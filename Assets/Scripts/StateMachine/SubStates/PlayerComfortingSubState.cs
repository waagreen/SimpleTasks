using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComfortingSubState : PlayerBaseState
{
    public PlayerComfortingSubState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { isRootState = false; }

    public override void EnterState()
    {
        Core.UI.CreateStressBar(Core.Data.stressLevel);
        Core.Binds.baseMove.KeyboardMouse.Movement.Disable();
        Core.Binds.mLook.XYAxis = Core.Binds.mZero;
    }
    public override void UpdateState()
    {
        Core.UI.CheckMiniGameEnd();
        CheckSwitchStates();
    }   

    public override void CheckSwitchStates()
    {
        if (!Core.Data.isComforting) ChangeState(_fact.Passive());
    }

    public override void ExitState()
    {   
        Core.Binds.baseMove.KeyboardMouse.Movement.Enable();
        Core.Binds.mLook.XYAxis = Core.Binds.mFollow;
    }

    public override void InitializeSubState()
    {
        
    }
}
