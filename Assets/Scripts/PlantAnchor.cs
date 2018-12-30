using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAnchor : MonoBehaviour
{
    new Collider collider;

    void Start()
    {
        this.collider = GetComponent<BoxCollider>();
    }

    public bool PlantSeed(GameObject plantPrefab)
    {
        GameObject plantObject = (GameObject)Instantiate(plantPrefab, transform.position, Quaternion.identity);
        plantObject.transform.SetParent(transform);

        Plant plant = plantObject.GetComponent<Plant>();
        plant.plantAnchor = this;

        this.EnablePlantAnchor(false);

        return true;
    }

    public void EnablePlantAnchor(bool enable)
    {
        this.collider.enabled = enable;
    }
}
