using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.InputSystem;
using Game.Player;

namespace Game.Interaction
{
    public interface IInteractable
    {
        void Interact();
        string GetInteractPrompt();
    }
    public class InteractionDetector : MonoBehaviour
    {
        [Header("Detection Setting")]
        public float maxInteractDistance = 3f;
        public LayerMask interactLayer;

        [Header("UI Settings")]
        public GameObject interactionUI;
        public TextMeshProUGUI interactionText;

        private PlayerInputHandler inputHandler;
        private Transform cameraTransform;
        private IInteractable currentTarget;
        private readonly List<IInteractable> nearbyInteractables = new List<IInteractable>();

        private void Start()
        {
            cameraTransform = Camera.main.transform;
            inputHandler = GetComponentInParent<PlayerInputHandler>();
            interactionUI.SetActive(false);
        }

        private void Update()
        {
            IInteractable bestTarget = null;
            float closestDistance = float.MaxValue;
            Vector3 rayOrigin = cameraTransform.position;
            Vector3 rayDir = cameraTransform.forward;

            foreach (var obj in nearbyInteractables) {
                if (obj is MonoBehaviour mono)
                {
                    float distance = DistanceFromRayToPoint(rayOrigin, rayDir, mono.transform.position);
                    float flatDistance = Vector3.Distance(rayOrigin, mono.transform.position);

                    if (flatDistance <= maxInteractDistance && distance < closestDistance)
                    {
                        closestDistance = distance;
                        bestTarget = obj;
                    }
                }
            }

            if (bestTarget != null)
            {
                currentTarget = bestTarget;
                interactionUI.SetActive(true);
                interactionText.text = currentTarget.GetInteractPrompt();

                if (inputHandler.InteractPressed)
                {
                    currentTarget.Interact();
                }
            }
            else
            {
                currentTarget = null;
                interactionUI.SetActive(false);
            }

        }

        private float DistanceFromRayToPoint(Vector3 origin, Vector3 dir, Vector3 point)
        {
            Vector3 originToPoint = point - origin;
            Vector3 projected = Vector3.Project(originToPoint, dir);
            Vector3 closestPoint = origin + projected;
            return Vector3.Distance(closestPoint, point);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Tirgger in" + other.gameObject.name);
            if (other.TryGetComponent<IInteractable>(out var interactable))
            {
                Debug.Log("Find interactive item!");
                if (!nearbyInteractables.Contains(interactable))
                {
                    nearbyInteractables.Add(interactable);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Trigger out" + other.gameObject.name);
            if (other.TryGetComponent<IInteractable>(out var interactable))
            {
                if (nearbyInteractables.Contains(interactable))
                {
                    nearbyInteractables.Remove(interactable);
                }
            }
        }
    }
}