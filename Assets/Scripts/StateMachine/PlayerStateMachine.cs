using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [HideInInspector] public PlayerBaseState cState;
    [HideInInspector] public PlayerStateFactory fState;
    [SerializeField] private Transform player;

    public CharacterController controller;
    public Camera mCam;

    private Vector3 move;

    //getters setters
    public bool IsMovePressed { get => Core.Binds.IsMovePressed; }

    public PlayerBaseState CurrentContext
    {
        get => cState;
        set
        {
            cState = value;
        }
    }

    //personagem sempre inicia no IDLE STATE
    public void Awake()
    {
        move = Core.Data.move;

        Core.Data.stressLevel = 4;
        fState = new PlayerStateFactory(this);
        cState = fState.Idle();
        cState.EnterState();
    }

    public void Update()
    {
        Gravity();
        cState.UpdateStates();
    }

    public void Moving()
    {
        move = Vector3.zero;

        move = Core.Binds.mInput;
        move = mCam.transform.forward * move.z + mCam.transform.right * move.x;

        controller.Move(move * Core.Data._speed * Time.deltaTime);
    }

    public void Gravity() 
    {
        if (controller.isGrounded == false) Core.Data.grav.y += Core.Data._gravity * Time.deltaTime;
        controller.Move(Core.Data.grav * Time.deltaTime);
    }
}
