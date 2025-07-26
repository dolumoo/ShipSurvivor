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
            var input = context.GetInput();
            context.Move(context.playerData.runSpeed);

            if (input.CrouchHeld)
                context.SwitchState(context.GetCrouchingState());
            else if (!input.RunHeld)
                context.SwitchState(context.GetWalkingState());
            else if (input.MoveInput.magnitude <= 0f)
                context.SwitchState(context.GetIdleState());

            if (input.JumpPressed && context.IsGrounded())
            {
                context.Jump();
            }
        }
    }
}