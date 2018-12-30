using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float interactionRange = 10f;
    public LayerMask interactionLayermask;

    new Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange, interactionLayermask))
        {
            if (hit.collider.tag == "Field")
            {
                Field field = hit.collider.GetComponent<Field>();
                field.PlantSeed();
            }
        }
    }
}
