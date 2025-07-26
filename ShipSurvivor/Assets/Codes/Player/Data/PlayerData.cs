using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    [CreateAssetMenu(fileName = "NewPlayerData", menuName = "Player/Player Data")]

    public class PlayerData : ScriptableObject
    {
        [Header("Movement")]
        public float walkSpeed = 3.0f;
        public float runSpeed = 6.0f;
        public float crouchSpeed = 1.5f;
        public float jumpForce = 5.0f;

        [Header("Hitbox")]
        public float crouchHeight = 1.0f;
        public float normalHeight = 2.0f;

        [Header("Stamina")]
        public float maxStamina = 100f;
        public float staminaDrainRate = 10f;
        public float staminaRegenRate = 5f;

        [Header("Health")]
        public float maxHealth = 100f;

        [Header("Stealth")]
        public float noiseLevelWalk = 1.0f;
        public float noiseLevelRun = 2.5f;
        public float noiseLevelCrouch = 0.3f;
    }
}