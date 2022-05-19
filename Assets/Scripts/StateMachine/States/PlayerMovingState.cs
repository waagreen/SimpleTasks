using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : PlayerBaseState
{
    public PlayerMovingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { isRootState = true; }

    public override void EnterState()
    {
        InitializeSubState();
    }
    public override void UpdateState() 
    {
        _contex.Moving();
        CheckSwitchStates();
    }
    public override void ExitState()
    {

    }
    public override void CheckSwitchStates()
    {
        if (!_contex.IsMovePressed) ChangeState(_fact.Idle());
    }
    public override void InitializeSubState()
    {
        if (Core.Data.isComforting == false && Core.Data.isHolding == false) SetSubState(_fact.Passive());
        else if(Core.Data.isComforting == false && Core.Data.isHolding == true) SetSubState(_fact.Holding());
        else if(Core.Data.isComforting == true && Core.Data.isHolding == false) SetSubState(_fact.Comforting());
    }

}
