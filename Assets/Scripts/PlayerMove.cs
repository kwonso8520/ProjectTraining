using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float jumpPower = 3.0f;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField] 
    private Transform foot;
    private Rigidbody2D rigid;
    bool isGrounded = false;
    [SerializeField]
    private GameObject gameOverText;
    [SerializeField]
    private GameObject gauge;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public Camera camera;
    public Transform head;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        gauge.transform.position = camera.WorldToScreenPoint(head.position + new Vector3(0,1.3f,0));
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(h, 0, 0);
        animator.SetFloat("Speed", Mathf.Abs(h));
        if(h < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        transform.Translate(dir * speed * Time.deltaTime);
        isGrounded = Physics2D.OverlapCircle(foot.position, 0.1f, groundLayer);
    }
    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0f);
        rigid.AddForce(Vector3.up * jumpPower,ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Die();
        }
    }
    private void Die()
    {
        gameOverText.SetActive(true);
        gauge.SetActive(false);
        Destroy(gameObject);
    }
}