using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace bumpnormal
{
    public partial class Form1 : Form
    {
        Color bc, pc;
        Device dr;
        PresentParameters ppr = new PresentParameters();
        CustomVertex.PositionNormalTextured[] dp = new CustomVertex.PositionNormalTextured[4] //Прямоугольник
        { 
            new CustomVertex.PositionNormalTextured(-0.5f, -0.5f, 0, 0, 0, 1, 0, 1),
            new CustomVertex.PositionNormalTextured(-0.5f, 0.5f, 0, 0, 0, 1, 0, 0), 
            new CustomVertex.PositionNormalTextured(0.5f, 0.5f, 0, 0, 0, 1, 1, 0), 
            new CustomVertex.PositionNormalTextured(0.5f, -0.5f, 0, 0, 0, 1, 1, 1)
        };
        //Карты нормалей и высот
        Texture txn, txh; //Текстуры
        Bitmap bmnm, bmhm; //Изображения

        float himax = 0.01f, step = 0.001f, hdv = 1;
        Effect eff;
        //cp – вектор камеры
        //cp0 – вектор камеры при нажатии ПКМ
        //ct – вектор цели
        //cup – вектор направления вверх
        Vector3 cp = new Vector3(0, -1, 1), cp0, ct = new Vector3(0, 0, 0), cup = new Vector3(0, 0, 1), lt;
        Point cur0; //Положение указателя при нажатии ПКМ
        float pi = (float)Math.PI;
        GraphicsStream gstr;

        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
            bc = this.BackColor;
            pc = Color.LightGray;
        }

        //Инициализация 3D устройства Low
        private bool InitializeGraphicsL()
        {
            try
            {
                ppr.Windowed = true; //Оконный режим
                ppr.SwapEffect = SwapEffect.Discard; //Гарантированный режим переключения заднего буфера
                ppr.MultiSample = MultiSampleType.None; //Без сглаживания
                //Попытка создать 3D устройство с программной обработкой вершин
                dr = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, ppr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Инициализация 3D устройства Hi
        private bool InitializeGraphicsH()
        {
            try
            {
                ppr.Windowed = true;
                ppr.SwapEffect = SwapEffect.Discard;
                ppr.MultiSample = MultiSampleType.FourSamples; //Четвертый уровень сглаживания
                //Попытка создать 3D устройство с аппаратной обработкой вершин
                dr = new Device(0, DeviceType.Hardware, this, CreateFlags.HardwareVertexProcessing, ppr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            //Попытка инициализации 3D устройства
            if (!this.InitializeGraphicsH())
            {
                if (!this.InitializeGraphicsL())
                {
                    MessageBox.Show("Невозможно инициализировать Direct3D устройство. Программа будет закрыта.");
                    this.Close();
                }
            }
            eff = Effect.FromFile(dr, "bumpnormal.fx", null, ShaderFlags.None, null);
            timer1.Enabled = true; //Включение таймера
        }

        //Обзор мышкой
        private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Vector3 cpt = cp0;
            //Облет вокруг цели
            if (e.Button == MouseButtons.Right)
            {
                float alpha = (float)(e.X - cur0.X) / this.ClientSize.Width * pi * 2;
                float beta = (float)(e.Y - cur0.Y) / this.ClientSize.Height * pi;
                float beta0 = (float)Math.Asin(cp0.Z / cp0.Length());
                if ((beta + beta0) > 1.5f) beta = 1.5f - beta0; //Ограничение обзора
                if ((beta + beta0) < 0.2f) beta = 0.2f - beta0;
                cp = Vector3.TransformCoordinate(cp0, Matrix.RotationAxis(Vector3.Cross(cp0, cup), beta) * Matrix.RotationZ(-alpha));
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            cur0 = e.Location;
            cp0 = cp;
        }

        //Приближение/удаление СКМ
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            Vector3 cpt = cp;
            float dc = cpt.Length();
            if (e.Delta < 0)
            {
                if (dc > 1) cpt = cpt * 0.9f;
            }
            if (e.Delta > 0)
            {
                if (dc < 10) cpt = cpt * 1.1f;
            }
            cp = cpt;
        }

        //Вывод по таймеру
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                dr.BeginScene();

                float ar = (float)this.ClientSize.Width / (float)this.ClientSize.Height;
                dr.RenderState.NormalizeNormals = true;
                dr.Transform.World = Matrix.Scaling(hdv, 1, 1);
                dr.Transform.Projection = Matrix.PerspectiveFovRH(pi / 4f, ar, 0.1f, 20);
                dr.Clear(ClearFlags.Target, bc, 1f, 0);
                dr.Transform.View = Matrix.LookAtRH(cp, ct, cup);
                if (изКамерыToolStripMenuItem.Checked) lt = cp; //Положение

                dr.RenderState.CullMode = Cull.None;

                eff.SetValue("w", dr.Transform.World);
                eff.SetValue("v", dr.Transform.View);
                eff.SetValue("p", dr.Transform.Projection);
                eff.SetValue("ln", new float[] { lt.X, lt.Y, lt.Z });
                eff.SetValue("txn", txn);
                eff.SetValue("txh", txh);
                eff.SetValue("c", ColorValue.FromColor(pc));
                eff.Begin(FX.None);
                eff.BeginPass((изТочкиToolStripMenuItem.Checked) ? 1 : 0);
                dr.VertexFormat = CustomVertex.PositionNormalTextured.Format;
                dr.DrawUserPrimitives(PrimitiveType.TriangleFan, 2, dp);

                eff.EndPass();
                eff.End();

                dr.EndScene();
                dr.Present();
            }
            catch
            {
                this.Close();
            }
        }

        //Фон
        private void m27_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                bc = colorDialog1.Color;
            }
        }

        //Исходное положение камеры
        private void m22_Click(object sender, EventArgs e)
        {
            cp = ct + new Vector3(0, -1, 1);
        }

        //Выход
        private void m12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Цвет образца
        private void цветТекстурыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pc = colorDialog1.Color;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Width = ClientSize.Width / 4;
            pictureBox1.Height = pictureBox1.Width;
            pictureBox2.Width = pictureBox1.Width;
            pictureBox2.Height = pictureBox1.Width;
            pictureBox1.Left = 0;
            pictureBox2.Left = ClientSize.Width - pictureBox2.Width;
            pictureBox1.Top = menuStrip1.Height;
            pictureBox2.Top = menuStrip1.Height;
            hScrollBar1.Width = pictureBox2.Width;
            hScrollBar1.Top = menuStrip1.Height + pictureBox2.Height;
            hScrollBar1.Left = pictureBox2.Left;
        }

        private void открытьКартуВысотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Карта высот(*.jpg)|*.jpg";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    if (bmhm != null) bmhm.Dispose();
                    bmhm = (Bitmap)pictureBox1.Image;
                    if (txh != null) txh.Dispose();
                    txh = Texture.FromBitmap(dr, bmhm, Usage.None, Pool.Managed);
                }
                catch
                {
                    MessageBox.Show("Ошибка при загрузке текстуры");
                }
            }
        }

        private void преобразоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {                                  
            if (pictureBox1.Image == null) return;
            Vector3 tnorm, znorm = new Vector3(0, 0, 1);
            if (bmnm != null) bmnm.Dispose();
            bmnm = new Bitmap(bmhm);
            for (int i = 0; i < bmnm.Width; i++)
            {
                for (int j = 0; j < bmnm.Height; j++)
                {
                    tnorm = znorm;
                    if ((i != 0) && (j != 0))
                    {
                        float h0 = (float)bmhm.GetPixel(i, j).R / 255 * himax;	
                        float h1 = (float)bmhm.GetPixel(i - 1, j).R / 255 * himax;	
                        float h2 = (float)bmhm.GetPixel(i, j - 1).R / 255 * himax;	
                        tnorm = Vector3.Normalize(Vector3.Cross(new Vector3(step, 0, h0 - h1), new Vector3(0, step, h2 - h0))) * 0.5f + new Vector3(0.5f, 0.5f, 0.5f);
                    } 
                    var pij = Color.FromArgb((int)(tnorm.X * 255), (int)(tnorm.Y * 255), (int)(tnorm.Z * 255));
                    bmnm.SetPixel(i, j, pij);
                }
            }
            if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
            pictureBox2.Image = (Image)bmnm;
            hdv = (float)bmnm.Width / (float)bmnm.Height;
            if (txn != null) txn.Dispose();
            txn = Texture.FromBitmap(dr, bmnm, Usage.None, Pool.Managed);
        }

        //private void сохранитьКартуНормалейToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    saveFileDialog1.Filter = "Карта нормалей(*.jpg)|*.jpg";
        //    if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
        //    {
        //        try
        //        {
        //            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
        //            EncoderParameters myEncoderParameters = new EncoderParameters();
        //            myEncoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
        //            pictureBox2.Image.Save(saveFileDialog1.FileName, jpgEncoder, myEncoderParameters);
        //        }
        //        catch
        //        {
        //            MessageBox.Show("Ошибка при сохранении файла");
        //        }
        //    }
        //}

        private void НаправленныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = (изКамерыToolStripMenuItem.Checked) ? "Направленный источник" : " ";
        }

        private void изТочкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = (изТочкиToolStripMenuItem.Checked) ? "Освещение точечное" : "Освещение параллельное";
        }

        private void прожекторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = (изТочкиToolStripMenuItem.Checked) ? "Прожектор" : "Освещение затухание";
        }

        private void открытьКартуНормалейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Карта нормалей(*.jpg)|*.jpg";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                try
                {
                    pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
                    if (bmnm != null) bmnm.Dispose();
                    bmnm = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                    hdv = (float)bmnm.Width / (float)bmnm.Height;
                    txn = Texture.FromBitmap(dr, bmnm, Usage.None, Pool.Managed);
                }
                catch
                {
                    MessageBox.Show("Ошибка при загрузке текстуры");
                }
            }  
        }

        private void нормализоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;
            byte rmin = bmhm.GetPixel(0, 0).R, rmax = bmhm.GetPixel(0, 0).R;
            for (int i = 0; i < bmhm.Width; i++)
            {
                for (int j = 0; j < bmhm.Height; j++)
                {
                    if (bmhm.GetPixel(i, j).R > rmax) rmax = bmhm.GetPixel(i, j).R;
                    if (bmhm.GetPixel(i, j).R < rmin) rmin = bmhm.GetPixel(i, j).R;
                }
            }
            if (rmin == 0 && rmax == 255) return;
            float k = 255.0f / rmax;
            for (int i = 0; i < bmhm.Width; i++)
            {
                for (int j = 0; j < bmhm.Height; j++)
                {
                    var pij = Color.FromArgb((int)(bmhm.GetPixel(i, j).R * k), (int)(bmhm.GetPixel(i, j).R * k), (int)(bmhm.GetPixel(i, j).R * k));
                    bmhm.SetPixel(i, j, pij);
                }
            }
            pictureBox1.Image = (Image)bmhm;
            if (txh != null) txh.Dispose();
            txh = Texture.FromBitmap(dr, bmhm, Usage.None, Pool.Managed);
        }

        private void сохранитьКартуВысотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Карта высот(*.jpg)|*.jpg";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {
                try
                {
                    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                    EncoderParameters myEncoderParameters = new EncoderParameters();
                    myEncoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                    pictureBox1.Image.Save(saveFileDialog1.FileName, jpgEncoder, myEncoderParameters);
                }
                catch
                {
                    MessageBox.Show("Ошибка при сохранении файла");
                }
            }
        }

        private void использоватьGPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;
            Surface newbb = dr.CreateRenderTarget(bmhm.Width, bmhm.Height, Format.A8R8G8B8, MultiSampleType.None, 0, true);
            Surface oldbb = dr.GetRenderTarget(0);
            dr.SetRenderTarget(0, newbb);
            dr.BeginScene();
            dr.Clear(ClearFlags.Target, Color.Black, 1f, 0); //Очистка фона
            eff.SetValue("w", Matrix.Scaling(2.0f, 2.0f, 2.0f));
            eff.SetValue("v", Matrix.RotationX(0));
            eff.SetValue("p", Matrix.RotationX(0));
            eff.SetValue("txh", txh);
            eff.SetValue("h", himax);
            eff.Begin(FX.None);
            eff.BeginPass(2);
            dr.VertexFormat = CustomVertex.PositionNormalTextured.Format;
            dr.DrawUserPrimitives(PrimitiveType.TriangleFan, 2, dp);
            eff.EndPass();
            eff.End();
            dr.EndScene();

            if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
            if (gstr != null) gstr.Dispose();
            gstr = SurfaceLoader.SaveToStream(ImageFileFormat.Bmp, newbb);
            if (bmnm != null) bmnm.Dispose();
            bmnm = (Bitmap)Image.FromStream(gstr);
            pictureBox2.Image = (Image)bmnm;
            hdv = (float)bmnm.Width / (float)bmnm.Height;
            if (txn != null) txn.Dispose();
            txn = Texture.FromBitmap(dr, bmnm, Usage.None, Pool.Managed);
            dr.SetRenderTarget(0, oldbb);
            newbb.Dispose();
            oldbb.Dispose();
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void инвертироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;
            for (int i = 0; i < bmhm.Width; i++)
            {
                for (int j = 0; j < bmhm.Height; j++)
                {
                    var pij = Color.FromArgb((int)(255 - bmhm.GetPixel(i, j).R), (int)(255 - bmhm.GetPixel(i, j).R), (int)(255 - bmhm.GetPixel(i, j).R));
                    bmhm.SetPixel(i, j, pij);
                }
            }
            pictureBox1.Image = (Image)bmhm;
            if (txh != null) txh.Dispose();
            txh = Texture.FromBitmap(dr, bmhm, Usage.None, Pool.Managed);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            himax = hScrollBar1.Value * 0.001f;
            toolStripStatusLabel3.Text = "| Максимальная высота " + himax.ToString();
        }  
    }
}
