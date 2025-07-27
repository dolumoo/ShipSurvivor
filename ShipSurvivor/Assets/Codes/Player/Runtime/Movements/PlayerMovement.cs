using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Reference")]
        public PlayerData playerData;
        public PlayerState playerState;
        public CharacterController controller;
        public PlayerInputHandler inputHandler;
        private Vector3 velocity;

        [Header("Setting")]
        public float gravity = -9.81f;


        public IPlayerMovementState currentState;
        public IdleState idleState;
        public WalkingState walkingState;
        public RunningState runningState;
        public CrouchingState crouchingState;

        private void Awake()
        {
            playerState = GetComponent<PlayerState>();
            playerState.Initialize(playerData);

            controller = GetComponent<CharacterController>();
            inputHandler = GetComponent<PlayerInputHandler>();

            idleState = new IdleState();
            walkingState = new WalkingState();
            runningState = new RunningState();
            crouchingState = new CrouchingState();

            currentState = idleState;
        }

        private void Update()
        {
            currentState.UpdateState(this);
            ApplyGravity();
        }

        public void SwitchState(IPlayerMovementState newState)
        {
            currentState.ExitState(this);
            currentState = newState;
            currentState.EnterState(this);
        }

        public void Move(float moveSpeed)
        {
            Vector3 move = transform.right * inputHandler.MoveInput.x + transform.forward * inputHandler.MoveInput.y;
            controller.Move(move * moveSpeed * Time.deltaTime);
        }

        public void Jump()
        {
            if (controller.isGrounded)
            {
                velocity.y = Mathf.Sqrt(playerData.jumpForce * -2f * gravity);
            }
        }

        public void ApplyGravity()
        {
            if (controller.isGrounded && velocity.y < 0f)
            {
                velocity.y = -2f;
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
