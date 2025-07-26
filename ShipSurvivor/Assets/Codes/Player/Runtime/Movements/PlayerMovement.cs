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
        private CharacterController controller;
        private Vector3 velocity;

        [Header("Setting")]
        public float gravity = -9.81f;


        private IPlayerMovementState currentState;
        private IdleState idleState;
        private WalkingState walkingState;
        private RunningState runningState;
        private CrouchingState crouchingState;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();

            idleState = new IdleState();
            walkingState = new WalkingState();
            runningState = new RunningState();
            crouchingState = new CrouchingState();

            currentState = idleState;
        }

        private void Update()
        {
            currentState.UpdateState(this);
        }

        public void SwitchState(IPlayerMovementState newState)
        {
            currentState.ExitState(this);
            currentState = newState;
            currentState.EnterState(this);
        }

        public void Jump()
        {

        }

        public void ApplyGravity()
        {

        }
    }
}