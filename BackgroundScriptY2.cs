using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScriptY2 : MonoBehaviour
{

    private Transform player;

    //public float minX, maxX;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && GameObject.Find("Player").GetComponent<PlayerScript22>().isAlive)
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x / 2;
            transform.position = temp;
        }
        if (player != null && GameObject.Find("Player").GetComponent<PlayerScript22>().isAlive)
        {
            Vector3 temp = transform.position;
            temp.y = player.position.y;
            transform.position = temp;
        }
    }
}
