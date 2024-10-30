using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable, IHeal
{
    [SerializeField] private float maxhealth = 100f;

    [SerializeField]
    Image healthBar;

    float timer;

    [SerializeField]float iframes;

    private float currentHealth;

    private knockback knockback;

    private void Start()
    {
        timer += Time.deltaTime;
        currentHealth = maxhealth;
        knockback = GetComponent<knockback>();
        healthBar.fillAmount = currentHealth / maxhealth;
    }


    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
        
        healthBar.fillAmount = currentHealth - damageAmount;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        knockback.callKnockback(transform.right, Vector2.up, Input.GetAxisRaw("Horizontal"));
        
    
    }

    public void Heal(float HealAmount)
    {
        currentHealth += HealAmount;

        healthBar.fillAmount = currentHealth - HealAmount;
        if (currentHealth >= 101)
        {
            currentHealth = 100;
        }


    }










    /*[SerializeField]
    float health = 100;
    [SerializeField]
    string levelToLoad = "Lose";
    float maxHP;
    [SerializeField]
    Image healthBar;
    [SerializeField]
    float bossDamage = 100f;
    [SerializeField]
    float gruntDamage = 20f;
    [SerializeField]
    float enemyBulletDMG = 5f;
    [SerializeField]
    float heal = 5f;
    [SerializeField]
    float biteDMG = 5f;
    [SerializeField]
    float hazardDMG = 5f;

    private knockback knockback;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = health;
        healthBar.fillAmount = health / maxHP;

        knockback = GetComponent<knockback>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        //IF we hit an enemy, reduce player HP
        if(collision.gameObject.tag == "enemy")
        {
            health -= gruntDamage;
            healthBar.fillAmount = health / maxHP;
            //add consequences
            //IF health gets to low reload current level
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene(levelToLoad);
            }
        }
        if (collision.gameObject.tag == "boss")
        {
            health -= bossDamage;
            healthBar.fillAmount = health / maxHP;
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpawnPos")
        {
            health += 100;
            healthBar.fillAmount = health / maxHP;
            if(health > 100)
            {
                health = 100;
                healthBar.fillAmount = health / maxHP;
            }
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            health -= enemyBulletDMG;
            healthBar.fillAmount = health / maxHP;
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }
        }
        if (collision.gameObject.tag == "EnemyBite")
        {
            health -= biteDMG;
            healthBar.fillAmount = health / maxHP;
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }
        }
        if (collision.gameObject.tag == "Hazards")
        {
            health -= hazardDMG;
            healthBar.fillAmount = health / maxHP;
            //add consequences
            //IF health gets to low reload current level
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene(levelToLoad);
            }
        }
        
    }*/
}
