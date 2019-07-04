using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform MainPart;
    //[SerializeField] Transform EnemyToLookAt;
    [SerializeField] Transform bokstoDistancija;
    [SerializeField] Transform enemyDistancija;
    [SerializeField] ParticleSystem kulkos;
    public WayPoint basePoint;
    float distance;

     Transform EnemyToLookAt;

    // Update is called once per frame
    void Update ()
    {
        SetTargetEnemy();
        if (EnemyToLookAt)
        {
            MainPart.LookAt(EnemyToLookAt);
            Distancija();
            if (distance <= 30f)
            {
                saudymas(true);
            }
            else
            {
                saudymas(false);
            }
        }
        else
        {
            saudymas(false);
        }

    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }
        Transform artimiausias = sceneEnemies[0].transform;
        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            artimiausias = GautiArtimiausia(artimiausias, testEnemy.transform);
        }
        EnemyToLookAt = artimiausias;
    }

    private Transform GautiArtimiausia(Transform EnemyA, Transform EnemyB)
    {
        var aDistancija = Vector3.Distance(transform.position, EnemyA.position);
        var bDistancija = Vector3.Distance(transform.position, EnemyB.position);
        if (aDistancija < bDistancija)
        {
            return EnemyA;
        }
        return EnemyB;
    }
    
    public void Distancija()
    {
        distance = Vector3.Distance(bokstoDistancija.transform.position, enemyDistancija.transform.position);
        //print(distance);
    }
    void saudymas(bool veikia)
    {
        //var kulkkuParticles = kulkos;
        kulkos.enableEmission = veikia;
    }
}
