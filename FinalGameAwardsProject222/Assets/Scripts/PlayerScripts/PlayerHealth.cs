using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 100;
    float currentHealth;

    [HideInInspector]
    public bool isDead = false;

	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHealth;
	}

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        if(currentHealth <= 0)
        {
            isDead = true;
        }
    }

    public void Respawn(Transform spawnPoint)
    {
        transform.position = spawnPoint.position;
        currentHealth = maxHealth;
        isDead = false;
    }
}
