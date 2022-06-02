using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Grid : MonoBehaviour
{
    //Gameobject da c�lula da geladeira
    public GameObject cellGrid;
    public RectTransform container;
    public bool isDone = false;


    [Header("Grid Specs")]
    public List<CellBehaviour> cellList;
    
    private void Awake() {
        FillList();
    }

    private void FillList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
           var a = transform.GetChild(i).GetComponent<CellBehaviour>();
           cellList.Add(a);
        }
    }

    public bool IsComplete() 
    {
        for ( int i = 0; i < cellList.Count; ++i ) 
        {
            if ( cellList[i].isOccupied == false ) {
                return false;
            }
        }

        Debug.Log("COMPLETO!!!!");
        return true;    
    }
}
