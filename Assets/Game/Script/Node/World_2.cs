using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_2 : MonoBehaviour
{
    public static World_2 instance;
    #region World

    public CameraFilterPack_TV_CompressionFX CompressionFx;
    [SerializeField] private List<Collider2D> _backCollider2Ds;
    [SerializeField] private List<Collider2D> _frontCollider2Ds;

    private float _timer;
    private float _interval;

    private bool _isInRoom = false;


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


        if (!WorldTri21)
        {
            WorldTri21 = FindObjectOfType<WorldTri_2_1>();
        }
        if (!WorldTri22)
        {
            WorldTri22 = FindObjectOfType<WorldTri_2_2>();
        }
        if (!WorldTri23)
        {
            WorldTri23 = FindObjectOfType<WorldTri_2_3>();
        }
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

    public enum WorldState
    {
        VIRTUAL,
        REAL
    }

    #region Show In Inspector

    [SerializeField]
    private GameObject _virtual;
    [SerializeField]
    private GameObject _real;

    [SerializeField]
    private float _showRealTime = 5f;

    [SerializeField]
    private float _blinkDistance = 3;

    [SerializeField]
    private Hero _hero;

    [Range(1f, 127f)]
    public float _maxParasite = 9f;

    public WorldTri_2_1 WorldTri21;
    public WorldTri_2_2 WorldTri22;
    public WorldTri_2_3 WorldTri23;
    #endregion

    #region Hide In Inspector

    private WorldState _worldState = WorldState.VIRTUAL;

    private float _virtualTimer;

    #endregion

    #region Update Part

    private void VirtualUpdate()
    {
        CheckDis();
    }

    private void CheckDis()
    {
        float dis1 = 
            Vector2.Distance(WorldTri21.transform.position,
            _hero.transform.position);
        float dis2 =
            Vector2.Distance(WorldTri22.transform.position,
            _hero.transform.position);
        float dis3 =
            Vector2.Distance(WorldTri23.transform.position,
            _hero.transform.position);
        float minDis = dis1;
        if (minDis > dis2)
        {
            minDis = dis2;
        }
        if (minDis > dis3)
        {
            minDis = dis3;
        }
        if (minDis <= _blinkDistance)
        {
            CompressionFx.enabled = true;
            CompressionFx.Parasite =
                1 + _maxParasite*(_blinkDistance - minDis)/_blinkDistance;
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

        if (_virtualTimer >= _showRealTime)
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
        WorldTri21.SwitchState(_worldState);
        WorldTri22.SwitchState(_worldState);
        WorldTri23.SwitchState(_worldState);
    }

    #endregion
    #endregion
}