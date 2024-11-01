using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class DontDestroyonload : MonoBehaviour
{
    GameObject SpawnPos;
    GameObject menu;
    GameObject player;
    Component Renderer;

    public string levelToLoad = "Landon TEST";
    public bool OriginalPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu");
        player = GameObject.FindGameObjectWithTag("Player");
        SpawnPos = GameObject.FindGameObjectWithTag("SpawnPos");
        if (player != null)
        {
            OriginalPlayer = true;
        }
        menu = GameObject.FindGameObjectWithTag("Menu");
        if (menu != null)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponentInChildren<Canvas>().enabled = false;
        }
        if (menu == null)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponentInChildren<Canvas>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Awake()
    {
        if (tag == "Player")
        {
            DontDestroyOnLoad(this.gameObject);
        }
        SpawnPos = GameObject.FindGameObjectWithTag("SpawnPos");
        gameObject.transform.position = SpawnPos.transform.position;

        if (OriginalPlayer == false)
        {
            Destroy(gameObject);

        }
    }
    private void OnLevelWasLoaded(int level)
    {
        menu = GameObject.FindGameObjectWithTag("Menu");
        if (menu != null)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponentInChildren<Canvas>().enabled = false;
        }
        if (menu == null)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponentInChildren<Canvas>().enabled = true;
        }
        if (OriginalPlayer == false)
        {
            Destroy(gameObject);
            
        }
        SpawnPos = GameObject.FindGameObjectWithTag("SpawnPos");
        gameObject.transform.position = SpawnPos.transform.position;
        menu = GameObject.FindGameObjectWithTag("Menu");
    }
}
