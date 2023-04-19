using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarDownStreet : MonoBehaviour
{
    public TextMeshProUGUI winText;
    public PlayerController playerController;
    void Start()
    {
        if (playerController.name == "Player2")
        {
            playerController = GameObject.Find("Player2").GetComponent<PlayerController>();            
        }
        else
        {
            playerController = GameObject.Find("Player1").GetComponent<PlayerController>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            if (transform.position.z > 184)
            {
                winText.SetText("Player" + playerController.inputID +  "Wins") ;
                Invoke(nameof(RestartGame), 1);
            }
            else
            {
                transform.rotation = Quaternion.identity;
                transform.position = new Vector3(0, 0.04f, transform.position.z);
                gameObject.SetActive(false);
                gameObject.SetActive(true);
                gameObject.SetActive(false);
                gameObject.SetActive(true);
            }
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Prototype 1");
    }
}
