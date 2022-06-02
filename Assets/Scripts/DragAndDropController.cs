using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    [SerializeField] private float dampSpeed = 0;

    private Transform startParent;
    private RectTransform draggableObject;
    private bool isBeingDragged = false;

    
    CellBehaviour lastPiece;

    private Vector3 startPosition;
    private Vector3 velocity = Vector3.zero;

    private void Awake() {
        draggableObject = transform as RectTransform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToWorldPointInRectangle(draggableObject, eventData.position, eventData.pressEventCamera, out var mPos))
        {
            draggableObject.position = Vector3.SmoothDamp(draggableObject.position, mPos, ref velocity, dampSpeed);
            isBeingDragged = true;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if(transform.parent == startParent) transform.position = startPosition;
        isBeingDragged = false;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        CellBehaviour piece = other.GetComponent<CellBehaviour>();

        if(piece != null)
        {
            if (!isBeingDragged) 
            {
                piece.isOccupied = true;
                if(piece.isOccupied) piece.border.color = Color.black;
            }
            else if(other.attachedRigidbody == null && !isBeingDragged) 
            {
                piece.isOccupied = false;
                if(!piece.isOccupied && !isBeingDragged) piece.border.color = Color.black;
            }
        }
    }

    
}
