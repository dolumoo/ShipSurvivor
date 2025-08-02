using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Player
{
    public class InventorySlotUI : MonoBehaviour
    {
        public Image iconImage;
        public TextMeshProUGUI countText;

        public void Set(InventorySlot slot)
        {
            if (slot.isEmpty)
            {
                iconImage.enabled = false;
                countText.text = "";
            }
            else
            {
                iconImage.enabled = true;
                iconImage.sprite = slot.itemData.icon;
                countText.text = slot.itemData.isStackable ? $"{slot.quantity}" : "";
            }
        }
    }
}