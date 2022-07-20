using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class CollactableCoin : CollactableBase
{
    public Collider2D colliderCoin;

    protected override void OnCollect() {
        base.OnCollect();
        ItemManager.Instance.AddByType(ItemType.COIN);

        colliderCoin.enabled = false;
    }
}