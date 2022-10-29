using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]private GameObject[] weapon;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(weapon[Random.Range(0,weapon.Length)],transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
