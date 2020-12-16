float4x4 w;
float4x4 v;
float4x4 p;

float4 c;
float4 ln;
	
float h; 

texture txn;
sampler stxn = sampler_state
{
	texture = (txn);
	mipfilter = LINEAR;
	magfilter = LINEAR;
	minfilter = LINEAR;
};

texture txh;
sampler stxh = sampler_state
{
	texture = (txh);
	mipfilter = LINEAR;
	magfilter = LINEAR;
	minfilter = LINEAR;
};

struct VI
{
    float4 position : POSITION;
    float4 normal : NORMAL;
	float2 tex: TEXCOORD;
};

struct PI
{
    float4 position : POSITION;
    float4 normal : TEXCOORD0;
    float4 pos : TEXCOORD1;		
	float2 tex: TEXCOORD2;
};

// Код вершинного шейдера
PI VS0(VI IN)
{
    PI OUT;
	OUT.pos = IN.position;
    OUT.position = mul(mul(mul(IN.position, w), v), p);
    OUT.normal = IN.normal;
	OUT.tex = IN.tex;
    return OUT;
}

// Код пиксельного шейдера ps0
float4 PS0(PI IN) : COLOR
{
	float3 lpn = ln.xyz; //Параллельный
	float3 normcol = tex2D(stxn, IN.tex).xyz - float3(0.5, 0.5, 0.5);
	float diff = dot(normalize(normcol), normalize(lpn));
	//float diff = dot(normcol, normalize(lpn));
	return float4(c * diff);
}

// Код пиксельного шейдера ps1
float4 PS1(PI IN) : COLOR
{
	float4 lpn = ln - IN.pos; //Точечный источник
	float3 normcol = tex2D(stxn, IN.tex).xyz - float3(0.5, 0.5, 0.5);
	float diff = dot(normalize(normcol), normalize(lpn));
	float llpn = length(lpn);
	float atten = 2 / llpn / llpn;
	return float4(c * diff * atten);
}

// Код пиксельного шейдера ps3
float4 PS1(PI IN) : COLOR
{
	float4 lpn = ln - IN.pos; //Прожектор
	float3 normcol = tex2D(stxn, IN.tex).xyz - float3(0.5, 0.5, 0.5);
	float diff = dot(normalize(normcol), normalize(lpn));
	float llpn = length(lpn);
	float atten = 2 / llpn / llpn;
	return float4(c * diff * atten);
}

// Код пиксельного шейдера ps2
float4 PS2(PI IN) : COLOR
{		
	float s = 0.001;	                        
	float h0 = tex2D(stxh, IN.tex).x * h;
	float h1 = tex2D(stxh, float2(IN.tex.x + s, IN.tex.y)).x * h;
	float h2 = tex2D(stxh, float2(IN.tex.x, IN.tex.y - s)).x * h;
	float3 nor = normalize(cross(float3(s, 0, h1 - h0), float3(0, s, h2 - h0)));
	nor = nor * 0.5 + float3(0.5, 0.5, 0.5);
	return float4(nor.x, nor.y, nor.z, 0);
}

technique Main
{
	pass p0 
	{
		VertexShader = compile vs_2_0 VS0();
		PixelShader = compile ps_2_0 PS0();
	}
	pass p1 
	{
		VertexShader = compile vs_2_0 VS0();
		PixelShader = compile ps_2_0 PS1();
	}
	pass p2 
	{
		VertexShader = compile vs_2_0 VS0();
		PixelShader = compile ps_2_0 PS2();
	}
}
