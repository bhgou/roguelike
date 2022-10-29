using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    public bool CameraFollow = true;
    
    private void Update()
    {
        if (CameraFollow)
        {
            transform.position = player.position;
        }
            
    }
}
