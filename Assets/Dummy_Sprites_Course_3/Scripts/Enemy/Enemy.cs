using UnityEngine;
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;

    [SerializeField] protected Transform A,B;

    [SerializeField] protected GameObject _diamondPrefab;

    protected SpriteRenderer sprite;
    protected Vector3 destination;
    protected float distance = 2f;
    protected Animator anim;

    protected bool isHit = false;
    protected bool isDead = false;
    protected GameObject player;

    private void Start()
    {
        Init();
    }
    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public virtual void Update()
    {
        if (isDead || (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !anim.GetBool("Combat")))
        {
            return;
        }
        Movement();
    }
    public virtual void Movement()
    {
        if (destination == A.position)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        if (transform.position == A.position)
        {
            anim.SetTrigger("Idle");
            destination = B.position;
        }
        else if (transform.position == B.position)
        {
            anim.SetTrigger("Idle");
            destination = A.position;
        }
        if(Vector3.Distance(transform.localPosition, player.transform.localPosition) > distance)
        {
            isHit = false;
            anim.SetBool("Combat", false);
        }
        if (!isHit)
        {
            transform.localScale = Vector3.one;
            transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
        Vector3 dir = player.transform.position - transform.position;
        if (dir.x > 0 && anim.GetBool("Combat") == true)
        {
            sprite.flipX = false;
        }
        else if (dir.x < 0 && anim.GetBool("Combat") == true)
        {
            sprite.flipX = true;
        }
    }
}