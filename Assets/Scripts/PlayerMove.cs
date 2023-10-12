using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float jumpPower = 3.0f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform foot;
    private Rigidbody2D rigid;
    bool isGrounded = false;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(h, 0, 0);
        transform.Translate(dir * speed * Time.deltaTime);
        isGrounded = Physics2D.OverlapCircle(foot.position, 0.1f, groundLayer);
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }
    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0f);
        rigid.AddForce(Vector3.up * jumpPower,ForceMode2D.Impulse);
    }
}
