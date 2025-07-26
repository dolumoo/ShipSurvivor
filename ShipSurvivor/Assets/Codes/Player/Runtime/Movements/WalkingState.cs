using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class WalkingState : IPlayerMovementState
    {
        public void EnterState(PlayerMovement context)
        {
            context.playerState.currentMovementState = MovementState.Walking;
        }

        public void ExitState(PlayerMovement context)
        {

        }

        public void UpdateState(PlayerMovement context)
        {
            //WASD ¶¼Áü -> Idle ÀüÈ¯
        }
    }
}