using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellBehaviour : MonoBehaviour, IDropHandler
{
    public bool isOccupied = false;

    public GameObject item
    {
        get {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(!item && !isOccupied) DragAndDropController.itemBeingDragged.transform.SetParent(transform);
    }
}
