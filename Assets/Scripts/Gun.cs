using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private BoxCollider gunTrigger;
    public EnemyManager enemyManager;

    // Layer Masks
    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;

    // Gun Ranges
    public float range = 20f;
    public float verticalRange = 20f;
    public float gunShotRadius = 20f;

    // Gun Damages
    public float bigDamage = 2f;
    public float smallDamage = 1f;

    // Gun Firerates
    public float fireRate = 1f;
    private float nextTimeToFire;

    // Gun Ammo
    public int maxAmmo;
    private int ammo;

    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * .5f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire && ammo > 0)
        {
            Fire();
        }
    }

    void Fire()
    {
        // simulate gun shot radius
        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);

        // alert any enemy in earshot
        foreach (var enemyCollider in enemyColliders)
        {
            enemyCollider.GetComponent<EnemyAwareness>().isAggro = true;
        }


        // stop test audio to remove overlapping
        GetComponent<AudioSource>().Stop();
        // play test audio
        GetComponent<AudioSource>().Play();

        // damage enemies found in trigger
        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            // get direction to enemy
            var dir = enemy.transform.position - transform.position;

            RaycastHit hit;

            if (Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
            {
                if (hit.transform == enemy.transform)
                {
                    // range check, used to determine damage in block below
                    float dist = Vector3.Distance(enemy.transform.position, transform.position);

                    if (dist > range * 0.5f)
                    {
                        // damage enemy small
                        enemy.TakeDamage(smallDamage);
                    }
                    else
                    {
                        // damage enemy big
                        enemy.TakeDamage(bigDamage);
                    }

                    //visibly checking the raycast
                    //Debug.DrawRay(transform.position, dir, Color.red);
                    //Debug.Break();
                }
            }
        }
        // reset timer
        nextTimeToFire = Time.time + fireRate;

        // deduct 1 ammo
        ammo--;
    }

    public void GiveAmmo(int amount, GameObject pickup)
    {
        if (ammo < maxAmmo)
        {
            ammo += amount;
            Destroy(pickup);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {

            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }

}
