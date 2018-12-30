using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int seedYield = 2;
    [HideInInspector] public PlantAnchor plantAnchor;

    public int Harvest()
    {
        plantAnchor.EnablePlantAnchor(true);
        Destroy(gameObject);
        return seedYield;
    }
}
