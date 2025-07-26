using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerInputActions inputActions;

        public Vector2 MoveInput { get; private set; }
        public bool JumpPressed { get; private set; }
        public bool CrouchHeld { get; private set; }
        public bool RunHeld { get; private set; }

        private void Awake()
        {
            inputActions = new PlayerInputActions();
        }

        void OnEnable()
        {
            inputActions.Player.Enable();

            inputActions.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
            inputActions.Player.Move.canceled += ctx => MoveInput = Vector2.zero;

            inputActions.Player.Jump.started += ctx => JumpPressed = true;
            inputActions.Player.Jump.canceled += ctx => JumpPressed = false;

            inputActions.Player.Crouch.started += ctx => CrouchHeld = true;
            inputActions.Player.Crouch.canceled += ctx => CrouchHeld = false;

            inputActions.Player.Run.started += ctx => RunHeld = true;
            inputActions.Player.Run.canceled += ctx => RunHeld = false;
        }

        void OnDisable()
        {
            inputActions.Player.Disable();
        }
    }
}