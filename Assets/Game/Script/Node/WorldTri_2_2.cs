using UnityEngine;

public class WorldTri_2_2 : MonoBehaviour
{
    public Sprite virtualSprite;
    public Sprite RealSprite;

    public SpriteRenderer spriteRenderer;

    public Transform target;
    public Vector3 afterPosition;
    public Vector3 afterRotation;


    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (spriteRenderer.sprite == RealSprite)
        {
            return;
        }
        if (collider2D.CompareTag("Player"))
        {
            World_2.instance.ShowRealWorld();
            target.localPosition = afterPosition;
            target.localEulerAngles = afterRotation;
        }
    }

    public void SwitchState(World_2.WorldState world)
    {
        switch (world)
        {
            case World_2.WorldState.VIRTUAL:
                spriteRenderer.sprite = virtualSprite;
                break;
            case World_2.WorldState.REAL:
                spriteRenderer.sprite = RealSprite;
                break;
        }
    }
}
