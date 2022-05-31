using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
 
public class GenericPieceBehaviour : MonoBehaviour
{
    public Canvas ui_canvas;

    private RectTransform element_rect;
    private GraphicRaycaster ui_raycaster;
    private PointerEventData click_data;
    private List<RaycastResult> click_results;
    private bool dragging = false;
    private GameObject drag_element;
 
    private List<GameObject> clicked_elements;
 
    private Vector2 mouse_position;
    private Vector2 previous_mouse_position;

    private void Awake() 
    {
        ui_canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
    
        ui_raycaster = ui_canvas.GetComponent<GraphicRaycaster>();
        click_data = new PointerEventData(EventSystem.current);
        click_results = new List<RaycastResult>();
        clicked_elements = new List<GameObject>();
    }
 
    void Update()
    {
        MouseDragUi();
    }
 
    void MouseDragUi()
    {
        /** Houses the main mouse dragging logic. **/
 
        mouse_position = Mouse.current.position.ReadValue();
 
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            DetectUi();
        }
 
        if(Mouse.current.leftButton.isPressed && dragging)
        {
            DragElement();
        }
        else
        {
            dragging = false;
        }
 
        previous_mouse_position = mouse_position;
    }
 
    void DetectUi()
    {
        /** Detect if the mouse has been clicked on a UI element, and begin dragging **/
 
        GetUiElementsClicked();
 
        if(clicked_elements.Count > 0)
        {
            dragging = true;
            drag_element = clicked_elements[0];
        }
    }
 
    void GetUiElementsClicked()
    {
        /** Get all the UI elements clicked, using the current mouse position and raycasting. **/
 
        click_data.position = mouse_position;
        click_results.Clear();
        ui_raycaster.Raycast(click_data, click_results);
 
        // Optimised version
        //clicked_elements = (from result in click_results select result.gameObject).ToList();
 
        // Foreach version
        clicked_elements.Clear();
        foreach(RaycastResult result in click_results)
        {
            clicked_elements.Add(result.gameObject);
        }
    }
 
    void DragElement()
    {
        /** Drag a UI element across the screen based on the mouse movement. **/
        if(drag_element != null && drag_element.tag == "Piece")
        {
            element_rect = drag_element.GetComponent<RectTransform>();
 
            Vector2 drag_movement = mouse_position - previous_mouse_position;
            element_rect.anchoredPosition = element_rect.anchoredPosition + drag_movement;
        }
    }
 
}