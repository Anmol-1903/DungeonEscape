using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class Movement : MonoBehaviour, IDamageable
{

    public int _diamonds;
    public int Health { get; set; }
    [SerializeField] int _maxHealth = 5;
    [SerializeField] float _speed = 500f;
    [SerializeField] float _jumpForce = 5f;
    [SerializeField] float _waitTillNextJump = .1f;
    [SerializeField] LayerMask _groundLayer;

    bool _isGrounded = false;
    bool _canJump = false;
    bool _canWalk = true;
    Rigidbody2D Rb;
    Animator anim;
    Animator swordAnim;


    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        swordAnim = transform.GetChild(1).GetComponent<Animator>();
        Health = _maxHealth;
    }
    private void Start()
    {
        UIManager.Instance.UpdateLivesMaxHealth(_maxHealth);
        UIManager.Instance.UpdateLives(_maxHealth);
    }
    private void Update()
    {
        Move();
        if(CrossPlatformInputManager.GetButtonDown("A_Button") && _isGrounded)
        {
            Attack();
        }

        _isGrounded = GroundCheck();

        if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button")) && _isGrounded && _canJump)
        {
            Jump();
            _isGrounded = false;
        }
        anim.SetBool("Jumping", !GroundCheck());
    }
    private bool GroundCheck()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.down, transform.localScale.y * 1f, _groundLayer.value);
        Debug.DrawRay(transform.position, Vector2.down * transform.localScale.y * 1f, Color.green);
        if (raycastHit2D.collider != null)
        {
            return true;
        }
        return false;
    }
    private void Move()
    {
        if (!_canWalk)
            return;
        float _horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        if(_horizontal != 0)
        {
            anim.SetFloat("Move", 1);
            transform.localScale = new Vector2(_horizontal, 1f);
        }
        else
        {
            if(Health > 0)
            {
                anim.SetFloat("Move", 0);
            }
        }
        Rb.velocity = new Vector2(_horizontal * _speed * Time.deltaTime, Rb.velocity.y);
    }
    private void Jump()
    {
        Rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _canJump = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
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
        swordAnim.SetTrigger("SwordArc");
    }

    public void Damage()
    {
        Health--;
        UIManager.Instance.UpdateLives(Health);
        anim.SetTrigger("Hit");
        if (Health < 1)
        {
            anim.SetTrigger("Death");
            _canJump = false;
            _canWalk = false;
        }
    }
    public void AddGems(int _amt)
    {
        _diamonds += _amt;
        UIManager.Instance.UpdateGems(_diamonds);
    }
}