using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Interaction;

namespace Game.Item
{
    public abstract class BaseInteractableItem : MonoBehaviour, IInteractable
    {
        [SerializeField] protected string interactPrompt = "interact";

        public virtual string GetInteractPrompt()
        {
            return interactPrompt;
        }

        public abstract void Interact();
    }
}