Shader "VertexFragment"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ScaleUVX("Scale X", Range(1,10)) = 1
        _ScaleUVX("Scale Y", Range(1,10)) = 1
    }
    SubShader
    {
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
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            //sampler2D _GrabTexure;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _ScaleUVX;
            float _ScaleUVY;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv.x = sin(o.uv.x * _ScaleUVX);
                o.uv.y = sin(o.uv.y * _ScaleUVY);
                return o; 
            }

            fixed4 frag(v2f i) : SV_TARGET
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                //fixed4 col = tex2D(_GrabTexure, i.uv);
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}