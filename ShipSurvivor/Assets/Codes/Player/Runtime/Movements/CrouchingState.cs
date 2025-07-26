using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{

    public class CrouchingState : IPlayerMovementState
    {
        public void EnterState(PlayerMovement context)
        {
            context.playerState.currentMovementState = MovementState.Crouching;
        }

        public void ExitState(PlayerMovement context)
        {

        }

        public void UpdateState(PlayerMovement context)
        {
            //Ctrl ¶¼Áü -> Idle ÀüÈ¯
        }
    }
}