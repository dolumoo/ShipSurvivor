using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class InventoryUI : MonoBehaviour
    {
        public Inventory inventory;
        public GameObject slotPrefab;
        public Transform slotParent;

        private List<InventorySlotUI> slotUIs = new();

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