using UnityEngine;
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;

    [SerializeField] protected Transform A,B;

    protected Vector3 destination;
    protected Animator anim;
    protected SpriteRenderer sprite;
    private void Start()
    {
        Init();
    }
    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
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
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }
}