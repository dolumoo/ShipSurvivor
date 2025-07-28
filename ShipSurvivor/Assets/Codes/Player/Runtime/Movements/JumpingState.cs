using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player 
{
    public class JumpingState : IPlayerMovementState
    {
        public void EnterState(PlayerMovement context)
        {
            context.playerState.currentMovementState = MovementState.Jumping;
            Debug.Log("มกวม!");
            context.Jump();
        }

        public void ExitState(PlayerMovement context)
        {

        }

        public void UpdateState(PlayerMovement context)
        {
            context.Move(context.playerData.walkSpeed);

            if (context.controller.isGrounded)
            {
                context.SwitchState(context.idleState);
            }
        }
    }
}