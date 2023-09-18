// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "SyntyStudios/WorldFog"
{
	Properties
	{
		_Texture("Texture", 2D) = "white" {}
		_FogColor("Fog Color", Color) = (0,1,0.7517242,0)
		_FogAmount("Fog Amount", Range( 0 , 1)) = 0
		_FogOffset("Fog Offset", Float) = 0
		_FogDistance("Fog Distance", Float) = 0
		_FogFalloff("Fog Falloff", Range( 0.001 , 1)) = 0.001
		_Specular("Specular", Range( 0 , 1)) = 0
		_SpecularSmoothness("Specular Smoothness", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
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
			float4 lerpResult14 = lerp( tex2DNode12 , _FogColor , _FogAmount);
			float3 ase_worldPos = i.worldPos;
			float clampResult13 = clamp( ( ( _FogOffset + ase_worldPos.y ) / _FogDistance ) , 0 , 1 );
			float temp_output_8_0 = pow( clampResult13 , _FogFalloff );
			float4 lerpResult11 = lerp( lerpResult14 , tex2DNode12 , temp_output_8_0);
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
2567;34;2546;1557;1249.864;571.367;1;True;True
Node;AmplifyShaderEditor.RangedFloatNode;19;-530.864,121.633;Float;False;Property;_FogOffset;Fog Offset;3;0;Create;True;0;0;26.29;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;5;-622.6179,241.7576;Float;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleAddOpNode;18;-376.864,249.633;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;7;-569.8688,521.9848;Float;False;Property;_FogDistance;Fog Distance;4;0;Create;True;0;0;14.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;6;-255.4985,461.4078;Float;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;13;-130.864,300.633;Float;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;2;-311.2385,-297.9739;Float;False;Property;_FogColor;Fog Color;1;0;Create;True;0;0,1,0.7517242,0;0.2745098,0,0.7960785,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;12;-317.2582,-112.6559;Float;True;Property;_Texture;Texture;0;0;Create;True;0;None;65bf252a1d0243b40a63ee08ad703289;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;15;-59.86401,-420.367;Float;False;Property;_FogAmount;Fog Amount;2;0;Create;True;0;0;0.894;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;9;-293.909,706.7017;Float;False;Property;_FogFalloff;Fog Falloff;5;0;Create;True;0;0.001;1;0.001;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;8;42.73656,486.9279;Float;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;14;117.136,-305.367;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ClampOpNode;10;359.1562,331.4656;Float;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;11;116.7418,-138.6559;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;17;-5.864014,153.633;Float;False;Property;_SpecularSmoothness;Specular Smoothness;7;0;Create;True;0;0;0.414;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;16;-3.864014,74.633;Float;False;Property;_Specular;Specular;6;0;Create;True;0;0;0.072;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;391.0693,-233.56;Float;False;True;2;Float;ASEMaterialInspector;0;0;StandardSpecular;SyntyStudios/WorldFog;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;0;False;0;0;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;0;0;0;0;False;2;15;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;OFF;OFF;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;18;0;19;0
WireConnection;18;1;5;2
WireConnection;6;0;18;0
WireConnection;6;1;7;0
WireConnection;13;0;6;0
WireConnection;8;0;13;0
WireConnection;8;1;9;0
WireConnection;14;0;12;0
WireConnection;14;1;2;0
WireConnection;14;2;15;0
WireConnection;10;0;8;0
WireConnection;11;0;14;0
WireConnection;11;1;12;0
WireConnection;11;2;8;0
WireConnection;0;0;11;0
WireConnection;0;3;16;0
WireConnection;0;4;17;0
ASEEND*/
//CHKSM=40BE5331D2C77ECAF5B93E8EBE0951041FDC3385