using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellBehaviour : MonoBehaviour, IDropHandler
{
    public bool isOccupied = false;
    public Image border;

    private bool accept = false;

    public GameObject item
    {
        get 
        {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            
            return null;
        }
    }

    public async void OnDrop(PointerEventData eventData)
    {
        var i = DragAndDropController.itemBeingDragged;

        if(!item && !isOccupied && accept) 
        {
            i.transform.SetParent(transform);
            i.transform.position = i.transform.parent.position;
        }

        transform.parent.GetComponent<AudioSource>().Play();
        await Task.Delay(100);
        transform.parent.GetComponent<GenericGrid>().IsComplete();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(!item && !isOccupied) accept = true;
        else accept = false;
    }
}
