using System.Collections.Generic;
using UnityEngine;

enum PlayerState
{
    idle,
    moving,
    passive,
    comforting,
    holding,
    interacting,
}

public class PlayerStateFactory
{
    PlayerStateMachine _context;
    Dictionary<PlayerState, PlayerBaseState> _states = new Dictionary<PlayerState, PlayerBaseState>();

    public PlayerStateFactory(PlayerStateMachine currentContext)
    {
        _context = currentContext;
        _states[PlayerState.idle] = new PlayerIdleState(_context, this);
        _states[PlayerState.moving] = new PlayerMovingState(_context, this);
        _states[PlayerState.passive] = new PlayerPassiveSubState(_context, this);
        _states[PlayerState.holding] = new PlayerHoldingSubState(_context, this);
        _states[PlayerState.comforting] = new PlayerComfortingSubState(_context, this);
        _states[PlayerState.interacting] = new PlayerInteractingSubState(_context, this);
    }

    public PlayerBaseState Idle()
    {
        Core.Data.main = 1; 
        return _states[PlayerState.idle];
    }
    public PlayerBaseState Moving()
    {
        Core.Data.main = 2;
        return _states[PlayerState.moving];
    }
    public PlayerBaseState Passive()
    {
        Core.Data.second = 1;
        return _states[PlayerState.passive];
    }
    public PlayerBaseState Comforting() 
    {
        Core.Data.second = 2;
        return _states[PlayerState.comforting];
    }
    public PlayerBaseState Holding() 
    {
        Core.Data.second = 3;
        return _states[PlayerState.holding];
    }
    public PlayerBaseState Interacting()
    {
        Core.Data.second = 4;
        return _states[PlayerState.interacting];
    }
}
