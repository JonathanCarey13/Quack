using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        target = FindObjectOfType<PlayerMovementBehavior>().transform;
    }

    void Update()
    {
        transform.LookAt(target);
    }
}
