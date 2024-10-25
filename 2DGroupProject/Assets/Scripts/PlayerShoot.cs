using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    float bulletSpeed = 10f;
    [SerializeField]
    float bulletLifetime = 2.0f;
    float timer = 0;
    [SerializeField]
    float shootDelay = 0.5f;
    [SerializeField]
    float boomDelay = 0.5f;
    [SerializeField]
    GameObject rocket;
    [SerializeField]
    float rocketLifetime = 2.0f;
    [SerializeField]
    bool shoot = true;
    [SerializeField]
    bool boom = false;
    [SerializeField]
    float boomSpeed = 10f;
    [SerializeField]
    float SwapDelay = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //0.016667 = 60 fps
                                 //IF you click
        if (Input.GetKeyUp(KeyCode.E) && boom && timer > SwapDelay)
        {
            shoot = true;
            boom = false;
            timer = 0;
        }
        if (Input.GetKeyUp(KeyCode.E) && shoot && timer > SwapDelay)
        {
            shoot = false;
            boom = true;
            timer = boomDelay - 0.1f;
        }
        if (Input.GetButton("Fire1") && timer > shootDelay && shoot)
        {
            timer = 0; //reset timer
                       //shoot towrds mouse cursor
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            Vector3 mouseDir = mousePos - transform.position;
            //spawn bullet
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            //normalize the vector so we dont have wonky speeds
            mouseDir.Normalize();
            //push the bullet towards the mouse
            bullet.GetComponent<Rigidbody2D>().velocity = mouseDir * bulletSpeed;
            Destroy(bullet, bulletLifetime);
        }
        if (Input.GetButton("Fire1") && timer > boomDelay && boom)
        {
            timer = 0; //reset timer
                       //shoot towrds mouse cursor
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            Vector3 mouseDir = mousePos - transform.position;
            //spawn bullet
            GameObject bullet = Instantiate(rocket, transform.position, Quaternion.identity);
            //normalize the vector so we dont have wonky speeds
            mouseDir.Normalize();
            //push the bullet towards the mouse
            bullet.GetComponent<Rigidbody2D>().velocity = mouseDir * boomSpeed;
            Destroy(bullet, rocketLifetime);
        }
    }

    /*if (Input.GetButton("Fire1") && timer > shootDelay)
            {
                timer = 0; //reset timer
                           //shoot towrds mouse cursor
                Vector3 mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                mousePos.z = 0;
                Vector3 mouseDir = mousePos - transform.position;
                //spawn bullet
                GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
                //normalize the vector so we dont have wonky speeds
                mouseDir.Normalize();
                //push the bullet towards the mouse
                bullet.GetComponent<Rigidbody2D>().velocity = mouseDir * bulletSpeed;
                Destroy(bullet, bulletLifetime);
            }*/



}
