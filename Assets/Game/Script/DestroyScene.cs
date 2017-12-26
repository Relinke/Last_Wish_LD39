using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScene : MonoBehaviour
{
    public List<GameObject> DestroyObjects;


    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            transform.parent = null;
            for (int i = 0; i < DestroyObjects.Count; i++)
            {
                Destroy(DestroyObjects[i]);
            }
        }
    }
}
