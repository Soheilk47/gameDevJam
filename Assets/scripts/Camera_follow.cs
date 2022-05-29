using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset = new Vector3(0, 0.14f, -1);

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position + offset, 5f * Time.deltaTime);
    }
}