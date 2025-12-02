using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Game.Item;

namespace Game.Player
{
    public class Inventory : MonoBehaviour
    {
        public int ItemSlotCount = 9;
        public int EquipSlotCount = 3;
        public List<InventorySlot> ItemSlots = new();
        public List<InventorySlot> EquipSlots = new();
        public UnityEvent OnInventoryChanged;

        private void Awake()
        {
            for (int i = 0; i < ItemSlotCount; i++)
            {
                ItemSlots.Add(new InventorySlot());
            }

            for (int i = 0; i < EquipSlotCount; i++)
            {
                EquipSlots.Add(new InventorySlot());
            }
        }

        public bool AddItem(ItemData item)
        {
            Debug.Log(ItemSlots.Count);
            // ½ºÅÃÀ» ½×À» ¼ö ÀÖ´ÂÁö È®ÀÎ
            if (item.isStackable)
            {
                Debug.Log("½ºÅÃ½×±â °¡´É");
                foreach (var slot in ItemSlots)
                {
                    if(slot.itemData == item && slot.quantity < item.maxStack)
                    {
                        slot.quantity++;
                        OnInventoryChanged.Invoke();
                        Debug.Log("½ºÅÃ Ãß°¡µÊ");
                        return true;
                    }
                }
            }

            // ºó ½½·Ô Ã£±â
            foreach (var slot in ItemSlots)
            {
                if (slot.isEmpty)
                {
                    slot.itemData = item;
                    slot.quantity = 1;
                    OnInventoryChanged.Invoke();
                    Debug.Log("»õ ½½·Ô »ç¿ë");
                    return true;
                }
            }

            // ºó ½½·Ô ¾øÀ½
            Debug.Log("ÀÎº¥Åä¸® ²ËÂü!");
            return false;
        }
    }
}