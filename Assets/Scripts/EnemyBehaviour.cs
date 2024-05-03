using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int Damage;
    public float RunSpeed;
    public float WalkSpeed;
    public float Knockback;
    public float KnockbackUp;
    public Animator Animator;

    [HideInInspector]
    public GameObject Target;

    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;
    private Vector3 _home;
    private float _speed;

    private Vector3 _currentDestination;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _home = transform.position;
    }

    void FixedUpdate()
    {
        _speed = 0;

        if (Target != null)
        {
            _speed = RunSpeed / 100;
            _currentDestination = Target.transform.position;
        }
        else
        {
            _currentDestination = _home;
            if (Vector2.Distance(transform.position, _home) > 0.1f)
                _speed = WalkSpeed / 100;
        }

        Vector3 dir = transform.position - _currentDestination;
        _sprite.flipX = dir.x > 0;

        if (_speed > 0)
        {
            Vector2 pos = Vector2.MoveTowards(transform.position, _currentDestination, _speed);
            pos.y = _home.y;
            _rb.MovePosition(pos);
        }

        Animator.SetFloat("Speed", _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<Rigidbody2D>().AddForce((collision.GetContact(0).normal * -Knockback) + Vector2.up * KnockbackUp);
            GameManager.Instance.TakeDamage(Damage);
        }
    }
}
