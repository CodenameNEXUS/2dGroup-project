using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockback : MonoBehaviour
{
    public float knockbacktime = 0.2f;
    public float hitDiretionForce = 10f;
    public float constForce = 5f;
    public float inputForce = 7.5f;

    private Rigidbody2D rb;

    private Coroutine KnockbackCoroutine;
    public bool IsBeingKnockedBack {  get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public IEnumerator KnockbackAction(Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection)
    {
        IsBeingKnockedBack = true;

        Vector2 _hitforce;
        Vector2 _constantForce;
        Vector2 _knockbackForce;
        Vector2 _combinedForce;

        _hitforce = hitDirection * hitDiretionForce;
        _constantForce = constantForceDirection * constForce;

        float _elapsedTime = 0f;
        while(_elapsedTime < knockbacktime)
        {
            // iterate the timer
            _elapsedTime += Time.fixedDeltaTime;

            //combine _hitforce and _constForce
            _knockbackForce = _hitforce + _constantForce;

            //combine Knockback with input force
            if (inputDirection != 0)
            {
                _combinedForce = _knockbackForce + new Vector2(inputDirection * inputForce, 0f);
            }
            else
            {
                _combinedForce = _knockbackForce;
            }

            //apply knockback
            rb.velocity = _combinedForce;

            yield return new WaitForFixedUpdate();
        }
        IsBeingKnockedBack = false;
    }

    public void callKnockback(Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection)
    {
        KnockbackCoroutine = StartCoroutine(KnockbackAction(hitDirection, constantForceDirection, inputDirection));
    }

}
