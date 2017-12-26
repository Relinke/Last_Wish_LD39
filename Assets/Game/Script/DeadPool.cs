using UnityEngine;

public class DeadPool : MonoBehaviour
{
    public Vector3 spawnPos;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            collider2D.transform.position = spawnPos;
        }
    }
}