using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript4 : MonoBehaviour
{

    private Transform player;

    public Vector3 min;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && GameObject.Find("Player").GetComponent<PlayerScript3>().isAlive)
        {
            Vector3 temp = transform.position;
            temp.y = player.position.y;
            transform.position = temp;
        }
    }
}
//CameraFollow