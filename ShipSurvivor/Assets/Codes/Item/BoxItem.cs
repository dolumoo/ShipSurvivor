using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;

namespace Game.Item
{
    public class BoxItem : BaseInteractableItem
    {
        public ItemData itemData;

        public override void Interact(Inventory inventory)
        {
            inventory.AddItem(itemData);
            Debug.Log(this.gameObject.name + "interacted!");
        }
    }
}