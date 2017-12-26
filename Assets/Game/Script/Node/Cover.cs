using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour
{
    private enum CoverState
    {
        SHOW_COVER,
        SHOWING_COVER,
        ENTER_GAME
    }

    private Animator _animator;
    private CoverState _coverState = CoverState.SHOW_COVER;
    private event EventManager.EventBase enterGame;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        enterGame += EventManager.instance.OnNotify;
    }

    private void Update()
    {
        switch (_coverState)
        {
            case CoverState.SHOW_COVER:
                break;
            case CoverState.SHOWING_COVER:
                ShowingCoverUpdate();
                break;
            case CoverState.ENTER_GAME:
                break;
        }
    }

    private void ShowingCoverUpdate()
    {
        if (Input.anyKeyDown)
        {
            if (enterGame != null)
            {
                enterGame(gameObject, EventManager.EventType.START_GAME);
                _animator.SetTrigger("EnterGame");
                GoNextState();
            }
        }
    }

    private void GoNextState()
    {
        ++_coverState;
    }
}