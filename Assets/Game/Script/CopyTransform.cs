using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyTransform : MonoBehaviour
{
    public Transform Transform;

    private void Update()
    {
        Transform.position = transform.position;
    }
}