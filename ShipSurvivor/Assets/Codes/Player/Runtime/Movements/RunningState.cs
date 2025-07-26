using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class RunningState : IPlayerMovementState
    {
        public void EnterState(PlayerMovement context)
        {
            context.playerState.currentMovementState = MovementState.Running;
        }

        public void ExitState(PlayerMovement context)
        {

        }

        public void UpdateState(PlayerMovement context)
        {
            //Shift ¶¼Áü -> Idle ÀüÈ¯
        }
    }
}