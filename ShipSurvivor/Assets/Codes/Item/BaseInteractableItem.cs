using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Interaction;
using Game.Player;

namespace Game.Item
{
    public abstract class BaseInteractableItem : MonoBehaviour, IInteractable
    {
        [SerializeField] protected string interactPrompt = "상호작용 메세지를 입력하세요";

        public virtual string GetInteractPrompt()
        {
            return interactPrompt;
        }

        public abstract void Interact(Inventory inventory);
    }
}