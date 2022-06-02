using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class InputHandler : MonoBehaviour
{
    [HideInInspector] public BaseMovement baseMove;
    [HideInInspector] public bool IsMovePressed;
    public Vector2 mPos { get; private set; }
    public Vector2 mTest;
    public Vector3 mInput { get; private set; }
    public Cinemachine.CinemachineInputProvider mLook;
    public InputActionReference mZero;
    public InputActionReference mFollow;

    public UnityEvent<string> OnInteract = new UnityEvent<string>();

    private GameObject selectedObject;
    private GameObject playerHands;
    private GameObject currentTarget;
    private RaycastHit hit;

    public TMP_Text objName;

    private void Awake()
    {
        selectedObject = Core.Data.selectedObject;
        playerHands = Core.Data.playerHands;
        hit = Core.Data.hit;

        baseMove = new BaseMovement();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        baseMove.KeyboardMouse.ComfortObject.started += PullComfortObject;
        baseMove.KeyboardMouse.PickUp.started += Interaction;
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        mInput = baseMove.KeyboardMouse.Movement.ReadValue<Vector3>();
        IsMovePressed = mInput != Vector3.zero;
    }
    public void MouseInput(InputAction.CallbackContext context) 
    {
        mPos = baseMove.KeyboardMouse.Look.ReadValue<Vector2>();

        Core.Data.ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
        
        if(Physics.Raycast(Core.Data.ray, out hit, Core.Data.contactDistance) && hit.transform.tag == "PickUp")
        {
            var target = hit.transform.gameObject;
            if(currentTarget != target)
            {
                objName.gameObject.SetActive(true);
                objName.SetText(hit.transform.gameObject.name);
                currentTarget = target;
                currentTarget.layer = LayerMask.NameToLayer("Highlight");
            }
        }
        else if(currentTarget != null)
        { 
            objName.gameObject.SetActive(false);
            currentTarget.layer = LayerMask.NameToLayer("Default");
            currentTarget = null;
        }
    }
    public void Interaction(InputAction.CallbackContext context) 
    {
        context.ReadValueAsButton();

        if (Core.Data.second == 3) Core.Data.isHolding = false;
        else if(Physics.Raycast(Core.Data.ray, out hit, Core.Data.contactDistance) && hit.transform.tag == "PickUp") Core.Data.isHolding = true;
        else if(Physics.Raycast(Core.Data.ray, out hit, Core.Data.contactDistance) && hit.transform.tag == "Interactible") Action(hit.transform.name);
    }
    public void PullComfortObject(InputAction.CallbackContext context)
    {
        context.ReadValueAsButton();
        if(!Core.Data.isComforting) Core.Data.isComforting = true;
    }
    void toggleRigidBody(bool state, Rigidbody rb)
    {
        rb.useGravity = state;
        rb.isKinematic = !state;
        rb.detectCollisions = state;
        rb.drag = 0;
    }
    public void PickUpAction()
    {
        //Debug.Log($"you picked a {hit.transform.name}");
        selectedObject = hit.transform.gameObject;
        toggleRigidBody(false, hit.rigidbody);
        selectedObject.transform.position = playerHands.transform.position;
        selectedObject.transform.SetParent(playerHands.transform);
    }
    public void DropAction()
    {
        var pickedRb = selectedObject.GetComponent<Rigidbody>();
        //Debug.Log($"You dropped a {selectedObject.transform.name}");
        selectedObject.transform.SetParent(null);
        toggleRigidBody(true, pickedRb);
        pickedRb.AddForce(playerHands.transform.forward * 5f, ForceMode.Impulse);
        pickedRb.drag = 0.5f;
    }

    private void Action(string id) => OnInteract.Invoke(id);

    public void DebugButton(InputAction.CallbackContext context)
    {
        context.ReadValueAsButton();
        Instantiate(Core.UI.gridTest, Core.UI.barHolder);
    }


    private void OnEnable() => baseMove.Enable();
    
    private void OnDisable()
    {
        baseMove.KeyboardMouse.ComfortObject.started -= PullComfortObject;
        baseMove.KeyboardMouse.PickUp.started -= Interaction;
        OnInteract.RemoveAllListeners();
        baseMove.Disable();
    }

}

