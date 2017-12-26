using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTri_2_3 : MonoBehaviour
{
    public Sprite bearVirtualSprite;
    public Sprite bearRealSprite;

    public SpriteRenderer BearSpriteRenderer;
    public Rigidbody2D BearRigidbody2D;

    private SpriteRenderer _spriteRenderer;
    

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (BearSpriteRenderer.sprite == bearRealSprite)
        {
            return;
        }
        if (collider2D.CompareTag("Player"))
        {
            World_2.instance.ShowRealWorld();
            BearRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void SwitchState(World_2.WorldState world)
    {
        switch (world)
        {
            case World_2.WorldState.VIRTUAL:
                BearSpriteRenderer.sprite = bearVirtualSprite;
                break;
            case World_2.WorldState.REAL:
                BearSpriteRenderer.sprite = bearRealSprite;
                break;
        }
    }
}
