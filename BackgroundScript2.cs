using UnityEngine;
using System.Collections;

public class BackgroundScript2 : MonoBehaviour
{

    private Transform player;

    //public float minX, maxX;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player (1)").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && GameObject.Find("Player (1)").GetComponent<PlayerScript22>().isAlive)
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x / 2;
            transform.position = temp;
        }
        if (player != null && GameObject.Find("Player (1)").GetComponent<PlayerScript22>().isAlive)
        {
            Vector3 temp = transform.position;
            temp.y = player.position.y;
            transform.position = temp;
        }
    }
}
//CameraFollow