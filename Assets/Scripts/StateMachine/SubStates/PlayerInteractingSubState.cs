using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractingSubState : PlayerBaseState
{
    public PlayerInteractingSubState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { isRootState = false; }
    
    public override void EnterState()
    {
        Core.Binds.baseMove.KeyboardMouse.Movement.Disable();
        Core.Binds.mLook.XYAxis = Core.Binds.mZero;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void CheckSwitchStates()
    {
        if (!Core.Data.isInteracting) ChangeState(_fact.Passive());
    }
    public override void ExitState()
    {
        Core.Binds.baseMove.KeyboardMouse.Movement.Enable();
        Core.Binds.mLook.XYAxis = Core.Binds.mFollow;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public override void InitializeSubState()
    {
        
    }
}
