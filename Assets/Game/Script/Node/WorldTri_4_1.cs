using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTri_4_1 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        World_4.instance.End();
    }
}
