using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    float chaseSpeed = 5.0f;
    [SerializeField]
    float chaseTriggerDistance = 10f;
    [SerializeField]
    bool goHome = true;
    Vector3 homePosition;
    [SerializeField]
    float homeSpeed = 5f;
    [SerializeField]
    float homeDistance = 13f;
    Rigidbody2D rb;
    public Animator animator;
    float timer = 0;
    public float delayTime = 0.25f;
    bool spotted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        homePosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //the chase direction is destination - enemy starting position
        Vector3 playerPosition = player.transform.position;
        Vector3 chaseDir = playerPosition - transform.position;
        Vector3 homeDir = homePosition - transform.position;
        if (chaseDir.magnitude < chaseTriggerDistance)
        {
            if (rb.velocity == Vector2.zero && timer < delayTime && !spotted)
            {
                animator.SetTrigger("Spot");
                Debug.Log("foo");
                spotted = true;
                timer = 0;
            }
            else
            {

                //move towards the player
                chaseDir.Normalize();
                rb.velocity = chaseDir * chaseSpeed;
            }
            
        }
        else if (goHome)
        {
            if (homeDir.magnitude < 0.1f)
            {
                transform.position = homePosition;
                rb.velocity = Vector3.zero;
                timer = 0;

            }
            else
            {
                homeDir.Normalize();
                rb.velocity = homeDir * homeSpeed;
                timer = 0;

            }
        }
        else if (chaseDir.magnitude > chaseTriggerDistance)
        {
            //if the player is NOT close, stop moving
            rb.velocity = Vector3.zero;
            spotted = false;
            
        }
        animator.SetFloat("x", rb.velocity.x);
        animator.SetFloat ("y", rb.velocity.y);

    }
    
}
