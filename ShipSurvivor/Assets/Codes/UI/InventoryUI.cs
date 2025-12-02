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
        public Transform ItemSlotParent;
        public Transform EquipSlotParent;

        private List<InventorySlotUI> ItemSlotUIs = new();
        private List<InventorySlotUI> EquipSlotUIs = new();

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
            for (int i = 0; i < inventory.ItemSlots.Count; i++)
            {
                var obj = Instantiate(slotPrefab, ItemSlotParent);
                var ui = obj.GetComponent<InventorySlotUI>();
                ItemSlotUIs.Add(ui);
            }

            for (int i = 0; i < inventory.EquipSlots.Count; i++)
            {
                var obj = Instantiate(slotPrefab, EquipSlotParent);
                Debug.Log("Instantiated!");
                var ui = obj.GetComponent<InventorySlotUI>();
                EquipSlotUIs.Add(ui);
            }
            UpdateUI();
        }

        public void UpdateUI()
        {
            for (int i = 0; i < inventory.ItemSlots.Count; i++)
            {
                ItemSlotUIs[i].Set(inventory.ItemSlots[i]);
            }

            for (int i = 0; i < inventory.EquipSlots.Count; i++)
            {
                EquipSlotUIs[i].Set(inventory.EquipSlots[i]);
            }
        }
    }
}