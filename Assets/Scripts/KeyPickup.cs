using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public bool isRedKey, isGreenKey, isBlueKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isRedKey)
            {
                other.GetComponent<PlayerInventory>().hasRed = true;
            }

            if (isBlueKey)
            {
                other.GetComponent<PlayerInventory>().hasBlue = true;
            }

            if (isGreenKey)
            {
                other.GetComponent<PlayerInventory>().hasGreen = true;
            }

            Destroy(gameObject);
        }
    }
}
