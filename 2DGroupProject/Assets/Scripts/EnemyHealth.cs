using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damge(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0) 
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    /*[SerializeField]
    float health = 10;
    float maxHP;
    Image healthBar;
    [SerializeField]
    float playerDamage = 1f;
    [SerializeField]
    float playerSnipeDMG = 10f;
    //reduce enemy health when hit by a player bullet
    //destroy the enemy if their health gets reduced to 0 or lower
    // Start is called before the first frame update
    void Start()
    {
        maxHP = health;
        //healthBar = GetComponentsInChildren<Image>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            health -= playerDamage;
            //healthBar.fillAmount = health / maxHP;
            if (health < 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Rocket")
        {
            health -= playerSnipeDMG;
            //healthBar.fillAmount = health / maxHP;
            if (health < 0)
            {
                Destroy(gameObject);
            }
        }
    }*/
    /*public void OnEnemyJustDied()
    {
        if (Random.Range(0f, 1f) <= m_dropChance)
        {
            // spawn a dropped item
        }
    }*/

    //const float m_dropChance = 1f / 10f;  
    // Set odds here - e.g. 1 in 10 chance.
}
