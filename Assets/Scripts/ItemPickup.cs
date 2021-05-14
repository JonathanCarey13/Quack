using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public bool isHealth;
    public bool isArmor;
    public bool isAmmo;

    public int amount;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isHealth)
            {
                other.GetComponent<PlayerBehavior>().GiveHealth(amount, this.gameObject);
            }
            if (isArmor)
            {
                other.GetComponent<PlayerBehavior>().GiveArmor(amount, this.gameObject);
            }
            if (isAmmo)
            {
                other.GetComponentInChildren<Gun>().GiveAmmo(amount, this.gameObject);
            }
        }
    }

}
