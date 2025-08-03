using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;
using Game.Core;

namespace Game.UI
{
    public class InventoryUIManager : Singleton <InventoryUIManager>
    {
        [Header("Reference")]
        public PlayerInputHandler playerInputHandler;

        public UnityEvent OnInventoryToggleChanged;

        private InventoryUI inventoryUI;
        private bool isInventoryOpen = false;

        public override void Awake()
        {
            base.Awake();
            inventoryUI = GetComponentInChildren<InventoryUI>();
        }

        private void OnEnable()
        {
            playerInputHandler.OnInventoryToggle.AddListener(ToggleInventory);
        }

        private void OnDisable()
        {
            playerInputHandler.OnInventoryToggle.RemoveListener(ToggleInventory);
        }

        private void ToggleInventory()
        {
            isInventoryOpen = !isInventoryOpen;
            inventoryUI.gameObject.SetActive(isInventoryOpen);
            OnInventoryToggleChanged.Invoke();
        }
    }
}