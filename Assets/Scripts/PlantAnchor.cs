using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAnchor : MonoBehaviour
{
    new Collider collider;

    void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    public bool PlantSeed(GameObject plantPrefab)
    {
        GameObject plant = (GameObject)Instantiate(plantPrefab, transform.position, Quaternion.identity);
        plant.transform.SetParent(transform);

        EnablePlantAnchor(false);

        return true;
    }

    void EnablePlantAnchor(bool enable)
    {
        collider.enabled = enable;
    }
}
