using UnityEngine;
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;

    [SerializeField] protected Transform A,B;

    [SerializeField] protected GameObject _diamondPrefab;

    protected Vector3 destination;
    protected float distance = 2f;
    protected Animator anim;

    protected bool isHit = false;
    protected bool isDead = false;
    protected GameObject player;
    bool flip = false;

    private void Start()
    {
        Init();
    }
    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
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
        if (flip)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (transform.position == A.position)
        {
            flip = true;
            anim.SetTrigger("Idle");
            destination = B.position;
        }
        else if (transform.position == B.position)
        {
            anim.SetTrigger("Idle");
            flip = false;
            destination = A.position;
        }
        if(Vector3.Distance(transform.localPosition, player.transform.localPosition) > distance || player.GetComponent<Movement>().Health <= 0)
        {
            isHit = false;
            anim.SetBool("Combat", false);
        }
        if (!isHit)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
        Vector3 dir = player.transform.position - transform.position;
        if (dir.x > 0 && anim.GetBool("Combat") == true)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (dir.x < 0 && anim.GetBool("Combat") == true)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }
}