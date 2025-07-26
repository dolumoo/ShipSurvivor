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
            var input = context.GetInput();

            if (input.CrouchHeld)
                context.SwitchState(context.GetCrouchingState());
            else if (input.RunHeld && input.MoveInput.magnitude > 0f)
                context.SwitchState(context.GetRunningState());
            else if (input.MoveInput.magnitude > 0f)
                context.SwitchState(context.GetWalkingState());

            if (input.JumpPressed && context.IsGrounded())
            {
                context.Jump();
            }
        }
    }
}