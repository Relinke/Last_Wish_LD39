using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBGManager : MonoBehaviour
{
    public static FallBGManager instance;
    
    #region Show In Inspector
    [SerializeField]
    private SpriteRenderer _backgroundSR;
    [SerializeField]
    private float _gradientTime = 1f;

    
    #endregion

    #region Hide In Inspector
    private bool _showing = false;
    [HideInInspector]
    public Hero hero;
    #endregion

    #region Init Part
    private void Awake()
    {
        instance = this;
    }

    #endregion

    #region Update Part

    protected void Update()
    {
        if (!_backgroundSR)
        {
            return;
        }
        ShowUpdate();
        FollowUpdate();
    }

    private void ShowUpdate()
    {
        Color color = _backgroundSR.color;
        if (_showing)
        {
            if (color.a > 0)
            {
                color.a -= Time.deltaTime / _gradientTime;
            }
        }
        else
        {
            if (color.a < 1)
            {
                color.a += Time.deltaTime / _gradientTime;
            }
        }
        _backgroundSR.color = color;
    }

    private void FollowUpdate()
    {
        if (_backgroundSR.color.a <= 0)
        {
            _backgroundSR.transform.position = hero.transform.position;
        }
    }

    #endregion

    #region Collision Part
    
    #endregion

    #region Function Part

    public void ShowBackground(bool isShow)
    {
        _showing = isShow;
    }
    #endregion
}