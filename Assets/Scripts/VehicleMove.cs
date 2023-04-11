using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMove : MonoBehaviour
{
    //private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // verticalInput = Input.GetAxis("Vertical");
        float vQueueSpeed = 0.1F;

        transform.Translate(Vector3.forward * vQueueSpeed);
    }
}
