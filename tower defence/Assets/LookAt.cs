using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {
    [SerializeField] Transform enemy;
    private void Update()
    {
        Vector3 direction = enemy.position - transform.position;   
        Quaternion rotation = Quaternion.LookRotation(direction);   
        transform.rotation = rotation;                              
        
    }
}
