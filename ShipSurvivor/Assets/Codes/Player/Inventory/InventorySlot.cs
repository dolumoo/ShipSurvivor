using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Item;

namespace Game.Player
{
    public class InventorySlot
    {
        public ItemData itemData;
        public int quantity;

        public bool isEmpty => itemData == null;
    }
}