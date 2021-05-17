using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public Animator doorAnim;
    public GameObject areaToSpawn;

    public bool reqRed, reqBlue, reqGreen;
    public bool requiresKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (requiresKey)
            { 
                // check player inventory for keys

                // Red Key
                if (reqRed && other.GetComponent<PlayerInventory>().hasRed)
                {
                    doorAnim.SetTrigger("DoorOpen");
                    areaToSpawn.SetActive(true);
                }

                // Green Key
                if (reqGreen && other.GetComponent<PlayerInventory>().hasGreen)
                {
                    doorAnim.SetTrigger("DoorOpen");
                    areaToSpawn.SetActive(true);
                }

                // Blue Key
                if (reqBlue && other.GetComponent<PlayerInventory>().hasBlue)
                {
                    doorAnim.SetTrigger("DoorOpen");
                    areaToSpawn.SetActive(true);
                }
            }
            else
            {
                doorAnim.SetTrigger("DoorOpen");
            }

            // spawn enemies in area
            areaToSpawn.SetActive(true);

        }
    }
}
