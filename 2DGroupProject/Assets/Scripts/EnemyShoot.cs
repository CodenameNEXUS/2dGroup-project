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
    GameObject enemybullet;
    [SerializeField]
    float shootDistance = 5;
    
    
    


    

    private EnemyProjectile enemyProjectile;



    // Start is called before the first frame update
    void Start()
    {
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

        }
    }
    private void shoot()
    {
        
        timer += Time.deltaTime;
        GameObject bullet = Instantiate(enemybullet, transform.position, Quaternion.identity);
        //push the bullet towrads the player

        bullet.GetComponent<Rigidbody2D>().transform.right = GetShootDir();

        bullet.GetComponent<Rigidbody2D>().velocity = bullet.GetComponent<Rigidbody2D>().transform.right * bulletSpeed;
        
        enemyProjectile = bullet.GetComponent<Rigidbody2D>().gameObject.GetComponent<EnemyProjectile>();

        timer = 0;
        Destroy(bullet, bulletLifetime);
    }

    public Vector2 GetShootDir()
    {
        Transform playerTrans = GameObject.FindGameObjectWithTag("Player").transform;

        return (playerTrans.position - transform.position).normalized;
    }
}
