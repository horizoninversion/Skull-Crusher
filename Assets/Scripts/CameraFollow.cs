using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

//Late update is used because we want the camera to move after the player moves.
    void LateUpdate()
    {
        Vector3 camPos = transform.position;
        camPos.x = player.position.x;
        camPos.y = player.position.y;
        transform.position = camPos;
    }
}
