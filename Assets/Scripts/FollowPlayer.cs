using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -7);

    // Update is called once per frame
    void LateUpdate()//late update will do all position calculations before updating
    {
        //offset the camera behind the the player by adding to the player's position
        transform.position = player.transform.position + offset;
    }
}
