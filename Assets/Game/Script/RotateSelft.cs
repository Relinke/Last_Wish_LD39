using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelft : MonoBehaviour
{
    public float rotateSpeed = 30;

    public GameObject OthserSelft;

    void Update()
    {
        Vector3 angle = transform.eulerAngles;
        angle.z += rotateSpeed*Time.deltaTime;
        if (Mathf.Abs(angle.z) >= 720f)
        {
            angle.z = 0;
        }
        transform.eulerAngles = angle;

        OthserSelft.transform.eulerAngles = angle;
    }
}