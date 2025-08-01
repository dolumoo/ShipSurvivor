using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerLook : MonoBehaviour
    {
        [Header("Reference")]
        public Transform playerBody;
        public Transform cameraHolder;

        [Header("Sensitivity")]
        public float mouseSensitivity = 70f;

        private float xRotation = 0f;
        private PlayerInputActions inputActions;
        public Vector2 mouseDelta;

        private void Awake()
        {
            inputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            inputActions.Enable();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void OnDisable()
        {
            inputActions.Disable();
            Cursor.lockState -= CursorLockMode.None;
            Cursor.visible = true;
        }

        private void Update()
        {
            Vector2 mouseDelta = inputActions.Player.Look.ReadValue<Vector2>();

        // 마우스 입력 적용
            float mouseX = mouseDelta.x * mouseSensitivity * Time.deltaTime;
            float mouseY = mouseDelta.y * mouseSensitivity * Time.deltaTime;

            // 상하 시야 회전 (카메라만 들고 숙이기)
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            cameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // 좌우 회전
            playerBody.Rotate(Vector3.up * mouseX);
        }

        private void OnDrawGizmos()
        {
            if (cameraHolder != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(cameraHolder.position, cameraHolder.forward * 2f);
            }
        }
    }
}