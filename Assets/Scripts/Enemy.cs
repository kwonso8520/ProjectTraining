using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private EnemyData enemyData;
    public EnemyData EnemyData { set{ enemyData = value; } }
    private Rigidbody2D rigid;
    public int nextMove;
    SpriteRenderer spriteRenderer;
    [SerializeField]LayerMask layerMask;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("Think", 5);
    }

    private void FixedUpdate()
    {
        //Move
        rigid.velocity = new Vector3 (nextMove, rigid.velocity.y);

        //Platform Check
        Vector2 frontVec = new Vector2 (rigid.position.x + nextMove * 0.2f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down * enemyData.Height, new Color(0, 1, 0));
        RaycastHit2D hit = Physics2D.Raycast(frontVec, Vector3.down, enemyData.Height, layerMask);
        if(hit.collider == null)
        {
            Turn();
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
    private void Turn()
    {
        Debug.Log("경고! 이앞에 길없음");
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;

        CancelInvoke();
        Invoke("Think", 2);
    }
}