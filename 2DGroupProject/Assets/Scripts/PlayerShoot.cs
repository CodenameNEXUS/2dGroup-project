using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    bool TF4 = false;
    bool TF3 = false;
    bool TF2 = false;
    bool TF1 = false;
    [SerializeField]
    string levelToLoad = "Space";

    [SerializeField] Image Gun;

    [SerializeField] Image Rocketlauncher;

    // Start is called before the first frame update
    void Start()
    {
        Gun.enabled = true;
        Rocketlauncher.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        

        timer += Time.deltaTime; //0.016667 = 60 fps
                                 //IF you click
        if (Input.GetKeyUp(KeyCode.E) && boom && timer > SwapDelay)
        {
            shoot = true;
            boom = false;
            timer = 0;
            Gun.enabled = true;
            Rocketlauncher.enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.E) && shoot && timer > SwapDelay && TF1 && TF2)
        {
            shoot = false;
            boom = true;
            timer = boomDelay - 0.1f;
            Gun.enabled = false;
            Rocketlauncher.enabled = true;
        }
        if (Input.GetButton("Fire1") && timer > shootDelay && shoot)
        {
            Gun.enabled = true;
            Rocketlauncher.enabled = false;
            timer = 0; //reset timer
                       //shoot towrds mouse cursor
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            Vector3 mouseDir = mousePos - transform.position;
            //spawn bullet
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            bullet.transform.right = mouseDir;
            //normalize the vector so we dont have wonky speeds
            mouseDir.Normalize();
            //push the bullet towards the mouse
            bullet.GetComponent<Rigidbody2D>().velocity = mouseDir * bulletSpeed;
            Destroy(bullet, bulletLifetime);
            
        }
        if (Input.GetButton("Fire1") && timer > boomDelay && boom && TF1 && TF2)
        {
            Gun.enabled = false;
            Rocketlauncher.enabled = true;
            timer = 0; //reset timer
                       //shoot towrds mouse cursor
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            Vector3 mouseDir = mousePos - transform.position;
            //spawn bullet
            GameObject bullet = Instantiate(rocket, transform.position, Quaternion.identity);
            bullet.transform.right = mouseDir;
            //normalize the vector so we dont have wonky speeds
            mouseDir.Normalize();
            //push the bullet towards the mouse
            bullet.GetComponent<Rigidbody2D>().velocity = mouseDir * boomSpeed;
            Destroy(bullet, rocketLifetime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rocket1")
        {
            TF1 = true;
        }
        if (collision.gameObject.tag == "rocket2")
        {
            TF2 = true;
        }
        if (collision.gameObject.tag == "rocket3")
        {
            TF3 = true;
        }
        if (TF1 && TF2 && TF3)
        {
            TF4 = true;
            Debug.Log("TF4");
        }
        if (collision.gameObject.tag == "rocketHome" && TF4 == true)
        {
            
            SceneManager.LoadScene(levelToLoad);
        }
        if (collision.gameObject.tag == "End")
        {
            SceneManager.LoadScene(levelToLoad);
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
