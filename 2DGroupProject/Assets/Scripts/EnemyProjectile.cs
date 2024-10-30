using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour, IDamageable
{
    [SerializeField] private float damageAmount = 7f;
    private IDamageable idamageable;

    public Collider2D EnemyColl { get; set; }
    private Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        idamageable = collision.gameObject.GetComponent<IDamageable>();
        if (idamageable != null)
        {
            //Damage
            idamageable.Damage(damageAmount);
        }
    }

    

    public void Damage(float damageAmount)
    {
        
    }
}
