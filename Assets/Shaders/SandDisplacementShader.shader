
Shader "Custom/SolidYellowSand"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0 // Ensure Shader Model 3.0 or higher
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex); // Simple vertex pass
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                return half4(0.5, 0.4, 0.3, 1.0); // Yellow
            }
            ENDCG
        }
    }

    Fallback "Diffuse"
}

