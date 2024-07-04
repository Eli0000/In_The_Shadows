Shader "Custom/ShadowMapShader"
{


    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _ShadowMap ("Shadow Map", 2D) = "white" {}
        
    }
    
        SubShader
    {
        Tags { "RenderType"="Opaque" }
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };
            
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 texcoord : TEXCOORD0;
            };
            
            sampler2D _MainTex;
            sampler2D _ShadowMap;
            
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                // Échantillonnez la shadow map pour récupérer l'intensité de l'ombre
                float shadowIntensity = tex2Dproj(_ShadowMap, UNITY_PROJ_COORD(i.vertex)).r;

                
            
                // Utilisez l'intensité de l'ombre pour moduler la couleur principale de l'objet
                fixed4 col = tex2D(_MainTex, i.texcoord) * shadowIntensity;
                
                return col;
            }
            ENDCG
        }
    }
    
    // Option de repli si le shader n'est pas pris en charge
    FallBack "Diffuse"
}