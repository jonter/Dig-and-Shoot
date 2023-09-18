// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "SyntyStudios/LocalFog_Add"
{
	Properties
	{
		_Texture("Texture", 2D) = "white" {}
		_FogColor("Fog Color", Color) = (0,1,0.7517242,0)
		_FogAmount("Fog Amount", Range( 0 , 1)) = 0
		_FogOffset("Fog Offset", Float) = 0.5303507
		_FogDistance("Fog Distance", Float) = 0
		_FogFalloff("Fog Falloff", Range( 0 , 1)) = 0
		_Specular("Specular", Range( 0 , 1)) = 0.5303507
		_SpecularSmoothness("Specular Smoothness", Range( 0 , 1)) = 0.5303507
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf StandardSpecular keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
			float3 worldPos;
		};

		uniform sampler2D _Texture;
		uniform float4 _Texture_ST;
		uniform float4 _FogColor;
		uniform float _FogAmount;
		uniform float _FogOffset;
		uniform float _FogDistance;
		uniform float _FogFalloff;
		uniform float _Specular;
		uniform float _SpecularSmoothness;

		void surf( Input i , inout SurfaceOutputStandardSpecular o )
		{
			float2 uv_Texture = i.uv_texcoord * _Texture_ST.xy + _Texture_ST.zw;
			float4 tex2DNode12 = tex2D( _Texture, uv_Texture );
			float4 lerpResult19 = lerp( tex2DNode12 , _FogColor , _FogAmount);
			float4 blendOpSrc26 = lerpResult19;
			float4 blendOpDest26 = tex2DNode12;
			float3 ase_vertex3Pos = mul( unity_WorldToObject, float4( i.worldPos , 1 ) );
			float clampResult13 = clamp( ( ( _FogOffset + ase_vertex3Pos.y ) / _FogDistance ) , 0 , 1 );
			float4 lerpResult11 = lerp( ( saturate( ( 1.0 - ( 1.0 - blendOpSrc26 ) * ( 1.0 - blendOpDest26 ) ) )) , tex2DNode12 , pow( clampResult13 , _FogFalloff ));
			o.Albedo = lerpResult11.rgb;
			float3 temp_cast_1 = (_Specular).xxx;
			o.Specular = temp_cast_1;
			o.Smoothness = _SpecularSmoothness;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=14501
2567;34;2546;1524;1619.385;757.818;1.055;True;True
Node;AmplifyShaderEditor.RangedFloatNode;23;-687.2753,164.0416;Float;False;Property;_FogOffset;Fog Offset;3;0;Create;True;0;0.5303507;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;17;-684.1566,344.6728;Float;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;22;-434.0059,272.831;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;7;-689.1335,521.0497;Float;False;Property;_FogDistance;Fog Distance;4;0;Create;True;0;0;0.38;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;12;-670.2582,-152.6559;Float;True;Property;_Texture;Texture;0;0;Create;True;0;None;5c4675b8d1dac0a4d88f6171f38efeeb;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;20;-660.8936,-415.4081;Float;False;Property;_FogAmount;Fog Amount;2;0;Create;True;0;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;6;-323.6737,385.4029;Float;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;2;-661.7585,-326.3139;Float;False;Property;_FogColor;Fog Color;1;0;Create;True;0;0,1,0.7517242,0;0.572549,0.6666667,0.4039216,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ClampOpNode;13;-169.3238,345.983;Float;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;9;-293.7339,608.5917;Float;False;Property;_FogFalloff;Fog Falloff;5;0;Create;True;0;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;19;-204.8936,-331.4081;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.BlendOpsNode;26;27.47064,-327.3786;Float;False;Screen;True;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.PowerNode;8;22.65655,360.6181;Float;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;24;-197.4581,6.760544;Float;False;Property;_Specular;Specular;6;0;Create;True;0;0.5303507;0.134;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;25;-187.1378,88.03049;Float;False;Property;_SpecularSmoothness;Specular Smoothness;7;0;Create;True;0;0.5303507;0.489;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;11;252.331,-180.7659;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;464.5997,-167.7703;Float;False;True;2;Float;ASEMaterialInspector;0;0;StandardSpecular;SyntyStudios/LocalFog_Add;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;0;False;0;0;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;0;0;0;0;False;2;15;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;OFF;OFF;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;22;0;23;0
WireConnection;22;1;17;2
WireConnection;6;0;22;0
WireConnection;6;1;7;0
WireConnection;13;0;6;0
WireConnection;19;0;12;0
WireConnection;19;1;2;0
WireConnection;19;2;20;0
WireConnection;26;0;19;0
WireConnection;26;1;12;0
WireConnection;8;0;13;0
WireConnection;8;1;9;0
WireConnection;11;0;26;0
WireConnection;11;1;12;0
WireConnection;11;2;8;0
WireConnection;0;0;11;0
WireConnection;0;3;24;0
WireConnection;0;4;25;0
ASEEND*/
//CHKSM=35C8EE1A78A6A7DC5BBEABB33AAF029CE6B295E4