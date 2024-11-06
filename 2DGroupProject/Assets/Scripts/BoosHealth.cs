using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;

    [SerializeField]
    GameObject door;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            GameObject End = Instantiate(door, transform.position, Quaternion.identity);
            Die();

        }
    }

    private void Die()
    {
        
        Destroy(gameObject);
    }
}
