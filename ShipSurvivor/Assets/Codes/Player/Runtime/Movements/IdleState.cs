using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class IdleState : IPlayerMovementState
    {
        public void EnterState(PlayerMovement context)
        {
            context.playerState.currentMovementState = MovementState.Idle;
        }

        public void ExitState(PlayerMovement context)
        {

        }

        public void UpdateState(PlayerMovement context)
        {
            // WASD -> walking 전환

            // Shift -> running 전환

            // Ctrl -> crouching 전환

        }
    }
}