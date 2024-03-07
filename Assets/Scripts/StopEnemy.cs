using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopEnemy : MonoBehaviour
{
    private bool rushTrigger = false;
    private Transform playerPos;
    private Vector2 direction;
    [SerializeField]
    private EnemyData enemyData;
    public EnemyData EnemyData { set { enemyData = value; } }
    private Collider2D col;
    private float time;
    [SerializeField]
    private float fadeTime;
    public float enemyHp;
    private void Awake()
    {
        playerPos = GameObject.Find("Player").transform;
        enemyHp = enemyData.Hp;
        col = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (rushTrigger)
        {
            direction = (playerPos.position - transform.position);
            direction.Normalize();
            GetComponent<Rigidbody2D>().AddForce(direction * enemyData.MoveSpeed);
            Invoke("Disapear", 1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            rushTrigger = true;
        }
    }
    public void TakeDamage(float damage)
    {
        enemyHp = enemyHp - damage;
    }
    private void Disapear()
    {
        col.enabled = false;
        if (time < fadeTime)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f - time / fadeTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
        time += Time.deltaTime;
    }
}
