using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMesh : MonoBehaviour
{

    // �������ٶ�
    [SerializeField]
    private Vector3 G = new Vector3(0.0f, 0.0f, 9.8f);
    //���ʱ��
    [SerializeField]
    private float _FixedTime = 0.05f;

    // �ٶ�  ��֤�ٶȾ��ȣ�·��Խ��ʱ��Խ��
    [SerializeField]
    private float _Speed = 10;
    public float Speed
    {
        set
        {
            _Speed = value;
        }
        get
        {
            return _Speed;
        }
    }
    //��ͷ�Ŀ��
    [SerializeField]
    private float _ArrowWidth = 2.0f;

    private MeshFilter _MeshFilter;

    // private Vector3 _StartPos;
#if UNITY_EDITOR
    private void OnValidate()
    {
    }
#endif

    private void Start()
    {
        _MeshFilter = GetComponent<MeshFilter>();
    }

    public void UpdatePosition(Vector3 _endPos)
    {
        if (!_MeshFilter)
            _MeshFilter = GetComponent<MeshFilter>();
        List<Vector3> _pos = GetRadianPos(Vector3.zero, _endPos);
        CreateMesh(_MeshFilter, _pos);
    }

    #region ����ģ��
    void CreateMesh(MeshFilter _meshFilter, List<Vector3> _pos)
    {
        int _num = _pos.Count - 1;
        if (_num < 1)
            return;
        float _halfWidth = _ArrowWidth * 0.5f;
        Vector3 _dir = GetDir(_pos[0], _pos[_num]);

        //Vector3[] _vertices = new Vector3[_num*4+8];
        //Vector2[] _uv = new Vector2[_num * 4 + 8];
        //int[] _triangle = new int[_num * 6 + 12];
        Vector3[] _vertices = new Vector3[_num * 4];
        Vector2[] _uv = new Vector2[_num * 4];
        int[] _triangle = new int[_num * 6];
        for (int i = 0; i < _num; i++)
        {
            //���㶥��λ��  
            _vertices[i * 4 + 0] = _pos[i] + _dir * _halfWidth;
            _vertices[i * 4 + 1] = _pos[i + 1] - _dir * _halfWidth;
            _vertices[i * 4 + 2] = _pos[i + 1] + _dir * _halfWidth;
            _vertices[i * 4 + 3] = _pos[i] - _dir * _halfWidth;

            //����uvλ��  
            _uv[i * 4 + 0] = new Vector2(0.0f, 0.0f);
            _uv[i * 4 + 1] = new Vector2(1.0f, 1.0f);
            _uv[i * 4 + 2] = new Vector2(1.0f, 0.0f);
            _uv[i * 4 + 3] = new Vector2(0.0f, 1.0f);
        }

        int _verticeIndex = 0;

        for (int i = 0; i < _num; i++)
        {
            // ��һ��������  
            _triangle[_verticeIndex++] = i * 4 + 0;
            _triangle[_verticeIndex++] = i * 4 + 1;
            _triangle[_verticeIndex++] = i * 4 + 2;
            // �ڶ���������  
            _triangle[_verticeIndex++] = i * 4 + 1;
            _triangle[_verticeIndex++] = i * 4 + 0;
            _triangle[_verticeIndex++] = i * 4 + 3;
        }
        Mesh _newMesh = new Mesh();
        _newMesh.vertices = _vertices;
        _newMesh.uv = _uv;
        _newMesh.triangles = _triangle;
#if UNITY_EDITOR
        _meshFilter.sharedMesh = _newMesh;
#else
        _meshFilter.mesh = _newMesh;  
#endif
    }
    #endregion

    #region ��ȡ��ͷ�Ĵ�ֱ����
    Vector3 GetDir(Vector3 _start, Vector3 _end)
    {
        Vector3 _dirValue = (_end - _start).normalized;
        //��Ϊ����Ҫ����z�����������һ�����������ɵó�Ψһ��ֱ����
        Vector2 _dir = new Vector2(Mathf.Abs(_dirValue.y), -1.0f * Mathf.Sign(_dirValue.x * _dirValue.y) * Mathf.Abs(_dirValue.x));
        if (_dirValue.y < 0)
            _dir *= -1.0f;
        return _dir;
    }
    #endregion

    #region ��ȡ����֮��ĵ�
    List<Vector3> GetRadianPos(Vector3 _startPos, Vector3 _endPos)
    {
        List<Vector3> _pos = new List<Vector3>();

        float _LifeTime = Vector3.Distance(_startPos, _endPos) / _Speed;

        // �����ƶ�:v=v0-gt;   v0=v+gt; v0=0;
        Vector3 _startSpeed = (_endPos - _startPos) / _LifeTime + G * (_LifeTime * 0.5f);
        for (float _moveTime = 0.0f; _moveTime <= _LifeTime; _moveTime += _FixedTime)
        {
            if (_moveTime > _LifeTime)
                _moveTime = _LifeTime;
            Vector3 _tmpPos = _startPos + (_startSpeed * _moveTime - 0.5f * G * _moveTime * _moveTime);
            _pos.Add(_tmpPos);
        }

        return _pos;
    }
    #endregion

}