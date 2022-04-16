using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;
    Vector3 offset;
    private float speed = 10f;
    void Start()
    {
        player = FindObjectOfType<Movement>().GetComponent<Transform>();
        offset = transform.position-player.position;
    }


    void Update()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targerPos = player.position + offset;
        transform.localPosition = Vector3.Lerp(transform.position, targerPos, Time.deltaTime*speed);
    }
}
