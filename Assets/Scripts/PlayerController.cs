using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speed2;
    [SerializeField] private float rpm;
    [SerializeField] private float rpm2;
    [SerializeField] private float horsePower;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] TextMeshProUGUI speedometerText2;
    [SerializeField] TextMeshProUGUI rpmText2;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private float turnSpeed = 20;
    private float horizontaInput;
    private float forwardInput;

    public AudioSource sfx;
    public AudioSource music;
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;

    private Rigidbody playerRb;

    public string inputID;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        hoodCamera.enabled = false;
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
        music.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontaInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        if (IsOnGround())
        {
            //move vehicle forward
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower * (playerRb.velocity.magnitude < 0.1f ? 10f : 1f));
            //transform.Translate(Vector3.forward * Time.deltaTime * forwardInput * speed);
            transform.Rotate(Vector3.up, turnSpeed * horizontaInput * Time.deltaTime);
            //transform.Translate(Vector3.right* Time.deltaTime * turnSpeed);

            if (inputID == "1")
            {
                speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
                speedometerText.SetText("Speed:" + speed + "Km/h");

                rpm = (speed % 30) * 35;
                rpmText.SetText("RPM: " + rpm);
            }
            else if (inputID == "2")
            {
                speed2 = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
                speedometerText2.SetText("Speed:" + speed2 + "Km/h");

                rpm2 = (speed2 % 30) * 35;
                rpmText2.SetText("RPM: " + rpm2);
            }
        }

        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }
    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "car")
        {
            sfx.Play();
        }
    }
}
