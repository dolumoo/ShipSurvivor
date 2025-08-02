using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


namespace Game.Item
{
    public enum ItemType { Weapon, Consumable, Tool}

    [CreateAssetMenu(menuName = "Item/ItemData")]
    public class ItemData : ScriptableObject
    {
        public string itemName;
        public Sprite icon;
        public ItemType type;
        public GameObject prefab;

        [FormerlySerializedAs("iStackable")]
        public bool isStackable;

        public int maxStack;
    }
}