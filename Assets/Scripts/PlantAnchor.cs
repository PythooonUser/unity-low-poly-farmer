using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAnchor : MonoBehaviour
{
    [SerializeField] bool isActive;

    public bool PlantSeed(GameObject plantPrefab)
    {
        if (this.isActive)
        {
            return false;
        }

        GameObject plant = (GameObject)Instantiate(plantPrefab, transform.position, Quaternion.identity);
        plant.transform.SetParent(transform);

        this.isActive = true;

        return true;
    }
}
