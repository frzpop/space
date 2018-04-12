Shader "Frzpop/Gradient"
{
	Properties
		{
			_Color1("Color 1", Color) = (1,1,1,1)
			_Color2("Color 2", Color) = (1,1,1,1)
			_Center ("Center", Range (0.25, 1.75)) = 1
		}

	SubShader
	{
		Tags
		{
			"PreviewType" = "Plane"
		}
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			float4 _Color1;
			float4 _Color2;
			float _Center;

			float4 frag(v2f i) : SV_Target
			{
				//float val = lerp( i.uv.y * 2, i.uv.x * 2, _Angle);
				float4 lerped = lerp( _Color2, _Color1, i.uv.y * _Center );
				return lerped;
			}
			ENDCG
		}
	}
}
