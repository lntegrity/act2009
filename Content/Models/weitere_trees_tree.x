xof 0302txt 0064
// File created by CINEMA 4D

template Header {
 <3D82AB43-62DA-11cf-AB39-0020AF71E433>
 SWORD major;
 SWORD minor;
 DWORD flags;
}

template Vector {
 <3D82AB5E-62DA-11cf-AB39-0020AF71E433>
 FLOAT x;
 FLOAT y;
 FLOAT z;
}

template Coords2d {
 <F6F23F44-7686-11cf-8F52-0040333594A3>
 FLOAT u;
 FLOAT v;
}

template Matrix4x4 {
 <F6F23F45-7686-11cf-8F52-0040333594A3>
 array FLOAT matrix[16];
}

template ColorRGBA {
 <35FF44E0-6C7C-11cf-8F52-0040333594A3>
 FLOAT red;
 FLOAT green;
 FLOAT blue;
 FLOAT alpha;
}

template ColorRGB {
 <D3E16E81-7835-11cf-8F52-0040333594A3>
 FLOAT red;
 FLOAT green;
 FLOAT blue;
}

template IndexedColor {
 <1630B820-7842-11cf-8F52-0040333594A3>
 DWORD index;
 ColorRGBA indexColor;
}

template Boolean {
 <4885AE61-78E8-11cf-8F52-0040333594A3>
 SWORD truefalse;
}

template Boolean2d {
 <4885AE63-78E8-11cf-8F52-0040333594A3>
 Boolean u;
 Boolean v;
}

template MaterialWrap {
 <4885AE60-78E8-11cf-8F52-0040333594A3>
 Boolean u;
 Boolean v;
}

template TextureFilename {
 <A42790E1-7810-11cf-8F52-0040333594A3>
 STRING filename;
}

template Material {
 <3D82AB4D-62DA-11cf-AB39-0020AF71E433>
 ColorRGBA faceColor;
 FLOAT power;
 ColorRGB specularColor;
 ColorRGB emissiveColor;
 [...]
}

template MeshFace {
 <3D82AB5F-62DA-11cf-AB39-0020AF71E433>
 DWORD nFaceVertexIndices;
 array DWORD faceVertexIndices[nFaceVertexIndices];
}

template MeshFaceWraps {
 <4885AE62-78E8-11cf-8F52-0040333594A3>
 DWORD nFaceWrapValues;
 Boolean2d faceWrapValues;
}

template MeshTextureCoords {
 <F6F23F40-7686-11cf-8F52-0040333594A3>
 DWORD nTextureCoords;
 array Coords2d textureCoords[nTextureCoords];
}

template MeshMaterialList {
 <F6F23F42-7686-11cf-8F52-0040333594A3>
 DWORD nMaterials;
 DWORD nFaceIndexes;
 array DWORD faceIndexes[nFaceIndexes];
 [Material]
}

template MeshNormals {
 <F6F23F43-7686-11cf-8F52-0040333594A3>
 DWORD nNormals;
 array Vector normals[nNormals];
 DWORD nFaceNormals;
 array MeshFace faceNormals[nFaceNormals];
}

template MeshVertexColors {
 <1630B821-7842-11cf-8F52-0040333594A3>
 DWORD nVertexColors;
 array IndexedColor vertexColors[nVertexColors];
}

template Mesh {
 <3D82AB44-62DA-11cf-AB39-0020AF71E433>
 DWORD nVertices;
 array Vector vertices[nVertices];
 DWORD nFaces;
 array MeshFace faces[nFaces];
 [...]
}

template FrameTransformMatrix {
 <F6F23F41-7686-11cf-8F52-0040333594A3>
 Matrix4x4 frameMatrix;
}

template Frame {
 <3D82AB46-62DA-11cf-AB39-0020AF71E433>
 [...]
}

Header {
 1;
 0;
 1;
}



