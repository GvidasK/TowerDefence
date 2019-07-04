using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    //[SerializeField] List<WayPoint> path;
    
    // Use this for initialization
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));

        //StartCoroutine(followPath());
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator FollowPath(List<WayPoint>path)
    {
        print("pradedu");
        foreach (WayPoint wayPoint in path) 
        {
            transform.position = wayPoint.transform.position;
            //print(wayPoint);
            yield return new WaitForSeconds(2f);
        }
        print("baigta");
    }

}
