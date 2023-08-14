using System;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpPower;
    
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    
    private float _speed = 1f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float movement = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * _speed;
        
        _spriteRenderer.flipX = movement < 0 ? true : false;
        
        _animator.SetFloat(AnimatorPlayerController.Params.Speed, Math.Abs(movement));

        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddForce(new Vector2(0, _jumpPower), ForceMode2D.Impulse);
        }
    }
}
