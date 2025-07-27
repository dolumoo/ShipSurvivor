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
            context.Move(context.playerData.crouchSpeed);

            if (!context.inputHandler.CrouchHeld)
            {
                if (context.inputHandler.MoveInput.magnitude > 0f)
                {
                    context.SwitchState(context.walkingState);
                    return;
                }
                else
                {
                    context.SwitchState(context.idleState);
                    return;
                }
            }
        }
    }
}