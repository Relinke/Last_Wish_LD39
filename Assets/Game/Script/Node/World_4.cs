using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_4 : MonoBehaviour
{
    public static World_4 instance;

    public CameraFilterPack_TV_CompressionFX CompressionFx;
    public Animator Animator;

    public Animator UiAnimator;
    public Animator CharacterAnimator;

    private bool isEnd = false;

    public bool showFx;
    public float fxValue;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (!isEnd)
        {
            return;
        }

        CompressionFx.enabled = showFx;
        CompressionFx.Parasite = fxValue;
    }

    public void End()
    {
        isEnd = true;
        Hero.instance._Rigidbody2D.bodyType = RigidbodyType2D.Static;
        Hero.instance.enabled = false;
        Animator.Play("End");
    }

    public void DestroyHero()
    {
        CharacterAnimator.Play("Disappear");
    }

    public void PlayStaff()
    {
        UiAnimator.enabled = true;
        UiAnimator.Play("Staff");
    }
}