using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Makes the camera follow the camera along the x direction only
/// </summary>
public class CameraControl : MonoBehaviour
{

    public Transform player;
    public float leftLimit = 0;
    public float rightLimit = 43.45f;

    private Vector3 cameraStartPosition;


    void Start()
    {
        cameraStartPosition = transform.position;
    }

    void Update ()
    {
        if(player.position.x >= leftLimit && player.position.x <= rightLimit)
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);

        if(player.position.y >= cameraStartPosition.y)
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
    }
}
