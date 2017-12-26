using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBeat : MonoBehaviour
{
    public Image heartBeat1;
    public Image heartBeat2;
    public Image heartBeatBG;
    public Image wholeBG;


    public float hideTime = 1.5f;

    public float moveSpeed = 1920f;

    public Hero Hero;

    public Animator Animator;

    private float _timer;
    private bool _hide = false;
    void Awake()
    {
        if (!Hero)
        {
            Hero = FindObjectOfType<Hero>();
        }
        Hero.enabled = false;
    }

	// Update is called once per frame
	void Update ()
	{
	    MoveUpdate();
	    if (_timer >= 1.5f)
	    {
            Animator.enabled = false;
            if (Input.anyKeyDown)
	        {
	            _hide = true;
	        }
	    }

	    if (_hide)
	    {
	        Color color = heartBeat1.color;
	        if (color.a > 0)
	        {
                color.a -= Time.deltaTime / hideTime;
            }
	            
	        if (color.a <= 0.5f)
	        {
                Hero.enabled = true;
            }
	        if (color.a <= 0)
	        {
	            AudioManager.instance.ChangeVolume(1);

                AudioManager.instance.Play(AudioManager.AudioType.SILENT_ROOM);
	            _hide = false;
                Destroy(gameObject);
                return;
	        }

	        heartBeat1.color = color;
            heartBeat2.color = color;
            heartBeatBG.color = color;
	        Color bgColor = wholeBG.color;
	        bgColor.a = color.a;
            AudioManager.instance.ChangeVolume(color.a);
            wholeBG.color = bgColor;
	    }
	    else
	    {
            _timer += Time.deltaTime;
        }
	   
	}

    void MoveUpdate()
    {
        heartBeat1.rectTransform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        heartBeat2.rectTransform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        if (heartBeat1.rectTransform.localPosition.x >= 1920)
        {
            heartBeat1.rectTransform.localPosition = new Vector3(-1920, 0, 0);
        }
        if (heartBeat2.rectTransform.localPosition.x >= 1920)
        {
            heartBeat2.rectTransform.localPosition = new Vector3(-1920, 0, 0);
        }
    }
}
