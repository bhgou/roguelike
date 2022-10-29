using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEnemys : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

    }
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
}
