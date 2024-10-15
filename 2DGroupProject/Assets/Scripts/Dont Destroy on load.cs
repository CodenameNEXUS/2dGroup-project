using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyonload : MonoBehaviour
{
    GameObject SpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPos = GameObject.FindGameObjectWithTag("SpawnPos");
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
    }
    private void OnLevelWasLoaded(int level)
    {
        SpawnPos = GameObject.FindGameObjectWithTag("SpawnPos");
        gameObject.transform.position = SpawnPos.transform.position;
    }
}
