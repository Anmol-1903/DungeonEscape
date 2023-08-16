using UnityEngine;
using System.Collections;
public class Movement : MonoBehaviour
{
    [SerializeField] float _speed = 500f;
    [SerializeField] float _jumpForce = 5f;
    [SerializeField] float _waitTillNextJump = .1f;
    [SerializeField] LayerMask _groundLayer;

    bool _isGrounded = false;
    bool _canJump = false;
    Rigidbody2D Rb;
    Animator anim;
    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        Move();
        if(Input.GetMouseButtonDown(0) && _isGrounded)
        {
            Attack();
        }

        _isGrounded = GroundCheck();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && _canJump)
        {
            Jump();
            _isGrounded = false;
        }
    }
    private bool GroundCheck()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.down, transform.localScale.y * .8f, _groundLayer.value);
        Debug.DrawRay(transform.position, Vector2.down * transform.localScale.y * 0.8f, Color.green);
        if (raycastHit2D.collider != null)
        {
            return true;
        }
        return false;
    }
    private void Move()
    {
        float _horizontal = Input.GetAxisRaw("Horizontal");
        if(_horizontal != 0)
        {
            anim.SetFloat("Move", 1);
            transform.localScale = new Vector2(_horizontal, 1f);
        }
        else
        {
            anim.SetFloat("Move", 0);
        }
        Rb.velocity = new Vector2(_horizontal * _speed * Time.deltaTime, Rb.velocity.y);
    }
    private void Jump()
    {
        Rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _canJump = false;
        anim.SetBool("Jumping", true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("Jumping", false);
            StartCoroutine(ResetJump());
        }
    }
    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(_waitTillNextJump);
        _canJump = true;
    }
    void Attack()
    {
        anim.SetTrigger("Attack");
    }
}