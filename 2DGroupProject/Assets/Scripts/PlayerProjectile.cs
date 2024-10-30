using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour, IDamageable
{
    [SerializeField] private float damageAmount = 7f;
    private IDamageable idamageable;

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
