using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public float growthTime = 4f;
    public int seedYield = 2;
    [HideInInspector] public PlantAnchor plantAnchor;
    public GameObject fruitObjects;

    new Collider collider;
    bool canBeHarvested;
    float startTime;

    void Start()
    {
        this.collider = GetComponent<BoxCollider>();
        this.collider.enabled = false;
        fruitObjects.SetActive(false);
        transform.localScale = Vector3.zero;
        startTime = Time.time;
    }

    void Update()
    {
        if (canBeHarvested) { return; }

        float currentTime = Time.time - startTime;

        if (currentTime <= growthTime)
        {
            float scale = currentTime / growthTime;
            transform.localScale = Vector3.one * scale;
        }

        else
        {
            this.collider.enabled = true;
            fruitObjects.SetActive(true);
            canBeHarvested = true;
        }
    }

    public int Harvest()
    {
        plantAnchor.EnablePlantAnchor(true);
        Destroy(gameObject);
        return seedYield;
    }
}
