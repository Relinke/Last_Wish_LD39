using UnityEngine;

public class WorldTri_3_2 : MonoBehaviour
{
    public CameraFilterPack_TV_CompressionFX CompressionFx;

    public Vector2 offSet = new Vector2(-7.53f, 2.2f);

    public Hero hero;

    public bool showCompressionFx = false;
    public bool showEnd = false;
    private bool enteringEnd = false;

    public Animator animator;

    public World_3 World3;
    public World_4 World4;

    public Color color = Color.white;

    void Update()
    {
        if (!enteringEnd)
        {
            return;
        }
        CompressionFx.enabled = showCompressionFx;
        if (showEnd)
        {
            World3.gameObject.SetActive(false);
            World4.gameObject.SetActive(true);
        }
        else
        {
            World3.gameObject.SetActive(true);
            World4.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            ShowEnd();
        }
    }

    void ShowEnd()
    {
        FindObjectOfType<Camera>().backgroundColor = color;
        enteringEnd = true;
        World3 = World_3.instance;
        World4 = World_4.instance;
        transform.parent = null;
        hero = Hero.instance;
        hero._Rigidbody2D.bodyType = RigidbodyType2D.Static;
        CompressionFx.Parasite = 10;
        hero.enabled = false;
        World_4.instance.transform.position = transform.position
            + (Vector3)offSet;
        animator.Play("ShowEnd");
    }

    public void EnterEnd()
    {
        CompressionFx.Parasite = 1;
        hero._Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        hero.enabled = true;
        World3.gameObject.SetActive(false);
        World4.gameObject.SetActive(true);
        AudioManager.instance.Play(AudioManager.AudioType.HEART_BEAT);
        Destroy(gameObject);
    }
}