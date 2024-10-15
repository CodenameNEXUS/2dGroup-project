using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketCollection : MonoBehaviour
{
    bool TF4 = false;
    bool TF3 = false;
    bool TF2 = false;
    bool TF1 = false;
    [SerializeField]
    string levelToLoad = "Space";
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
            Debug.Log("you win for now");
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
