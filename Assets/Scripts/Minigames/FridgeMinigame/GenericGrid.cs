using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
public class GenericGrid : MonoBehaviour
{
    public RectTransform greyBlock;
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
        Debug.Log("GOT HERE!");
        for ( int i = 0; i < cellList.Count; ++i ) 
        {
            if ( cellList[i].isOccupied == false ) {
                return false;
            }
        }

        Debug.Log("COMPLETO!!!!");
       
        isDone = true;
        greyBlock.gameObject.SetActive(true);
        Core.UI.OnMiniGameStepEnd.Invoke();
        
        return isDone;    
    }
}

