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

        public void ExitState(PlayerMovement context) { }

        public void UpdateState(PlayerMovement context)
        {

            context.Move(context.playerData.runSpeed);

            if (context.inputHandler.CrouchHeld)
            {
                context.SwitchState(context.crouchingState);
                return;
            }

            if (context.inputHandler.MoveInput.magnitude < 0.1f)
            {
                context.SwitchState(context.idleState);
                return;
            }

            if (!context.inputHandler.RunHeld)
            {
                context.SwitchState(context.walkingState);
                return;
            }

            if (context.inputHandler.JumpPressed)
            {
                context.Jump();
            }
        }
    }
}