Mesh CINEMA4D_Mesh {
  242;
  // Treedemo
  2.191;2.755;-1.02;,
  -2.192;2.755;1.023;,
  2.515;3.183;-0.326;,
  -1.868;3.183;1.718;,
  2.839;3.604;0.37;,
  -1.544;3.604;2.413;,
  3.239;4.134;0.965;,
  -1.144;4.134;3.009;,
  4.01;4.97;1.783;,
  -0.373;4.97;3.827;,
  0.209;1.102;-2.404;,
  -0.213;1.102;2.414;,
  1.006;1.462;-2.334;,
  0.585;1.462;2.484;,
  1.805;1.814;-2.264;,
  1.383;1.814;2.553;,
  2.458;2.397;-2.083;,
  2.036;2.397;2.735;,
  3.252;3.468;-1.664;,
  2.83;3.468;3.153;,
  -2.193;1.102;1.027;,
  2.189;1.102;-1.017;,
  -2.532;1.462;0.301;,
  1.851;1.462;-1.742;,
  -2.871;1.814;-0.425;,
  1.512;1.814;-2.469;,
  -2.986;2.429;-1.072;,
  1.397;2.429;-3.116;,
  -2.874;3.577;-1.897;,
  1.508;3.577;-3.941;,
  1.979;1.102;1.392;,
  -1.983;1.102;-1.382;,
  1.519;1.462;2.048;,
  -2.442;1.462;-0.726;,
  1.06;1.814;2.704;,
  -2.902;1.814;-0.069;,
  0.654;2.323;3.306;,
  -3.307;2.323;0.532;,
  0.079;3.187;4.194;,
  -3.883;3.187;1.42;,
  -1.982;1.653;-1.383;,
  1.979;1.653;1.391;,
  -1.523;2.013;-2.039;,
  2.438;2.013;0.735;,
  -1.063;2.365;-2.695;,
  2.898;2.365;0.078;,
  -0.886;2.761;-3.516;,
  3.075;2.761;-0.742;,
  -1.088;3.302;-5.066;,
  2.873;3.302;-2.292;,
  -0.212;1.653;2.413;,
  0.209;1.653;-2.405;,
  -1.01;2.013;2.343;,
  -0.588;2.013;-2.475;,
  -1.808;2.365;2.273;,
  -1.387;2.365;-2.544;,
  -2.48;2.93;2.12;,
  -2.058;2.93;-2.698;,
  -3.345;3.953;1.77;,
  -2.924;3.953;-3.048;,
  2.19;1.653;-1.018;,
  -2.193;1.653;1.026;,
  2.528;2.013;-0.292;,
  -1.855;2.013;1.751;,
  2.867;2.365;0.434;,
  -1.516;2.365;2.478;,
  3.023;2.956;1.088;,
  -1.359;2.956;3.132;,
  3.021;4.045;1.971;,
  -1.361;4.045;4.015;,
  -2.193;2.204;1.024;,
  2.19;2.204;-1.019;,
  -2.531;2.564;0.299;,
  1.852;2.564;-1.745;,
  -2.87;2.916;-0.428;,
  1.513;2.916;-2.471;,
  -3.124;3.455;-1.085;,
  1.259;3.455;-3.129;,
  -3.408;4.405;-2.031;,
  0.975;4.405;-4.075;,
  1.979;2.204;1.39;,
  -1.982;2.204;-1.384;,
  1.52;2.564;2.045;,
  -2.441;2.564;-0.728;,
  1.061;2.916;2.702;,
  -2.901;2.916;-0.072;,
  0.73;3.377;3.389;,
  -3.231;3.377;0.616;,
  0.398;4.102;4.554;,
  -3.563;4.102;1.78;,
  0.21;2.204;-2.406;,
  -0.212;2.204;2.411;,
  1.007;2.564;-2.336;,
  0.586;2.564;2.481;,
  1.806;2.916;-2.266;,
  1.384;2.916;2.551;,
  2.57;3.372;-2.337;,
  2.148;3.372;2.481;,
  3.753;4.083;-2.672;,
  3.332;4.083;2.145;,
  -0.212;2.755;2.41;,
  0.21;2.755;-2.407;,
  -0.975;3.183;2.343;,
  -0.553;3.183;-2.474;,
  -1.739;3.604;2.276;,
  -1.318;3.604;-2.541;,
  -2.474;4.11;2.39;,
  -2.052;4.11;-2.428;,
  -3.618;4.878;2.861;,
  -3.196;4.878;-1.957;,
  -1.981;2.755;-1.386;,
  1.98;2.755;1.388;,
  -1.542;3.183;-2.013;,
  2.42;3.183;0.76;,
  -1.102;3.604;-2.642;,
  2.86;3.604;0.132;,
  -0.716;4.178;-3.198;,
  3.245;4.178;-0.424;,
  -0.17;5.143;-3.993;,
  3.791;5.143;-1.219;,
  1.98;3.306;1.387;,
  -1.981;3.306;-1.387;,
  1.564;3.799;1.982;,
  -2.398;3.799;-0.792;,
  1.146;4.285;2.578;,
  -2.815;4.285;-0.196;,
  0.707;5.004;2.904;,
  -3.254;5.004;0.131;,
  0.061;6.26;3.032;,
  -3.9;6.26;0.259;,
  0.211;3.306;-2.408;,
  -0.211;3.306;2.409;,
  0.934;3.799;-2.345;,
  0.513;3.799;2.472;,
  1.659;4.285;-2.282;,
  1.237;4.285;2.536;,
  2.232;4.955;-2.147;,
  1.811;4.955;2.67;,
  2.929;6.105;-1.839;,
  2.507;6.105;2.978;,
  -2.192;3.306;1.022;,
  2.191;3.306;-1.022;,
  -2.499;3.799;0.364;,
  1.884;3.799;-1.68;,
  -2.806;4.285;-0.296;,
  1.577;4.285;-2.339;,
  -2.821;5.028;-0.821;,
  1.562;5.028;-2.864;,
  -2.495;6.323;-1.34;,
  1.888;6.323;-3.384;,
  2.192;3.856;-1.023;,
  -2.191;3.856;1.021;,
  2.435;4.521;-0.502;,
  -1.948;4.521;1.542;,
  2.678;5.179;0.02;,
  -1.705;5.179;2.064;,
  3.058;5.902;0.408;,
  -1.325;5.902;2.452;,
  3.909;6.994;0.856;,
  -0.473;6.994;2.9;,
  -1.98;3.856;-1.388;,
  1.981;3.856;1.386;,
  -1.651;4.521;-1.859;,
  2.311;4.521;0.915;,
  -1.32;5.179;-2.33;,
  2.641;5.179;0.443;,
  -1.03;5.974;-2.618;,
  2.931;5.974;0.156;,
  -0.613;7.264;-2.84;,
  3.348;7.264;-0.066;,
  -0.211;3.856;2.408;,
  0.211;3.856;-2.41;,
  -0.783;4.521;2.358;,
  -0.362;4.521;-2.46;,
  -1.357;5.179;2.307;,
  -0.935;5.179;-2.51;,
  -1.835;5.933;2.332;,
  -1.413;5.933;-2.485;,
  -2.512;7.119;2.483;,
  -2.091;7.119;-2.334;,
  0.094;-0.001;0.107;,
  0.058;0.55;0.064;,
  0.143;-0.001;-0.029;,
  0.089;0.55;-0.019;,
  0.05;-0.001;-0.139;,
  0.032;0.55;-0.087;,
  -0.092;-0.001;-0.114;,
  -0.056;0.55;-0.072;,
  -0.141;-0.001;0.021;,
  -0.086;0.55;0.012;,
  -0.048;-0.001;0.132;,
  -0.029;0.55;0.08;,
  -0.048;-0.001;0.132;,
  -0.029;0.55;0.08;,
  0.044;1.101;0.047;,
  0.066;1.101;-0.015;,
  0.024;1.101;-0.066;,
  -0.041;1.101;-0.054;,
  -0.064;1.101;0.008;,
  -0.021;1.101;0.058;,
  -0.021;1.101;0.058;,
  0.038;1.652;0.04;,
  0.057;1.652;-0.014;,
  0.021;1.652;-0.057;,
  -0.035;1.652;-0.047;,
  -0.055;1.652;0.006;,
  -0.018;1.652;0.05;,
  -0.018;1.652;0.05;,
  0.032;2.203;0.033;,
  0.048;2.203;-0.012;,
  0.017;2.203;-0.048;,
  -0.029;2.203;-0.04;,
  -0.046;2.203;0.005;,
  -0.015;2.203;0.041;,
  -0.015;2.203;0.041;,
  0.026;2.754;0.026;,
  0.039;2.754;-0.01;,
  0.014;2.754;-0.04;,
  -0.024;2.754;-0.033;,
  -0.037;2.754;0.003;,
  -0.012;2.754;0.032;,
  -0.012;2.754;0.032;,
  0.02;3.305;0.019;,
  0.03;3.305;-0.009;,
  0.011;3.305;-0.031;,
  -0.018;3.305;-0.026;,
  -0.028;3.305;0.001;,
  -0.009;3.305;0.024;,
  -0.009;3.305;0.024;,
  0.014;3.856;0.012;,
  0.021;3.856;-0.007;,
  0.008;3.856;-0.023;,
  -0.012;3.856;-0.019;,
  -0.019;3.856;0.0;,
  -0.006;3.856;0.015;,
  -0.006;3.856;0.015;,
  0.001;4.053;-0.004;,
  0.001;4.053;-0.004;,
  0.001;4.053;-0.004;,
  0.001;4.053;-0.004;,
  0.001;4.053;-0.004;,
  0.001;4.053;-0.004;;
  
  234;
  // Treedemo
  3;3,1,2;,
  3;6,5,4;,
  3;7,5,6;,
  3;8,7,6;,
  3;9,7,8;,
  3;0,2,1;,
  3;2,4,3;,
  3;3,4,5;,
  3;12,11,10;,
  3;14,13,12;,
  3;15,13,14;,
  3;16,15,14;,
  3;17,15,16;,
  3;18,17,16;,
  3;11,12,13;,
  3;19,17,18;,
  3;22,21,20;,
  3;23,21,22;,
  3;24,23,22;,
  3;25,23,24;,
  3;26,25,24;,
  3;27,25,26;,
  3;28,27,26;,
  3;29,27,28;,
  3;33,31,32;,
  3;34,33,32;,
  3;35,33,34;,
  3;36,35,34;,
  3;37,35,36;,
  3;38,37,36;,
  3;30,32,31;,
  3;37,38,39;,
  3;42,41,40;,
  3;45,43,44;,
  3;46,45,44;,
  3;47,45,46;,
  3;48,47,46;,
  3;49,47,48;,
  3;41,42,43;,
  3;42,44,43;,
  3;52,51,50;,
  3;53,51,52;,
  3;54,53,52;,
  3;55,53,54;,
  3;56,55,54;,
  3;57,55,56;,
  3;58,57,56;,
  3;59,57,58;,
  3;62,61,60;,
  3;63,61,62;,
  3;64,63,62;,
  3;65,63,64;,
  3;66,65,64;,
  3;67,65,66;,
  3;68,67,66;,
  3;69,67,68;,
  3;72,71,70;,
  3;73,71,72;,
  3;74,73,72;,
  3;75,73,74;,
  3;76,75,74;,
  3;77,75,76;,
  3;78,77,76;,
  3;77,78,79;,
  3;82,81,80;,
  3;83,81,82;,
  3;84,83,82;,
  3;85,83,84;,
  3;86,85,84;,
  3;87,85,86;,
  3;88,87,86;,
  3;89,87,88;,
  3;92,91,90;,
  3;93,91,92;,
  3;94,93,92;,
  3;95,93,94;,
  3;96,95,94;,
  3;97,95,96;,
  3;98,97,96;,
  3;99,97,98;,
  3;102,101,100;,
  3;103,101,102;,
  3;104,103,102;,
  3;105,103,104;,
  3;106,105,104;,
  3;107,105,106;,
  3;108,107,106;,
  3;109,107,108;,
  3;112,111,110;,
  3;113,111,112;,
  3;114,113,112;,
  3;115,113,114;,
  3;116,115,114;,
  3;117,115,116;,
  3;118,117,116;,
  3;119,117,118;,
  3;122,121,120;,
  3;123,121,122;,
  3;124,123,122;,
  3;125,123,124;,
  3;126,125,124;,
  3;127,125,126;,
  3;128,127,126;,
  3;129,127,128;,
  3;132,131,130;,
  3;133,131,132;,
  3;134,133,132;,
  3;135,133,134;,
  3;136,135,134;,
  3;137,135,136;,
  3;138,137,136;,
  3;139,137,138;,
  3;142,141,140;,
  3;143,141,142;,
  3;144,143,142;,
  3;145,143,144;,
  3;146,145,144;,
  3;147,145,146;,
  3;148,147,146;,
  3;149,147,148;,
  3;152,151,150;,
  3;153,151,152;,
  3;154,153,152;,
  3;155,153,154;,
  3;156,155,154;,
  3;157,155,156;,
  3;158,157,156;,
  3;159,157,158;,
  3;162,161,160;,
  3;163,161,162;,
  3;164,163,162;,
  3;165,163,164;,
  3;166,165,164;,
  3;167,165,166;,
  3;168,167,166;,
  3;169,167,168;,
  3;172,171,170;,
  3;173,171,172;,
  3;174,173,172;,
  3;175,173,174;,
  3;176,175,174;,
  3;177,175,176;,
  3;178,177,176;,
  3;179,177,178;,
  3;182,181,180;,
  3;183,181,182;,
  3;185,182,184;,
  3;183,182,185;,
  3;187,184,186;,
  3;185,184,187;,
  3;189,186,188;,
  3;187,186,189;,
  3;191,188,190;,
  3;189,188,191;,
  3;180,193,192;,
  3;181,193,180;,
  3;183,194,181;,
  3;195,194,183;,
  3;196,183,185;,
  3;195,183,196;,
  3;197,185,187;,
  3;196,185,197;,
  3;198,187,189;,
  3;197,187,198;,
  3;199,189,191;,
  3;198,189,199;,
  3;181,200,193;,
  3;194,200,181;,
  3;195,201,194;,
  3;202,201,195;,
  3;203,195,196;,
  3;202,195,203;,
  3;204,196,197;,
  3;203,196,204;,
  3;205,197,198;,
  3;204,197,205;,
  3;206,198,199;,
  3;205,198,206;,
  3;194,207,200;,
  3;201,207,194;,
  3;202,208,201;,
  3;209,208,202;,
  3;210,202,203;,
  3;209,202,210;,
  3;211,203,204;,
  3;210,203,211;,
  3;212,204,205;,
  3;211,204,212;,
  3;213,205,206;,
  3;212,205,213;,
  3;201,214,207;,
  3;208,214,201;,
  3;209,215,208;,
  3;216,215,209;,
  3;217,209,210;,
  3;216,209,217;,
  3;218,210,211;,
  3;217,210,218;,
  3;219,211,212;,
  3;218,211,219;,
  3;220,212,213;,
  3;219,212,220;,
  3;208,221,214;,
  3;215,221,208;,
  3;216,222,215;,
  3;223,222,216;,
  3;224,216,217;,
  3;223,216,224;,
  3;225,217,218;,
  3;224,217,225;,
  3;226,218,219;,
  3;225,218,226;,
  3;227,219,220;,
  3;226,219,227;,
  3;215,228,221;,
  3;222,228,215;,
  3;223,229,222;,
  3;230,229,223;,
  3;231,223,224;,
  3;230,223,231;,
  3;232,224,225;,
  3;231,224,232;,
  3;233,225,226;,
  3;232,225,233;,
  3;234,226,227;,
  3;233,226,234;,
  3;222,235,228;,
  3;229,235,222;,
  3;230,236,229;,
  3;237,230,231;,
  3;238,231,232;,
  3;239,232,233;,
  3;240,233,234;,
  3;229,241,235;;
  
  MeshNormals {
    242;
    // Treedemo
    0.206;-0.873;0.442;,
    0.206;-0.873;0.442;,
    0.205;-0.874;0.44;,
    0.205;-0.875;0.439;,
    0.21;-0.868;0.45;,
    0.247;-0.812;0.529;,
    0.254;-0.798;0.546;,
    0.257;-0.793;0.552;,
    0.261;-0.787;0.559;,
    0.261;-0.787;0.559;,
    0.409;-0.912;0.036;,
    0.409;-0.912;0.036;,
    0.406;-0.913;0.036;,
    0.402;-0.915;0.035;,
    0.438;-0.898;0.038;,
    0.545;-0.837;0.048;,
    0.684;-0.727;0.06;,
    0.733;-0.677;0.064;,
    0.788;-0.612;0.069;,
    0.788;-0.612;0.069;,
    -0.173;-0.912;-0.372;,
    -0.173;-0.912;-0.372;,
    -0.173;-0.912;-0.371;,
    -0.172;-0.914;-0.368;,
    -0.188;-0.895;-0.404;,
    -0.241;-0.822;-0.516;,
    -0.309;-0.682;-0.663;,
    -0.334;-0.613;-0.716;,
    -0.361;-0.521;-0.774;,
    -0.361;-0.521;-0.774;,
    -0.235;-0.912;0.336;,
    -0.235;-0.912;0.336;,
    -0.235;-0.912;0.335;,
    -0.233;-0.914;0.333;,
    -0.244;-0.905;0.349;,
    -0.285;-0.867;0.408;,
    -0.336;-0.811;0.479;,
    -0.341;-0.804;0.487;,
    -0.363;-0.774;0.518;,
    -0.363;-0.774;0.518;,
    0.235;-0.912;-0.336;,
    0.235;-0.912;-0.336;,
    0.232;-0.915;-0.331;,
    0.231;-0.915;-0.33;,
    0.233;-0.914;-0.333;,
    0.247;-0.903;-0.352;,
    0.258;-0.893;-0.369;,
    0.252;-0.898;-0.36;,
    0.243;-0.905;-0.348;,
    0.243;-0.905;-0.348;,
    -0.409;-0.912;-0.036;,
    -0.409;-0.912;-0.036;,
    -0.408;-0.912;-0.036;,
    -0.405;-0.914;-0.035;,
    -0.435;-0.9;-0.038;,
    -0.533;-0.845;-0.047;,
    -0.659;-0.75;-0.058;,
    -0.702;-0.709;-0.061;,
    -0.751;-0.658;-0.066;,
    -0.751;-0.658;-0.066;,
    0.173;-0.912;0.372;,
    0.173;-0.912;0.372;,
    0.173;-0.912;0.371;,
    0.172;-0.914;0.368;,
    0.186;-0.897;0.4;,
    0.233;-0.834;0.501;,
    0.295;-0.717;0.632;,
    0.317;-0.663;0.679;,
    0.341;-0.592;0.731;,
    0.341;-0.592;0.731;,
    -0.173;-0.912;-0.372;,
    -0.173;-0.912;-0.372;,
    -0.173;-0.912;-0.371;,
    -0.172;-0.914;-0.368;,
    -0.182;-0.902;-0.391;,
    -0.219;-0.856;-0.469;,
    -0.264;-0.78;-0.567;,
    -0.271;-0.768;-0.581;,
    -0.295;-0.717;-0.632;,
    -0.295;-0.717;-0.632;,
    -0.235;-0.912;0.336;,
    -0.235;-0.912;0.336;,
    -0.235;-0.912;0.335;,
    -0.233;-0.914;0.333;,
    -0.24;-0.908;0.343;,
    -0.268;-0.884;0.383;,
    -0.301;-0.851;0.43;,
    -0.304;-0.848;0.434;,
    -0.307;-0.845;0.439;,
    -0.307;-0.845;0.439;,
    0.409;-0.912;0.036;,
    0.409;-0.912;0.036;,
    0.408;-0.912;0.036;,
    0.405;-0.914;0.035;,
    0.416;-0.909;0.036;,
    0.463;-0.885;0.041;,
    0.517;-0.855;0.045;,
    0.52;-0.853;0.045;,
    0.524;-0.851;0.046;,
    0.524;-0.851;0.046;,
    -0.486;-0.873;-0.043;,
    -0.486;-0.873;-0.043;,
    -0.485;-0.873;-0.042;,
    -0.482;-0.875;-0.042;,
    -0.491;-0.87;-0.043;,
    -0.53;-0.847;-0.046;,
    -0.572;-0.819;-0.05;,
    -0.571;-0.819;-0.05;,
    -0.57;-0.82;-0.05;,
    -0.57;-0.82;-0.05;,
    0.28;-0.873;-0.4;,
    0.28;-0.873;-0.4;,
    0.279;-0.873;-0.399;,
    0.278;-0.875;-0.397;,
    0.289;-0.864;-0.413;,
    0.329;-0.819;-0.47;,
    0.378;-0.753;-0.539;,
    0.391;-0.732;-0.558;,
    0.406;-0.707;-0.579;,
    0.406;-0.707;-0.579;,
    -0.322;-0.827;0.46;,
    -0.322;-0.827;0.46;,
    -0.322;-0.828;0.46;,
    -0.32;-0.829;0.458;,
    -0.341;-0.804;0.487;,
    -0.404;-0.71;0.577;,
    -0.482;-0.542;0.688;,
    -0.509;-0.46;0.727;,
    -0.536;-0.354;0.766;,
    -0.536;-0.354;0.766;,
    0.56;-0.827;0.049;,
    0.56;-0.827;0.049;,
    0.559;-0.828;0.049;,
    0.557;-0.829;0.049;,
    0.583;-0.811;0.051;,
    0.667;-0.743;0.058;,
    0.771;-0.633;0.067;,
    0.806;-0.588;0.071;,
    0.844;-0.531;0.074;,
    0.844;-0.531;0.074;,
    -0.238;-0.827;-0.509;,
    -0.238;-0.827;-0.509;,
    -0.237;-0.828;-0.509;,
    -0.236;-0.829;-0.506;,
    -0.254;-0.8;-0.544;,
    -0.305;-0.691;-0.655;,
    -0.369;-0.489;-0.791;,
    -0.39;-0.385;-0.837;,
    -0.409;-0.249;-0.878;,
    -0.409;-0.249;-0.878;,
    0.32;-0.654;0.686;,
    0.32;-0.654;0.686;,
    0.319;-0.655;0.685;,
    0.319;-0.656;0.684;,
    0.322;-0.649;0.69;,
    0.333;-0.616;0.714;,
    0.345;-0.578;0.74;,
    0.345;-0.576;0.741;,
    0.346;-0.574;0.742;,
    0.346;-0.574;0.742;,
    0.434;-0.654;-0.62;,
    0.434;-0.654;-0.62;,
    0.434;-0.655;-0.619;,
    0.433;-0.656;-0.618;,
    0.444;-0.633;-0.634;,
    0.479;-0.551;-0.684;,
    0.519;-0.425;-0.741;,
    0.532;-0.373;-0.76;,
    0.545;-0.31;-0.779;,
    0.545;-0.31;-0.779;,
    -0.754;-0.654;-0.066;,
    -0.754;-0.654;-0.066;,
    -0.753;-0.655;-0.066;,
    -0.751;-0.656;-0.066;,
    -0.763;-0.643;-0.067;,
    -0.803;-0.592;-0.07;,
    -0.848;-0.525;-0.074;,
    -0.858;-0.508;-0.075;,
    -0.87;-0.487;-0.076;,
    -0.87;-0.487;-0.076;,
    0.325;0.094;0.941;,
    0.545;0.078;0.835;,
    0.99;0.096;0.107;,
    0.98;0.063;0.189;,
    0.209;0.099;-0.973;,
    0.412;0.075;-0.908;,
    -0.738;0.099;-0.668;,
    -0.58;0.075;-0.811;,
    -0.947;0.099;0.305;,
    -0.992;0.075;0.097;,
    -0.763;0.087;0.64;,
    -0.764;0.073;0.641;,
    0.173;0.087;0.981;,
    0.173;0.081;0.982;,
    0.528;0.032;0.849;,
    0.975;0.026;0.219;,
    0.383;0.03;-0.923;,
    -0.608;0.03;-0.793;,
    -0.991;0.03;0.13;,
    -0.766;0.03;0.643;,
    0.174;0.034;0.984;,
    0.519;0.016;0.854;,
    0.972;0.015;0.235;,
    0.37;0.017;-0.929;,
    -0.619;0.017;-0.785;,
    -0.99;0.017;0.144;,
    -0.766;0.014;0.643;,
    0.174;0.014;0.985;,
    0.515;0.016;0.857;,
    0.968;0.015;0.252;,
    0.376;0.017;-0.926;,
    -0.614;0.017;-0.789;,
    -0.99;0.017;0.137;,
    -0.766;0.014;0.643;,
    0.174;0.014;0.985;,
    0.511;0.016;0.86;,
    0.963;0.015;0.269;,
    0.384;0.017;-0.923;,
    -0.607;0.017;-0.794;,
    -0.992;0.017;0.129;,
    -0.766;0.014;0.643;,
    0.174;0.014;0.985;,
    0.506;0.016;0.862;,
    0.958;0.015;0.287;,
    0.398;0.017;-0.917;,
    -0.596;0.017;-0.803;,
    -0.993;0.017;0.114;,
    -0.766;0.014;0.643;,
    0.174;0.014;0.985;,
    0.654;0.02;0.757;,
    0.958;0.02;0.286;,
    0.481;0.047;-0.876;,
    -0.518;0.047;-0.854;,
    -0.999;0.047;0.021;,
    -0.766;0.036;0.642;,
    0.174;0.017;0.985;,
    0.936;0.088;0.341;,
    0.763;0.087;-0.64;,
    -0.173;0.088;-0.981;,
    -0.936;0.088;-0.341;,
    -0.763;0.089;0.64;,
    0.173;0.088;0.981;;
    
    234;
    // Treedemo
    3;3,1,2;,
    3;6,5,4;,
    3;7,5,6;,
    3;8,7,6;,
    3;9,7,8;,
    3;0,2,1;,
    3;2,4,3;,
    3;3,4,5;,
    3;12,11,10;,
    3;14,13,12;,
    3;15,13,14;,
    3;16,15,14;,
    3;17,15,16;,
    3;18,17,16;,
    3;11,12,13;,
    3;19,17,18;,
    3;22,21,20;,
    3;23,21,22;,
    3;24,23,22;,
    3;25,23,24;,
    3;26,25,24;,
    3;27,25,26;,
    3;28,27,26;,
    3;29,27,28;,
    3;33,31,32;,
    3;34,33,32;,
    3;35,33,34;,
    3;36,35,34;,
    3;37,35,36;,
    3;38,37,36;,
    3;30,32,31;,
    3;37,38,39;,
    3;42,41,40;,
    3;45,43,44;,
    3;46,45,44;,
    3;47,45,46;,
    3;48,47,46;,
    3;49,47,48;,
    3;41,42,43;,
    3;42,44,43;,
    3;52,51,50;,
    3;53,51,52;,
    3;54,53,52;,
    3;55,53,54;,
    3;56,55,54;,
    3;57,55,56;,
    3;58,57,56;,
    3;59,57,58;,
    3;62,61,60;,
    3;63,61,62;,
    3;64,63,62;,
    3;65,63,64;,
    3;66,65,64;,
    3;67,65,66;,
    3;68,67,66;,
    3;69,67,68;,
    3;72,71,70;,
    3;73,71,72;,
    3;74,73,72;,
    3;75,73,74;,
    3;76,75,74;,
    3;77,75,76;,
    3;78,77,76;,
    3;77,78,79;,
    3;82,81,80;,
    3;83,81,82;,
    3;84,83,82;,
    3;85,83,84;,
    3;86,85,84;,
    3;87,85,86;,
    3;88,87,86;,
    3;89,87,88;,
    3;92,91,90;,
    3;93,91,92;,
    3;94,93,92;,
    3;95,93,94;,
    3;96,95,94;,
    3;97,95,96;,
    3;98,97,96;,
    3;99,97,98;,
    3;102,101,100;,
    3;103,101,102;,
    3;104,103,102;,
    3;105,103,104;,
    3;106,105,104;,
    3;107,105,106;,
    3;108,107,106;,
    3;109,107,108;,
    3;112,111,110;,
    3;113,111,112;,
    3;114,113,112;,
    3;115,113,114;,
    3;116,115,114;,
    3;117,115,116;,
    3;118,117,116;,
    3;119,117,118;,
    3;122,121,120;,
    3;123,121,122;,
    3;124,123,122;,
    3;125,123,124;,
    3;126,125,124;,
    3;127,125,126;,
    3;128,127,126;,
    3;129,127,128;,
    3;132,131,130;,
    3;133,131,132;,
    3;134,133,132;,
    3;135,133,134;,
    3;136,135,134;,
    3;137,135,136;,
    3;138,137,136;,
    3;139,137,138;,
    3;142,141,140;,
    3;143,141,142;,
    3;144,143,142;,
    3;145,143,144;,
    3;146,145,144;,
    3;147,145,146;,
    3;148,147,146;,
    3;149,147,148;,
    3;152,151,150;,
    3;153,151,152;,
    3;154,153,152;,
    3;155,153,154;,
    3;156,155,154;,
    3;157,155,156;,
    3;158,157,156;,
    3;159,157,158;,
    3;162,161,160;,
    3;163,161,162;,
    3;164,163,162;,
    3;165,163,164;,
    3;166,165,164;,
    3;167,165,166;,
    3;168,167,166;,
    3;169,167,168;,
    3;172,171,170;,
    3;173,171,172;,
    3;174,173,172;,
    3;175,173,174;,
    3;176,175,174;,
    3;177,175,176;,
    3;178,177,176;,
    3;179,177,178;,
    3;182,181,180;,
    3;183,181,182;,
    3;185,182,184;,
    3;183,182,185;,
    3;187,184,186;,
    3;185,184,187;,
    3;189,186,188;,
    3;187,186,189;,
    3;191,188,190;,
    3;189,188,191;,
    3;180,193,192;,
    3;181,193,180;,
    3;183,194,181;,
    3;195,194,183;,
    3;196,183,185;,
    3;195,183,196;,
    3;197,185,187;,
    3;196,185,197;,
    3;198,187,189;,
    3;197,187,198;,
    3;199,189,191;,
    3;198,189,199;,
    3;181,200,193;,
    3;194,200,181;,
    3;195,201,194;,
    3;202,201,195;,
    3;203,195,196;,
    3;202,195,203;,
    3;204,196,197;,
    3;203,196,204;,
    3;205,197,198;,
    3;204,197,205;,
    3;206,198,199;,
    3;205,198,206;,
    3;194,207,200;,
    3;201,207,194;,
    3;202,208,201;,
    3;209,208,202;,
    3;210,202,203;,
    3;209,202,210;,
    3;211,203,204;,
    3;210,203,211;,
    3;212,204,205;,
    3;211,204,212;,
    3;213,205,206;,
    3;212,205,213;,
    3;201,214,207;,
    3;208,214,201;,
    3;209,215,208;,
    3;216,215,209;,
    3;217,209,210;,
    3;216,209,217;,
    3;218,210,211;,
    3;217,210,218;,
    3;219,211,212;,
    3;218,211,219;,
    3;220,212,213;,
    3;219,212,220;,
    3;208,221,214;,
    3;215,221,208;,
    3;216,222,215;,
    3;223,222,216;,
    3;224,216,217;,
    3;223,216,224;,
    3;225,217,218;,
    3;224,217,225;,
    3;226,218,219;,
    3;225,218,226;,
    3;227,219,220;,
    3;226,219,227;,
    3;215,228,221;,
    3;222,228,215;,
    3;223,229,222;,
    3;230,229,223;,
    3;231,223,224;,
    3;230,223,231;,
    3;232,224,225;,
    3;231,224,232;,
    3;233,225,226;,
    3;232,225,233;,
    3;234,226,227;,
    3;233,226,234;,
    3;222,235,228;,
    3;229,235,222;,
    3;230,236,229;,
    3;237,230,231;,
    3;238,231,232;,
    3;239,232,233;,
    3;240,233,234;,
    3;229,241,235;;
    
  }
  MeshTextureCoords {
    242;
    // Treedemo
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.0;2.0;,
    -1.0;2.0;,
    0.0;1.78;,
    -1.0;1.78;,
    0.0;1.562;,
    -1.0;1.562;,
    0.0;1.336;,
    -1.0;1.336;,
    0.0;1.0;,
    -1.0;1.0;,
    0.215;-1.936;,
    0.215;-1.569;,
    0.431;-1.936;,
    0.431;-1.569;,
    0.646;-1.936;,
    0.646;-1.569;,
    0.862;-1.936;,
    0.862;-1.569;,
    1.077;-1.936;,
    1.077;-1.569;,
    1.292;-1.936;,
    1.292;-1.569;,
    0.0;-1.936;,
    0.0;-1.569;,
    0.215;-1.202;,
    0.431;-1.202;,
    0.646;-1.202;,
    0.862;-1.202;,
    1.077;-1.202;,
    1.292;-1.202;,
    0.0;-1.202;,
    0.215;-0.835;,
    0.431;-0.835;,
    0.646;-0.835;,
    0.862;-0.835;,
    1.077;-0.835;,
    1.292;-0.835;,
    0.0;-0.835;,
    0.215;-0.468;,
    0.431;-0.468;,
    0.646;-0.468;,
    0.862;-0.468;,
    1.077;-0.468;,
    1.292;-0.468;,
    0.0;-0.468;,
    0.215;-0.101;,
    0.431;-0.101;,
    0.646;-0.101;,
    0.862;-0.101;,
    1.077;-0.101;,
    1.292;-0.101;,
    0.0;-0.101;,
    0.215;0.266;,
    0.431;0.266;,
    0.646;0.266;,
    0.862;0.266;,
    1.077;0.266;,
    1.292;0.266;,
    0.0;0.266;,
    0.215;0.633;,
    0.431;0.633;,
    0.646;0.633;,
    0.862;0.633;,
    1.077;0.633;,
    1.292;0.633;,
    0.0;0.633;,
    0.215;1.0;,
    0.646;1.0;,
    0.862;1.0;,
    1.077;1.0;,
    1.292;1.0;,
    0.0;1.0;;
  }
  MeshMaterialList {
    7;
    234;
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1;
    
    Material C4DMAT_NONE {
      1.0;1.0;1.0;1.0;;
      1.0;
      0.0;0.0;0.0;;
      0.0;0.0;0.0;;
    }
    Material C4DMAT_TreeDemo_Trunk {
      1.0;1.0;1.0;1.0;;
      1.0;
      0.0;0.0;0.0;;
      0.098;0.098;0.098;;
      TextureFilename {
        "BarkDemo.jpg";
      }
    }
    
    Material C4DMAT_TreeDemo_Leaf {
      1.0;1.0;1.0;1.0;;
      1.0;
      0.0;0.0;0.0;;
      0.25;0.25;0.25;;
      TextureFilename {
        "TreeDemo.jpg";
      }
    }
    
    Material C4DMAT_Traffic_cone02 {
      0.973;0.973;0.973;1.0;;
      1.0;
      0.0;0.0;0.0;;
      0.0;0.0;0.0;;
    }
    
    Material C4DMAT_Traffic_cone01 {
      0.98;0.4;0.012;1.0;;
      1.0;
      0.0;0.0;0.0;;
      0.0;0.0;0.0;;
    }
    
    Material C4DMAT_Baum-Rinde-Berg-Ahorn {
      1.0;1.0;1.0;1.0;;
      1.0;
      0.068;0.068;0.068;;
      0.0;0.0;0.0;;
      TextureFilename {
        "Baum-Rinde-Berg-Ahorn.ppm";
      }
    }
    
    Material C4DMAT_Blaetter-Ahorn-Sommer {
      1.0;1.0;1.0;1.0;;
      1.0;
      0.0;0.0;0.0;;
      0.0;0.0;0.0;;
      TextureFilename {
        "Blaetter-Ahorn-Sommer.ppm";
      }
    }
    
    {C4DMAT_TreeDemo_Trunk}
  }
}