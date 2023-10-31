using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrradiateLight : MonoBehaviour
{
    [SerializeField] private float lightDamage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
                collision.GetComponent<Enemy>().TakeDamage(lightDamage);
        }
        else if (collision.CompareTag("StopEnemy"))
        {
            collision.GetComponent <StopEnemy>().TakeDamage(lightDamage);
        }
    }
}