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

        public void ExitState(PlayerMovement context) { }

        public void UpdateState(PlayerMovement context)
        {

            if (context.inputHandler.CrouchHeld)
            {
                context.SwitchState(context.crouchingState);
                return;
            }

            if (context.inputHandler.MoveInput.magnitude > 0f)
            {
                if (context.inputHandler.RunHeld)
                {
                    context.SwitchState(context.runningState);
                    return;
                }
                else
                {
                    context.SwitchState(context.walkingState);
                    return;
                }
            }

            if(context.inputHandler.JumpPressed && context.controller.isGrounded)
            {
                context.Jump();
            }
        }
    }
}