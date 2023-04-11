using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 30.0f;
    [SerializeField] private float turnSpeed = 20;
    private float horizontaInput;
    private float forwardInput;

    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;

    public string inputID;

    // Start is called before the first frame update
    void Start()
    {
        hoodCamera.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontaInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);
        //move vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * forwardInput * speed);
        transform.Rotate(Vector3.up, turnSpeed * horizontaInput * Time.deltaTime);
        //transform.Translate(Vector3.right* Time.deltaTime * turnSpeed);

        if (Input.GetKeyDown(switchKey))
        {
        
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;

            /* if (active)
             {
                 mainCamera.enabled = true;//!mainCamera.enabled;
                 hoodCamera.enabled = false; // !hoodCamera.enabled;
             }
             else
             {
                 mainCamera.enabled = false;//!mainCamera.enabled;
                 hoodCamera.enabled = true; // !hoodCamera.enabled;
             }
            */
        }
    }
}
