using UnityEngine;

[ExecuteAlways] // �Đ����Ă��Ȃ��Ԃ����W�Ɣ��a���ω�����悤��
public class SlimeRender : MonoBehaviour
{
    [SerializeField] private Material material; // �X���C���p�̃}�e���A��

    private const int MaxSphereCount = 256; // ���̍ő���i�V�F�[�_�[���ƍ��킹��j
    private readonly Vector4[] _spheres = new Vector4[MaxSphereCount];
    private SphereCollider[] _colliders;
    private Vector4[] _colors = new Vector4[MaxSphereCount];
    private readonly float[] _spheres_state = new float[MaxSphereCount];
    private readonly float[] _alpha = new float[MaxSphereCount];

    private void Start()
    {
        // �q��SphereCollider�����ׂĎ擾
        _colliders = GetComponentsInChildren<SphereCollider>();

        // �V�F�[�_�[���� _SphereCount ���X�V
        material.SetInt("_SphereCount", _colliders.Length);

        // �����_���ȐF��z��Ɋi�[
               for (var i = 0; i < _colors.Length; i++)
                   {
            _colors[i] = (Vector4)Random.ColorHSV(0, 1, 1, 1, 1, 1);
                   }

               // �V�F�[�_�[���� _Colors ���X�V
        material.SetVectorArray("_Colors", _colors);
    }

    private void Update()
    {
        // �q��SphereCollider�����ׂĎ擾
        _colliders = GetComponentsInChildren<SphereCollider>();
        

        // �q��SphereCollider�̕������A_spheres �ɒ��S���W�Ɣ��a�����Ă���
        for (var i = 0; i < _colliders.Length; i++)
        {
            var col = _colliders[i];
            var t = col.transform;
            var center = t.position;
            var radius = t.lossyScale.x * col.radius;
            // ���S���W�Ɣ��a���i�[
            _spheres[i] = new Vector4(center.x, center.y, center.z, radius);

            //_spheres_state[i] = 1;
            int _state = (int)col.gameObject.GetComponent<SlimeContoroller>().m_state;

            if (_state == 0)
            {
                //_colors[i] = new Vector4(1, 1, 1, 1); 
            }
            else if (_state == 1)
            {
                _colors[i] = new Vector4(0, 0, 1, 0);
            }
        }

        // �V�F�[�_�[���� _Spheres ���X�V
        material.SetVectorArray("_Spheres", _spheres);
        material.SetVectorArray("_Colors", _colors);
        material.SetFloatArray("_SphereState", _spheres_state);

        //Debug.Log(material.GetInt("_SphereState2"));
        
    }
}
