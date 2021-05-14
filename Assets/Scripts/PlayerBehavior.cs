using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public int maxHealth;
    private int health;

    public int maxArmor;
    private int armor;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        // temporary test function
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            DamagePlayer(30);
            Debug.Log("Player hurt.");
        }
    }

    public void DamagePlayer(int damage)
    {
        // if the player has armor, damage it instead
        if (armor > 0)
        {
            if (armor >= damage)    // if the player has enough armor to absorb all the damage, then only damage the armor
            {
                armor -= damage;
            }
            else if (armor < damage)    //if the player only has enough armor to absorb some of the damage, then damage the armor first and then the player
            {
                int remainingDamage;

                remainingDamage = damage - armor;

                armor = 0;

                health -= remainingDamage;
            }
        }
        else
        {
            health -= damage;
        }

        if (health <= 0)
        {
            Debug.Log("Player died.");

            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }

    public void GiveHealth(int amount, GameObject pickup)
    {
        if (health < maxHealth)
        {
            health += amount;
            Destroy(pickup);
        }

        // stops health going over max health
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void GiveArmor(int amount, GameObject pickup)
    {
        if (armor < maxArmor)
        {
            armor += amount;
            Destroy(pickup);
        }

        // stops armor going over max armor
        if (armor > maxArmor)
        {
            armor = maxArmor;
        }
    }

}
