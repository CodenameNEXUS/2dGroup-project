using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    
    [SerializeField]
    float bulletSpeed = 10f;
    [SerializeField]
    float bulletLifetime = 2.0f;
    private float timer = 0;
    [SerializeField]
    private float shootDelay = 0.5f;
    GameObject player;
    [SerializeField]
    float shootDistance = 5;
    [SerializeField] private Rigidbody2D bulletPrefab;


    private Rigidbody2D bulletRB;

    private EnemyProjectile enemyProjectile;

    private Collider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // if a player get within a certain distance
        Vector3 shootDir = player.transform.position - transform.position;
        if(shootDir.magnitude < shootDistance && timer > shootDelay)
        {
            // shoot towards the player
            //spawn the bullet
            shoot();
            // delay the next bullet
            Destroy(bulletPrefab, bulletLifetime);
        }
    }
    private void shoot()
    {
        bulletRB = Instantiate(bulletPrefab, transform.position, transform.rotation);
        //push the bullet towrads the player
        
        bulletRB.velocity = bulletRB.transform.right * bulletSpeed;

        enemyProjectile = bulletRB.gameObject.GetComponent<EnemyProjectile>();

        enemyProjectile.EnemyColl = coll;

        timer = 0;
    }
}
