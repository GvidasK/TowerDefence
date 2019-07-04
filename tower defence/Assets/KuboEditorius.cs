using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint))]
public class KuboEditorius : MonoBehaviour
{
    
    
    WayPoint waypoint;
    private void Awake()
    {
        waypoint = GetComponent<WayPoint>();
    }
    void Start()
    {
        //textMesh = GetComponentInChildren<TextMesh>();                    
        //textMesh.text = "testas";
    }
   


    void Update ()
    {
        GridoSnappinimas();
        UpdateLabel();
    }

    private void GridoSnappinimas()
    {
        int gridSize = waypoint.GetGridSize();
        //snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        //snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(waypoint.GetGridPos().x * gridSize, 0f, waypoint.GetGridPos().y * gridSize);
    }
    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGridPos().x + "&" + waypoint.GetGridPos().y;
        textMesh.text = labelText;
        gameObject.name = labelText;    
    }
            
   
}
