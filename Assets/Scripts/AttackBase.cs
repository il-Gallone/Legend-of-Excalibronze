using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
    public int damage;
    public int critcalDamage;
    public bool isCritical = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if (isCritical)
            {
                collision.gameObject.GetComponent<EnemyBase>().OnDamaged(critcalDamage);
            }
            else
            {
                collision.gameObject.GetComponent<EnemyBase>().OnDamaged(damage);
            }
        }
    }
}
