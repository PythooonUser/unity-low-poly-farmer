using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float interactionRange = 10f;
    public LayerMask interactionLayermask;
    public PlayerInventory playerInventory;

    new Camera camera;

    void Start()
    {
        this.camera = GetComponent<Camera>();

        this.playerInventory.SetDefaultState();
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) { return; }

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, this.interactionRange, this.interactionLayermask))
        {
            if (hit.collider.tag == "Plant Anchor")
            {
                if (this.playerInventory.GetSeedAmount() > 0)
                {
                    PlantAnchor plantAnchor = hit.collider.GetComponent<PlantAnchor>();
                    plantAnchor.PlantSeed(this.playerInventory.GetPlantPrefab());
                    this.playerInventory.ReduceSeedAmount();
                }
            }

            else if (hit.collider.tag == "Plant")
            {
                Plant plant = hit.collider.GetComponent<Plant>();
                int seedYield = plant.Harvest();
                this.playerInventory.IncreaseSeedAmount(seedYield);
            }
        }
    }
}
