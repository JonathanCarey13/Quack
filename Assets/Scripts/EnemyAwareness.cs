using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public float awarenessRadius = 5f;
    public Material aggroMat;
    public bool isAggro;
    private Transform playersTransform;

    private void Start()
    {
        // finds the players position
        playersTransform = FindObjectOfType<PlayerMovementBehavior>().transform;
    }


    private void Update()
    {
        // creates a distance for the enemy to use in reaching the player
        var dist = Vector3.Distance(transform.position, playersTransform.position);

        if (dist < awarenessRadius)
        {
            isAggro = true;
        }

        if (isAggro)
        {
            GetComponent<MeshRenderer>().material = aggroMat;
        }
    }
}
