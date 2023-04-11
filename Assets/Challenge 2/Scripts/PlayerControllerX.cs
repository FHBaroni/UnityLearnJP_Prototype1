using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    // Update is called once per frame
    public float timeInterval;
     
    void Update()
    {
        timeInterval += Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && timeInterval > 1)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            timeInterval = 0;
        }
    }
}
