using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldingSubState : PlayerBaseState
{
    public PlayerHoldingSubState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { isRootState = false;}

    public override void EnterState()
    {
        Core.Binds.PickUpAction();
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void CheckSwitchStates()
    {
        if (Core.Data.isHolding == false) ChangeState(_fact.Passive());
    }
    public override void ExitState()
    {
        Core.Binds.DropAction();
    }

    public override void InitializeSubState()
    {
        
    }
}
