using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;

namespace Game.UI
{
    public class InventoryUI : MonoBehaviour
    {
        [Header("References")]
        public Inventory inventory;
        public GameObject slotPrefab;
        public Transform slotParent;

        private List<InventorySlotUI> slotUIs = new();

        private void OnEnable()
        {
            InventoryUIManager.Instance.OnInventoryToggleChanged.AddListener(UpdateUI);
            inventory.OnInventoryChanged.AddListener(UpdateUI);
        }

        private void OnDisable()
        {
            InventoryUIManager.Instance.OnInventoryToggleChanged.RemoveListener(UpdateUI);
            inventory.OnInventoryChanged.RemoveListener(UpdateUI);
        }

        private void Start()
        {
            for (int i = 0; i < inventory.slots.Count; i++)
            {
                var obj = Instantiate(slotPrefab, slotParent);
                var ui = obj.GetComponent<InventorySlotUI>();
                slotUIs.Add(ui);
            }
            UpdateUI();
        }

        public void UpdateUI()
        {
            for (int i = 0; i < inventory.slots.Count; i++)
            {
                slotUIs[i].Set(inventory.slots[i]);
            }
        }
    }
}