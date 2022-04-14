Shader "Slime/Step3"
{
    Properties{}
        SubShader
    {
        Tags
        {
            "Queue" = "Transparent" // ���߂ł���悤�ɂ���
        }

        Pass
        {
            ZWrite On // �[�x����������
            Blend SrcAlpha OneMinusSrcAlpha // ���߂ł���悤�ɂ���

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

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

    // ���̋����֐�
    float4 sphereDistanceFunction(float4 sphere, float3 pos)
    {
        return length(sphere.xyz - pos) - sphere.w;
    }

    // �[�x�v�Z
    inline float getDepth(float3 pos)
    {
        const float4 vpPos = mul(UNITY_MATRIX_VP, float4(pos, 1.0));

        float z = vpPos.z / vpPos.w;
        #if defined(SHADER_API_GLCORE) || \
                    defined(SHADER_API_OPENGL) || \
                    defined(SHADER_API_GLES) || \
                    defined(SHADER_API_GLES3)
                return z * 0.5 + 0.5;
                #else
                return z;
                #endif
            }

 #define MAX_SPHERE_COUNT 256 // �ő�̋��̌�
 float4 _Spheres[MAX_SPHERE_COUNT]; // ���̍��W�E���a���i�[�����z��
int _SphereCount; // �������鋅�̌�

           // �����ꂩ�̋��Ƃ̍ŒZ������Ԃ�
float getDistance(float3 pos)
 {
float dist = 100000;
for (int i = 0; i < _SphereCount; i++)
 {
dist = min(dist, sphereDistanceFunction(_Spheres[i], pos));
}
 return dist;
}



// v2f -> �o��
output frag(const v2f i)
{
    output o;

    float3 pos = i.pos.xyz; // ���C�̍��W�i�s�N�Z���̃��[���h���W�ŏ������j
    const float3 rayDir = normalize(pos.xyz - _WorldSpaceCameraPos); // ���C�̐i�s����

    

    for (int i = 0; i < 30; i++)
    {
        // pos�Ƃ����ꂩ�̋��Ƃ̍ŒZ����
        float dist = getDistance(pos);

        // ������0.001�ȉ��ɂȂ�����A�F�Ɛ[�x����������ŏ����I��
        if (dist < 0.001)
        {
            o.col = fixed4(0, 1, 0, 0.5); // �h��Ԃ�
            o.depth = getDepth(pos); // �[�x��������
            return o;
        }

        // ���C�̕����ɍs�i
        pos += dist * rayDir;
    }

    // �Փ˔��肪�Ȃ������瓧���ɂ���
    o.col = 0;
    o.depth = 0;
    return o;
}
            ENDCG
        }
    }
}