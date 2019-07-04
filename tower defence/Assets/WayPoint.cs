using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    
    const int gridSize = 10;
    //[SerializeField] Raketa raketa;
    public bool BokstasJauCiaStovi = false;
    public bool Pastatomas = true;
    Vector2Int gridPos;
    
    public bool istirtas = false;
    public WayPoint istirtasIs;
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize));
    }
    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();     
        topMeshRenderer.material.color = color;
        //MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        //topMeshRenderer.material.color = color;
    }
    
    /*public void StartStop(Color color)
    {
        MeshRenderer endMeshRenderer = transform.Find("end").GetComponent<MeshRenderer>();
        endMeshRenderer.material.color = color;
    }*/
   
    /*public void SetBackColor(Color color1)
    {
        MeshRenderer backMeshRenderer = transform.Find("Finish").GetComponent<MeshRenderer>();
        backMeshRenderer.material.color = color1;
        //MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        //topMeshRenderer.material.color = color;
    }*/
    public int GetGridSize()
    {
        return gridSize;
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Pastatomas)
            {
                Debug.Log("Bokstas pastatytas ant " + " " + gameObject.name);
                if (Pastatomas == true)
                {
                    FindObjectOfType<TowerFactory>().AddTower(this);
                }
            }
            else
            {
                print("cia negalima statyt boksto");
            }
        }
    }
}
