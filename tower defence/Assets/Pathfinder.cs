using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();
    [SerializeField] WayPoint start;
    [SerializeField] WayPoint end;
    bool buvo = false;
    WayPoint searchCenter;
    List<WayPoint> path = new List<WayPoint>();
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };
    public List <WayPoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            PathFind();
            sukurtKelia();
            //sukurtKelia();          
            //AplankytKaimynus();
        }

        return path;
    }
    bool veikia = true;
    // Use this for initialization
   

    private void sukurtKelia()
    {
        SetAsPath(end);                             
        WayPoint priesTaiBuvesKubas = end.istirtasIs;
        while (priesTaiBuvesKubas != start)
        {
            path.Add(priesTaiBuvesKubas);
            priesTaiBuvesKubas.Pastatomas = false;
            priesTaiBuvesKubas = priesTaiBuvesKubas.istirtasIs;
        }
        path.Add(start);
        start.Pastatomas = false;
        path.Reverse();

        //buvo = true;
        //if (buvo == true)
        //{ path.Reverse(); }



    }

    private void SetAsPath(WayPoint wayPoint)
    {
        path.Add(wayPoint);
        wayPoint.Pastatomas = false;
    }

    private void AplankytKaimynus()
    {
        if (!veikia) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int lankymas = searchCenter.GetGridPos() + direction;   
            if (grid.ContainsKey(lankymas)) 
            {
                naujuKaimynuEile(lankymas);
            }
           
        }
    }

    private void naujuKaimynuEile(Vector2Int lankymas)
    {
        WayPoint kaimynas = grid[lankymas];
        if (kaimynas.istirtas || queue.Contains(kaimynas))
        {

        }
        else
        {
            if (kaimynas != end)
            { kaimynas.SetTopColor(Color.blue); }
            
            queue.Enqueue(kaimynas);
            kaimynas.istirtasIs = searchCenter;
            //print("eilinamas " + kaimynas);
        }
    }

    void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<WayPoint>();
        foreach (WayPoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            bool Overlappina = grid.ContainsKey(gridPos);
            if (Overlappina)
            {
                Debug.LogWarning("Overlappina" + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
                waypoint.SetTopColor(Color.black);
                start.SetTopColor(Color.green);
                end.SetTopColor(Color.red);
                //start.SetTopColor(Color.green);
                //end.SetTopColor(Color.red);
                //waypoint.Stop(Color.red);
                //waypoint.SetBackColor(Color.red);
            }
            
        }
        print(grid.Count);
            
    }
    public void PathFind()
    {
        queue.Enqueue(start);
        while (queue.Count > 0 && veikia)
        {
            searchCenter = queue.Dequeue();
            //print("ieskoma is " + searchCenter);
            if (searchCenter == end)
            {
                veikia = false;
                print("sutampa pradzios ir galutuinis taskai");
            }
            AplankytKaimynus();
            searchCenter.istirtas = true;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        //AplankytKaimynus();
    }
}
