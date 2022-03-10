using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    //Public fields
    public int hitPoint = 10;
    public int maxHitPooint = 10;
    public float pushRecoverySpeed = 0.2f;
    //Imunity
    protected float immuneTime = 1f;
    protected float lastImmune;
    //Push
    protected Vector3 pushDirection;

    //All fighters can RecieveDamage / Die
    protected virtual void RecieveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitPoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            //Visual effect when you have been hit
            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 15, Color.red, transform.position, Vector3.zero, 0.5f);

            if(hitPoint <= 0)
            {
                hitPoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {
        
    }
}
