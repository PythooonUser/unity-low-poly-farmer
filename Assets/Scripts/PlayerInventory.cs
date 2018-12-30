using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Player Inventory")]
public class PlayerInventory : ScriptableObject
{
    [SerializeField]
    private int seedAmount;

    public void SetDefaultState()
    {
        this.seedAmount = 4;
    }

    public int GetSeedAmount()
    {
        return this.seedAmount;
    }

    public void ReduceSeedAmount()
    {
        this.seedAmount -= 1;
    }
}
