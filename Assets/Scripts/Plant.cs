using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public Vector2 growthTimeMinMax = new Vector2(8f, 14f);
    public Vector2 scaleMinMax = new Vector2(0.95f, 1.05f);
    public Vector2 seedYieldMinMax = new Vector2(2, 6);

    [HideInInspector] public PlantAnchor plantAnchor;
    public GameObject fruitObjects;

    new Collider collider;
    bool canBeHarvested;
    float growthTime;
    float scale;
    int seedYield;
    float startTime;

    void Start()
    {
        this.collider = GetComponent<BoxCollider>();
        this.collider.enabled = false;
        this.fruitObjects.SetActive(false);
        transform.localScale = Vector3.zero;
        this.startTime = Time.time;

        this.growthTime = Random.Range(this.growthTimeMinMax.x, this.growthTimeMinMax.y);
        this.scale = Random.Range(this.scaleMinMax.x, this.scaleMinMax.y);
        this.seedYield = Random.Range((int)this.seedYieldMinMax.x, (int)this.seedYieldMinMax.y + 1);

        transform.localRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
    }

    void Update()
    {
        if (this.canBeHarvested) { return; }

        float currentTime = Time.time - this.startTime;

        if (currentTime <= this.growthTime)
        {
            float currentScale = currentTime / this.growthTime;
            transform.localScale = Vector3.one * Mathf.Lerp(0f, this.scale, currentScale);
        }

        else
        {
            this.collider.enabled = true;
            this.fruitObjects.SetActive(true);
            this.canBeHarvested = true;
        }
    }

    public int Harvest()
    {
        this.plantAnchor.EnablePlantAnchor(true);
        Destroy(gameObject);
        return this.seedYield;
    }
}
