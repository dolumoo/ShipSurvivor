using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
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

        [Header("State")]
        public bool isGrounded = true;

        public IPlayerMovementState currentState;
        public IdleState idleState;
        public WalkingState walkingState;
        public RunningState runningState;
        public CrouchingState crouchingState;
        public JumpingState jumpingState;

        private void Awake()
        {
            idleState = new IdleState();
            walkingState = new WalkingState();
            runningState = new RunningState();
            crouchingState = new CrouchingState();
            jumpingState = new JumpingState();
        }

        private void Start()
        {
            playerState = GetComponent<PlayerState>();
            playerState.Initialize(playerData);

            controller = GetComponent<CharacterController>();
            inputHandler = GetComponent<PlayerInputHandler>();

            isGrounded = controller.isGrounded;
            currentState = idleState;
        }

        private void Update()
        {
            currentState.UpdateState(this);
            isGrounded = controller.isGrounded;
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
