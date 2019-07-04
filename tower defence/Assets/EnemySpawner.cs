using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float laikasTarpSpawn = 2f;
    [SerializeField] GameObject enemyPrefab;
 
    

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(SpawnEnemie());
    }

    IEnumerator SpawnEnemie()
    {
        while (true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(laikasTarpSpawn); 
        }
    }



    
}
