using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Weapon onHand;

    public void DropItem()
    {
        onHand = null;
    }
}
