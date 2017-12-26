using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTri_2_1 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            World_2.instance.ShowRealWorld();
        }
    }

    public void SwitchState(World_2.WorldState world)
    {
        switch (world)
        {
            case World_2.WorldState.VIRTUAL:
                break;
            case World_2.WorldState.REAL:
                break;
        }
    }
}