using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public float FadeSpeed;
    public Animator Animator;

    [HideInInspector]
    public bool IsDead = false;

    private float _alpha = 1f;
    private SpriteRenderer _sprite;

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsDead)
        {
            _sprite.color = new Color(1f, 1f, 1f, _alpha);
            _alpha -= Time.deltaTime * FadeSpeed;

            if (_alpha <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void Die()
    {
        IsDead = true;
        Animator.SetBool("isDead", true);
    }
}
