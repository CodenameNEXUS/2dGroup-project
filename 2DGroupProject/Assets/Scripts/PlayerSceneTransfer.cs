using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerSceneTransfer : MonoBehaviour
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

        menu = GameObject.FindGameObjectWithTag("menu");
        player = GameObject.FindGameObjectWithTag("Player");
        SpawnPos = GameObject.FindGameObjectWithTag("SpawnPos");
        if (player != null)
        {
            OriginalPlayer = true;
        }
        menu = GameObject.FindGameObjectWithTag("menu");
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
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(levelToLoad);
            gameObject.transform.position = SpawnPos.transform.position;
        }*/
    }
    void Awake()
    {
            if (tag == "Player")
            {
                DontDestroyOnLoad(this.gameObject);
            }
        SpawnPos = GameObject.FindGameObjectWithTag("SpawnPos");
        gameObject.transform.position = SpawnPos.transform.position;
    }
    private void OnLevelWasLoaded(int level)
    {
        
        menu = GameObject.FindGameObjectWithTag("menu");
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
        menu = GameObject.FindGameObjectWithTag("menu");
    }
}
