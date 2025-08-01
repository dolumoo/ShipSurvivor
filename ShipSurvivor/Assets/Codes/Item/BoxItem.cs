using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Item;


public class BoxItem : BaseInteractableItem
{
    public override void Interact()
    {
        Debug.Log(this.gameObject.name + "interacted!");
    }
}
