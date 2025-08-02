using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Item;

namespace Game.Player
{
    public class Inventory : MonoBehaviour
    {
        public int slotCount = 6;
        public List<InventorySlot> slots = new();

        private void Awake()
        {
            for (int i = 0; i < slotCount; i++)
            {
                slots.Add(new InventorySlot());
            }
        }

        public bool AddItem(ItemData item)
        {
            Debug.Log(slots.Count);
            // ½ºÅÃÀ» ½×À» ¼ö ÀÖ´ÂÁö È®ÀÎ
            if (item.isStackable)
            {
                Debug.Log("½ºÅÃ½×±â °¡´É");
                foreach (var slot in slots)
                {
                    if(slot.itemData == item && slot.quantity < item.maxStack)
                    {
                        slot.quantity++;
                        Debug.Log("½ºÅÃ Ãß°¡µÊ");
                        return true;
                    }
                }
            }

            // ºó ½½·Ô Ã£±â
            foreach (var slot in slots)
            {
                if (slot.isEmpty)
                {
                    slot.itemData = item;
                    slot.quantity = 1;
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