Shader "Slime/Step0"
{
    Properties
    {
        //_MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { 
            "Queue" = "Transparent" // ���߂ł���悤�ɂ���
        }
        LOD 100

        Pass
        {
             ZWrite On // �[�x����������
            Blend SrcAlpha OneMinusSrcAlpha // ���߂ł���悤�ɂ���

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
        // ���̓f�[�^�p�̍\����
            struct input
            {
                float4 vertex : POSITION; // ���_���W
            };

    // vert�Ōv�Z����frag�ɓn���p�̍\����
    struct v2f
    {
        float4 pos : POSITION1; // �s�N�Z�����[���h���W
        float4 vertex : SV_POSITION; // ���_���W
    };

    // �o�̓f�[�^�p�̍\����
    struct output
    {
        float4 col: SV_Target; // �s�N�Z���F
        float depth : SV_Depth; // �[�x
    };

    // ���� -> v2f
    v2f vert(const input v)
    {
        v2f o;
        o.vertex = UnityObjectToClipPos(v.vertex);
        o.pos = mul(unity_ObjectToWorld, v.vertex); // ���[�J�����W�����[���h���W�ɕϊ�
        return o;
    }

    // v2f -> �o��
    output frag(const v2f i)
    {
        output o;
        o.col = fixed4(i.pos.xyz, 0.5);
        o.depth = 1;
        return o;
    }
    ENDCG
        }
    }
}
