using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        float vQueueSpeed = 0.2F;

        transform.Translate(Vector3.forward * vQueueSpeed);
    }
}
