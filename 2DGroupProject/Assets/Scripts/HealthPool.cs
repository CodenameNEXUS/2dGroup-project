using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPool : MonoBehaviour, IHeal
{
    [SerializeField] private float HealAmount = 7f;
    private IHeal iHealable;

    private Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        iHealable = collision.gameObject.GetComponent<IHeal>();
        if (iHealable != null)
        {
            //Damage
            iHealable.Heal(HealAmount);
        }
    }

    public void Heal(float HealAmount)
    {

    }
}
