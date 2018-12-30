using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Player Inventory")]
public class PlayerInventory : ScriptableObject
{
    [SerializeField] int seedAmount;
    [SerializeField] GameObject plantPrefab;

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

    public void IncreaseSeedAmount(int seedAmount)
    {
        this.seedAmount += seedAmount;
    }

    public GameObject GetPlantPrefab()
    {
        return this.plantPrefab;
    }
}
