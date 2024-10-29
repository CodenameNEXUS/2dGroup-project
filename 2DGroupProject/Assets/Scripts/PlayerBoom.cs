using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
    [SerializeField] private float damageAmount = 7f;
    private IDamageable idamageable;

    public Collider2D PlayerColl {  get; set; }
    private Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();

        IgnoreCollisionWithEnemyToggle();
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

    private void IgnoreCollisionWithEnemyToggle()
    {
        if (Physics2D.GetIgnoreCollision(coll, PlayerColl))
        {
            // turn on ignore collisions
            Physics2D.IgnoreCollision(coll, PlayerColl, true);
        }
        else
        {
            //turn OFF ignore collisions
            Physics2D.IgnoreCollision(coll, PlayerColl, false);
        }
    }
}
