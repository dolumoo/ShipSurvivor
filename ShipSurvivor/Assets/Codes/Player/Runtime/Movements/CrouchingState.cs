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

        public void ExitState(PlayerMovement context) { }

        public void UpdateState(PlayerMovement context)
        {
            var input = context.GetInput();
            context.Move(context.playerData.crouchSpeed);

            if (!input.CrouchHeld)
            {
                if (input.MoveInput.magnitude > 0f)
                {
                    context.SwitchState(context.GetWalkingState());
                }
                else
                {
                    context.SwitchState(context.GetIdleState());
                }
            }
        }
    }
}