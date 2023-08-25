using UnityEngine;
public class MossGiant : Enemy
{
    Animator _anim;
    SpriteRenderer _sprite;

    Vector3 _destination;
    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }
    public override void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Movement();
    }
    void Movement()
    {
        if(_destination == A.position)
        {
            _sprite.flipX = true;
        }
        else
        {
            _sprite.flipX = false;
        }
        if (transform.position == A.position)
        {
            _anim.SetTrigger("Idle");
            _destination = B.position;
        }
        else if(transform.position == B.position)
        {
            _anim.SetTrigger("Idle");
            _destination = A.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, _destination, _speed * Time.deltaTime);
    }
}