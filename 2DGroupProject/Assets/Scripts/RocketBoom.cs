using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class RocketBoom : MonoBehaviour
{
    [SerializeField] GameObject Explosion;

    [SerializeField] float boomLifeTime = 0.1f;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        timer += Time.deltaTime;
        if (collision.gameObject)
        {
            Destroy(gameObject);
            GameObject bullet = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(bullet, boomLifeTime);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        timer += Time.deltaTime;
        if (collision.gameObject)
        {
            Destroy(gameObject);
            GameObject bullet = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(bullet, boomLifeTime);
        }
    }

}
