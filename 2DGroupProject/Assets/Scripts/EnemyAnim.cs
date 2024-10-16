using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            float xVelocity = Input.GetAxis("Horizontal");
            float yVelocity = Input.GetAxis("Vertical");
            GetComponent<Animator>().SetFloat("x", xVelocity);
            GetComponent<Animator>().SetFloat("y", yVelocity);
        }
    }
}
