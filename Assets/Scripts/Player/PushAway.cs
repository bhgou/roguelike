
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAway : MonoBehaviour
{
    [SerializeField] private float pushPower;
    [SerializeField] private int direction;

    public float bushTime;

    private void Update()
    {
        if (MovePlayer.Instance.FacingRight)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        for (int i = 0; i < Weapon.Instance.Enemy.Count; i++)
        {
            if (Weapon.Instance.Enemy[i].GetComponent<Rigidbody2D>() == null) return;
        }
     
        if (Input.GetMouseButtonDown(0)){
            StartCoroutine(Push());
        }
       
    }
    IEnumerator Push()
    {
        Weapon.Instance.LastEnemy.bush = true;
        Weapon.Instance.LastEnemy.GetComponent<Rigidbody2D>().AddForce(Vector2.left * pushPower * direction, ForceMode2D.Impulse);
        yield return new WaitForSeconds(bushTime);
        Weapon.Instance.LastEnemy.bush = false;
        
    }
 
}
