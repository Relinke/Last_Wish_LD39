using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTri_3_1 : MonoBehaviour
{
    public Sprite virtualSprite;
    public Sprite RealSprite;

    public SpriteRenderer spriteRenderer;

    private float _timer = 0f;

    void Awake()
    {
    }

    void Update()
    {
        _timer += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            _timer = 0f;
            World_3.instance.ShowRealWorld();
        }
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            if (_timer >= World_3.instance.showVirtualTime + 
                World_3.instance.showRealTime)
            {
                _timer = 0f;
                World_3.instance.ShowRealWorld();
            }
        }
    }

    public void SwitchState(World_3.WorldState world)
    {
        if (!spriteRenderer)
        {
            return;
        }
        switch (world)
        {
            case World_3.WorldState.VIRTUAL:
                spriteRenderer.sprite = virtualSprite;
                break;
            case World_3.WorldState.REAL:
                spriteRenderer.sprite = RealSprite;
                break;
        }
    }
}