using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPassiveSubState : PlayerBaseState
{
    public PlayerPassiveSubState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { isRootState = false; }

    public override void EnterState()
    {
        Core.Data.isComforting = false;
        Core.Data.isHolding = false; 
        Core.Data.isInteracting = false;
    }
    
    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void CheckSwitchStates()
    {
        if(Core.Data.isComforting) ChangeState(_fact.Comforting());
        else if(Core.Data.isHolding) ChangeState(_fact.Holding());
        else if(Core.Data.isInteracting) ChangeState(_fact.Interacting());
    }

    public override void ExitState()
    {

    }

    public override void InitializeSubState()
    {

    }

 
}
