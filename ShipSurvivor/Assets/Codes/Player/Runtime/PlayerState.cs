using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public enum MovementState
    {
        Idle,
        Walking,
        Running,
        Crouching
    }

    public class PlayerState : MonoBehaviour
    {
        public float currentHealth;
        public float currentStamina;

        public MovementState currentMovementState;

        public bool isDead;
        public float currentNoiseLevel;

        public void Initialize(PlayerData data)
        {
            currentHealth = data.maxHealth;
            currentStamina = data.maxStamina;
            currentMovementState = MovementState.Idle;
            isDead = false;
            currentNoiseLevel = 0;
        }
    }
}