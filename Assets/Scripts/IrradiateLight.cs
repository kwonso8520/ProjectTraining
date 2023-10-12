using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrradiateLight : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private float lightDamage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemy.TakeDamage(lightDamage);
        }
    }
}
