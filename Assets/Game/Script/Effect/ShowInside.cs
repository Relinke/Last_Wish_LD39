using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInside : MonoBehaviour
{
    #region Show In Inspector
    [SerializeField]
    private SpriteRenderer _outsideSR;
    [SerializeField]
    private SpriteRenderer _insideSR;
    [SerializeField]
    private float _gradientTime = 1f;
    #endregion

    #region Hide In Inspector
    private bool _showing = false;
    #endregion

    #region Init Part

    protected void Awake()
    {
        
    }

    protected void Init()
    {
        
    }

    #endregion

    #region Update Part

    protected void Update()
    {
        ShowUpdate();
    }

    private void ShowUpdate()
    {
        Color color = _outsideSR.color;
        if (_showing)
        {
            if (color.a >= 0)
            {
                color.a -= Time.deltaTime / _gradientTime;
            }
        }
        else
        {
            if (color.a <= 1)
            {
                color.a += Time.deltaTime / _gradientTime;
            }
        }
        _outsideSR.color = color;
    }

    #endregion

    #region Collision Part

    protected void OnTriggerEnter2D(Collider2D collider2D)
    {
        CheckShowInside(collider2D, true);
    }

    protected void OnTriggerStay2D(Collider2D collider2D)
    {
       
    }

    protected void OnTriggerExit2D(Collider2D collider2D)
    {
        CheckShowInside(collider2D, false);
    }

    #endregion

    #region Function Part

    private void CheckShowInside(Collider2D collider2D, bool isShow)
    {

        if (collider2D.CompareTag("Player"))
        {
            _showing = isShow;
        }
        else
        {
            Debug.Log(collider2D.tag + " is not Player");
        }
    }
    #endregion
   
}