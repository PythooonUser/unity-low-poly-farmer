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
    }

    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, this.interactionRange, this.interactionLayermask))
        {
            if (hit.collider.tag == "Field")
            {
                if (this.playerInventory.GetSeedAmount() > 0)
                {
                    Field field = hit.collider.GetComponent<Field>();
                    field.PlantSeed();
                    this.playerInventory.ReduceSeedAmount();
                }
            }
        }
    }
}
