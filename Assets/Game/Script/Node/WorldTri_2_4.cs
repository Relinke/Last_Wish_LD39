using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;

public class WorldTri_2_4 : MonoBehaviour
{
    public World_1 world1;
    public World_2 world2;
    public World_3 world3;

    private Collider2D _collider2D;

    private Hero hero;
    private bool _isFall = false;
    private float _timer = 0f;
    private ProCamera2DRooms proCamera2DRooms;
    private ProCamera2DNumericBoundaries numericBoundaries;

    void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        if (!world1)
        {
            world1 = FindObjectOfType<World_1>();
        }
        if (!world2)
        {
            world2 = FindObjectOfType<World_2>();
        }
        if (!world3)
        {
            world3 = FindObjectOfType<World_3>();
        }
    }


    void Update()
    {
        if (_isFall)
        {
            if (_timer <= 3)
            {
                AudioManager.instance.ChangeVolume( (3 - _timer) / 3);

            }
            if (_timer >= 3)
            {
                proCamera2DRooms = FindObjectOfType<ProCamera2DRooms>();
                numericBoundaries = FindObjectOfType<ProCamera2DNumericBoundaries>();

                proCamera2DRooms.enabled = false;
                numericBoundaries.enabled = false;
            }

            if (_timer >= 5)
            {
                hero.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Vector3 pos = hero.transform.position;
                pos.x += 10;
                pos.y -= 16;
                world3.transform.position = pos;
                _isFall = false;
                _timer = 0f;
                if (AudioManager.instance.GetVolume() < 1)
                {
                    AudioManager.instance.ChangeVolume(1);
                    AudioManager.instance.Play(AudioManager.AudioType.WINDMILL_IN_GARDEN);
                }
            }
            _timer += Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            transform.parent = null;
            _collider2D.enabled = false;
            hero = FindObjectOfType<Hero>();
            _isFall = true;
            
            world1.gameObject.SetActive(false);
            world2.gameObject.SetActive(false);
        }
    }
}