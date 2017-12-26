using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_1 : MonoBehaviour
{
    public CameraFilterPack_TV_CompressionFX CompressionFx;
    [SerializeField] private List<Collider2D> _backCollider2Ds;
    [SerializeField] private List<Collider2D> _frontCollider2Ds;

    private float _timer;
    private float _interval;

    private bool _isInRoom = false;

    void Awake()
    {
        if (!CompressionFx)
        {
            CompressionFx =
                FindObjectOfType<CameraFilterPack_TV_CompressionFX>();
        }
        CompressionFx.enabled = false;
        _interval = Random.Range(1, 5);
    }

    void Update()
    {
        if (!_isInRoom)
        {
            return;
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
}