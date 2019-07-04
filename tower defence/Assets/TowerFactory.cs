using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower raketa;
    [SerializeField] int RaketuNumeris = 5;
    public int esamasKiekis;
    //public WayPoint basePoint;
    Queue<Tower> towerQueue = new Queue<Tower>();
    

    public void AddTower(WayPoint basePoint) //*
    {
        //var raketos = GameObject.FindGameObjectsWithTag("raketa");
        esamasKiekis = towerQueue.Count;
        if (esamasKiekis < RaketuNumeris)
        {
            SukurtiNauja(basePoint);

        }
        else
        {
            PajudintiEsama(basePoint);
        }
    }

    private void SukurtiNauja(WayPoint basePoint)
    {
        var newTower = Instantiate(raketa, basePoint.transform.position, Quaternion.identity);
        basePoint.Pastatomas = false;
        newTower.basePoint = basePoint;
        basePoint.Pastatomas = false;
        towerQueue.Enqueue(newTower);
    }

    private void PajudintiEsama(WayPoint basePoint)
    {
        print("jau duagiau nei 5 bokstai");
        var oldTower = towerQueue.Dequeue();
        oldTower.basePoint.Pastatomas = true;
        basePoint.Pastatomas = false;
        oldTower.basePoint = basePoint;
        oldTower.transform.position = basePoint.transform.position;
        towerQueue.Enqueue(oldTower);
    }
}
