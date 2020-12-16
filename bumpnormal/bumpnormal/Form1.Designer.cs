namespace bumpnormal
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.m1 = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьКартуВысотToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКартуВысотToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьКартуНормалейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКартуНормалейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m12 = new System.Windows.Forms.ToolStripMenuItem();
            this.m2 = new System.Windows.Forms.ToolStripMenuItem();
            this.m27 = new System.Windows.Forms.ToolStripMenuItem();
            this.цветОбразцаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.освещениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изТочкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изКамерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m22 = new System.Windows.Forms.ToolStripMenuItem();
            this.нормализоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нормализоватьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.инвертироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.преобразоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.использоватьCPUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.использоватьGPUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m1,
            this.m2,
            this.нормализоватьToolStripMenuItem,
            this.преобразоватьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // m1
            // 
            this.m1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьКартуВысотToolStripMenuItem,
            this.сохранитьКартуВысотToolStripMenuItem,
            this.открытьКартуНормалейToolStripMenuItem,
            this.сохранитьКартуНормалейToolStripMenuItem,
            this.m12});
            this.m1.Name = "m1";
            this.m1.Size = new System.Drawing.Size(48, 20);
            this.m1.Text = "Файл";
            // 
            // открытьКартуВысотToolStripMenuItem
            // 
            this.открытьКартуВысотToolStripMenuItem.Name = "открытьКартуВысотToolStripMenuItem";
            this.открытьКартуВысотToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.открытьКартуВысотToolStripMenuItem.Text = "Открыть карту высот";
            this.открытьКартуВысотToolStripMenuItem.Click += new System.EventHandler(this.открытьКартуВысотToolStripMenuItem_Click);
            // 
            // сохранитьКартуВысотToolStripMenuItem
            // 
            this.сохранитьКартуВысотToolStripMenuItem.Name = "сохранитьКартуВысотToolStripMenuItem";
            this.сохранитьКартуВысотToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.сохранитьКартуВысотToolStripMenuItem.Text = "Сохранить карту высот";
            this.сохранитьКартуВысотToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКартуВысотToolStripMenuItem_Click);
            // 
            // открытьКартуНормалейToolStripMenuItem
            // 
            this.открытьКартуНормалейToolStripMenuItem.Name = "открытьКартуНормалейToolStripMenuItem";
            this.открытьКартуНормалейToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.открытьКартуНормалейToolStripMenuItem.Text = "Открыть карту нормалей";
            this.открытьКартуНормалейToolStripMenuItem.Click += new System.EventHandler(this.открытьКартуНормалейToolStripMenuItem_Click);
            // 
            // сохранитьКартуНормалейToolStripMenuItem
            // 
            this.сохранитьКартуНормалейToolStripMenuItem.Name = "сохранитьКартуНормалейToolStripMenuItem";
            this.сохранитьКартуНормалейToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.сохранитьКартуНормалейToolStripMenuItem.Text = "Сохранить карту нормалей";
            this.сохранитьКартуНормалейToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКартуНормалейToolStripMenuItem_Click);
            // 
            // m12
            // 
            this.m12.Name = "m12";
            this.m12.Size = new System.Drawing.Size(225, 22);
            this.m12.Text = "Выход";
            this.m12.Click += new System.EventHandler(this.m12_Click);
            // 
            // m2
            // 
            this.m2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m27,
            this.цветОбразцаToolStripMenuItem,
            this.освещениеToolStripMenuItem,
            this.m22});
            this.m2.Name = "m2";
            this.m2.Size = new System.Drawing.Size(79, 20);
            this.m2.Text = "Настройки";
            // 
            // m27
            // 
            this.m27.Name = "m27";
            this.m27.Size = new System.Drawing.Size(240, 22);
            this.m27.Text = "Фон";
            this.m27.Click += new System.EventHandler(this.m27_Click);
            // 
            // цветОбразцаToolStripMenuItem
            // 
            this.цветОбразцаToolStripMenuItem.Name = "цветОбразцаToolStripMenuItem";
            this.цветОбразцаToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.цветОбразцаToolStripMenuItem.Text = "Цвет образца";
            this.цветОбразцаToolStripMenuItem.Click += new System.EventHandler(this.цветОбразцаToolStripMenuItem_Click);
            // 
            // освещениеToolStripMenuItem
            // 
            this.освещениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изТочкиToolStripMenuItem,
            this.изКамерыToolStripMenuItem});
            this.освещениеToolStripMenuItem.Name = "освещениеToolStripMenuItem";
            this.освещениеToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.освещениеToolStripMenuItem.Text = "Освещение";
            // 
            // изТочкиToolStripMenuItem
            // 
            this.изТочкиToolStripMenuItem.CheckOnClick = true;
            this.изТочкиToolStripMenuItem.Name = "изТочкиToolStripMenuItem";
            this.изТочкиToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.изТочкиToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.изТочкиToolStripMenuItem.Text = "Точечное";
            this.изТочкиToolStripMenuItem.Click += new System.EventHandler(this.изТочкиToolStripMenuItem_Click);
            // 
            // изКамерыToolStripMenuItem
            // 
            this.изКамерыToolStripMenuItem.Checked = true;
            this.изКамерыToolStripMenuItem.CheckOnClick = true;
            this.изКамерыToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.изКамерыToolStripMenuItem.Name = "изКамерыToolStripMenuItem";
            this.изКамерыToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.изКамерыToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.изКамерыToolStripMenuItem.Text = "Из камеры";
            this.изКамерыToolStripMenuItem.Click += new System.EventHandler(this.изКамерыToolStripMenuItem_Click);
            // 
            // m22
            // 
            this.m22.Name = "m22";
            this.m22.Size = new System.Drawing.Size(240, 22);
            this.m22.Text = "Исходное положение камеры";
            this.m22.Click += new System.EventHandler(this.m22_Click);
            // 
            // нормализоватьToolStripMenuItem
            // 
            this.нормализоватьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.нормализоватьToolStripMenuItem1,
            this.инвертироватьToolStripMenuItem});
            this.нормализоватьToolStripMenuItem.Name = "нормализоватьToolStripMenuItem";
            this.нормализоватьToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.нормализоватьToolStripMenuItem.Text = "Карта высот";
            // 
            // нормализоватьToolStripMenuItem1
            // 
            this.нормализоватьToolStripMenuItem1.Name = "нормализоватьToolStripMenuItem1";
            this.нормализоватьToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.нормализоватьToolStripMenuItem1.Text = "Нормализовать";
            this.нормализоватьToolStripMenuItem1.Click += new System.EventHandler(this.нормализоватьToolStripMenuItem_Click);
            // 
            // инвертироватьToolStripMenuItem
            // 
            this.инвертироватьToolStripMenuItem.Name = "инвертироватьToolStripMenuItem";
            this.инвертироватьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.инвертироватьToolStripMenuItem.Text = "Инвертировать";
            this.инвертироватьToolStripMenuItem.Click += new System.EventHandler(this.инвертироватьToolStripMenuItem_Click);
            // 
            // преобразоватьToolStripMenuItem
            // 
            this.преобразоватьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.использоватьCPUToolStripMenuItem,
            this.использоватьGPUToolStripMenuItem});
            this.преобразоватьToolStripMenuItem.Name = "преобразоватьToolStripMenuItem";
            this.преобразоватьToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.преобразоватьToolStripMenuItem.Text = "Карта нормалей";
            // 
            // использоватьCPUToolStripMenuItem
            // 
            this.использоватьCPUToolStripMenuItem.Name = "использоватьCPUToolStripMenuItem";
            this.использоватьCPUToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.использоватьCPUToolStripMenuItem.Text = "Использовать CPU";
            this.использоватьCPUToolStripMenuItem.Click += new System.EventHandler(this.преобразоватьToolStripMenuItem_Click);
            // 
            // использоватьGPUToolStripMenuItem
            // 
            this.использоватьGPUToolStripMenuItem.Name = "использоватьGPUToolStripMenuItem";
            this.использоватьGPUToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.использоватьGPUToolStripMenuItem.Text = "Использовать GPU";
            this.использоватьGPUToolStripMenuItem.Click += new System.EventHandler(this.использоватьGPUToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(744, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 200);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(944, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(153, 17);
            this.toolStripStatusLabel1.Text = "Освещение параллельное";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel2.Text = "из камеры";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(162, 17);
            this.toolStripStatusLabel3.Text = "| Максимальная высота 0,01";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(90, 17);
            this.toolStripStatusLabel4.Text = "Прожектор";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(744, 230);
            this.hScrollBar1.Minimum = 1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(200, 32);
            this.hScrollBar1.TabIndex = 5;
            this.hScrollBar1.Value = 10;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 441);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "Form1";
            this.Text = "Выщерблины";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem m1;
        private System.Windows.Forms.ToolStripMenuItem m2;
        private System.Windows.Forms.ToolStripMenuItem m27;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem m22;
        private System.Windows.Forms.ToolStripMenuItem m12;
        private System.Windows.Forms.ToolStripMenuItem цветОбразцаToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem открытьКартуВысотToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem преобразоватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКартуНормалейToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem освещениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изТочкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изКамерыToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem открытьКартуНормалейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нормализоватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКартуВысотToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem использоватьCPUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem использоватьGPUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нормализоватьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem инвертироватьToolStripMenuItem;
        private System.Windows.Forms.HScrollBar hScrollBar1;
    }
}

