using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;

public class World_3 : MonoBehaviour {
    public static World_3 instance;
    #region World

    public CameraFilterPack_TV_CompressionFX CompressionFx;
    [SerializeField]
    private List<Collider2D> _backCollider2Ds;
    [SerializeField]
    private List<Collider2D> _frontCollider2Ds;

    private float _timer;
    private float _interval;

    private bool _isInRoom = false;
    [SerializeField]
    public Vector2 offSet;

    void Awake()
    {
        instance = this;
        if (!CompressionFx)
        {
            CompressionFx =
                FindObjectOfType<CameraFilterPack_TV_CompressionFX>();
        }
        CompressionFx.enabled = false;
        _interval = Random.Range(1, 5);

        switch (_worldState)
        {
            case WorldState.VIRTUAL:
                HideRealWorld();
                break;
            case WorldState.REAL:
                ShowRealWorld();
                break;
        }
        if (!_hero)
        {
            _hero = FindObjectOfType<Hero>();
        }
    }

    void Update()
    {
        if (!_isInRoom)
        {
            return;
        }

        switch (_worldState)
        {
            case WorldState.VIRTUAL:
                VirtualUpdate();
                break;
            case WorldState.REAL:
                RealUpdate();
                break;
        }

        _timer += Time.deltaTime;
    }

    public void EnterRoom()
    {
        _isInRoom = true;
        ProCamera2D.Instance.OverallOffset = offSet;
        EnableStop();
    }

    public void LeaveRoom()
    {
        _isInRoom = false;
        DisableStop();
        CompressionFx.enabled = false;
        _timer = 0f;
        _interval = Random.Range(1, 5);
    }

    private void EnableStop()
    {
        for (int i = 0; i < _backCollider2Ds.Count; i++)
        {
            _backCollider2Ds[i].enabled = true;
        }
        for (int i = 0; i < _frontCollider2Ds.Count; i++)
        {
            _frontCollider2Ds[i].enabled = false;
        }
    }

    private void DisableStop()
    {
        for (int i = 0; i < _backCollider2Ds.Count; i++)
        {
            _backCollider2Ds[i].enabled = false;
        }
        for (int i = 0; i < _frontCollider2Ds.Count; i++)
        {
            _frontCollider2Ds[i].enabled = true;
        }
    }

    #endregion

    #region Virtual 

    //进入real之后把新的Virtual也解锁
    public enum WorldState
    {
        VIRTUAL,
        REAL,
    }

    #region Show In Inspector

    [SerializeField]
    private GameObject _virtual;
    [SerializeField]
    private GameObject _real;
    
    public float showRealTime = 3f;
    
    public float showVirtualTime = 3f;
    [SerializeField]
    private float _blinkDistance = 3;
    
   

    [Range(1f, 127f)]
    public float _maxParasite = 9f;

    public List<WorldTri_3_1> WorldTri31S;

    public GameObject first_Virtual;
    public GameObject once_Real_Virtual;
    #endregion

    #region Hide In Inspector
    [HideInInspector]
    public WorldState _worldState = WorldState.VIRTUAL;

    private float _virtualTimer;
    private Hero _hero;
    #endregion

    #region Update Part

    private void VirtualUpdate()
    {
        CheckDis();
    }

    private void CheckDis()
    {
        float minDis = 9999;
        for (int i = 0; i < WorldTri31S.Count; i++)
        {
            float dis = Vector2.Distance(WorldTri31S[i].transform.position,
                _hero.transform.position);
            if (dis < minDis)
            {
                minDis = dis;
            }
        }
        if (minDis <= _blinkDistance)
        {
            CompressionFx.enabled = true;
            CompressionFx.Parasite =
                1 + _maxParasite * (_blinkDistance - minDis) / _blinkDistance;
        }
        else
        {
            CompressionFx.enabled = false;
        }
    }

    private void RealUpdate()
    {
        if (_timer >= _interval + 0.5f)
        {
            CompressionFx.enabled = false;
            _timer = 0f;
            _interval = Random.Range(1, 5);
        }
        else if (_timer >= _interval)
        {
            CompressionFx.enabled = true;
        }

        if (_virtualTimer >= showRealTime)
        {
            HideRealWorld();
        }
        _virtualTimer += Time.deltaTime;
    }

    #endregion

    #region Function Part

    public void ShowRealWorld()
    {
        SwitchState(WorldState.REAL);
        first_Virtual.SetActive(false);
        once_Real_Virtual.SetActive(true);
        CompressionFx.Parasite = 1;
        _real.SetActive(true);
        _virtual.SetActive(false);
    }

    public void HideRealWorld()
    {
        SwitchState(WorldState.VIRTUAL);
        _real.SetActive(false);
        _virtual.SetActive(true);
    }

    private void SwitchState(WorldState worldState)
    {
        _virtualTimer = 0f;
        _worldState = worldState;
        switch (_worldState)
        {
            case WorldState.VIRTUAL:
                break;
            case WorldState.REAL:
                break;
        }
        for (int i = 0; i < WorldTri31S.Count; i++)
        {
            WorldTri31S[i].SwitchState(_worldState);
        }
    }

    #endregion
    #endregion
}
