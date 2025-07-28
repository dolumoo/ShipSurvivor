using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

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
            context.Move(context.playerData.walkSpeed);

            if (context.inputHandler.CrouchHeld)
            {
                context.SwitchState(context.crouchingState);
                return;
            }

            if (context.inputHandler.RunHeld)
            {
                context.SwitchState(context.runningState);
                return;
            }

            if (context.inputHandler.MoveInput.magnitude < 0.1f)
            {
                context.SwitchState(context.idleState);
                return;
            }

            if (context.inputHandler.JumpPressed && context.controller.isGrounded)
            {
                context.SwitchState(context.jumpingState);
            }
        }
    }
}
