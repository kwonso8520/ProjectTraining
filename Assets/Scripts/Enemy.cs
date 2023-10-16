using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemyData;
    public EnemyData EnemyData { set{ enemyData = value; } }
    private Rigidbody2D rigid;
    public int nextMove;
    SpriteRenderer spriteRenderer;
    [SerializeField]
    LayerMask layerMask;
    private float time;
    [SerializeField]
    private float fadeTime;
    public float enemyHp;
    private Collider2D col;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyHp = enemyData.Hp;
        col = GetComponent<Collider2D>();
        Invoke("Think", 5);
    }

    private void FixedUpdate()
    {
        //Move
        rigid.velocity = new Vector3 (nextMove * enemyData.MoveSpeed, rigid.velocity.y);
            
        //Platform Check
        Vector2 frontVec = new Vector2 (rigid.position.x + nextMove * 0.2f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down * enemyData.Height, new Color(0, 1, 0));
        RaycastHit2D hit = Physics2D.Raycast(frontVec, Vector3.down, enemyData.Height, layerMask);
        if(hit.collider == null)
        {
            Turn();
        }
    }
    private void Update()
    {
        if (enemyHp <= 0)
        {
            Disapear();
        }
    }
    private void Think()
    {
        //set new action
        nextMove = Random.Range(-1, 2);

        //flip sprite
        if(nextMove != 0)
        {
            spriteRenderer.flipX = nextMove == 1;
        }
        float thinkTime = Random.Range(2f, 5f);
        Invoke("Think", thinkTime);
    }
    public void TakeDamage(float damage)
    {
        enemyHp = enemyHp - damage;
    }
    private void Turn()
    {
        Debug.Log("경고! 이앞에 길없음");
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;

        CancelInvoke();
        Invoke("Think", 2);
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