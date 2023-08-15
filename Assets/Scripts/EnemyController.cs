using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    public UnityEvent Return;
    
    [SerializeField] private float _speed;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private bool direction = true;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        
        Return.AddListener(Turn());
    }

    private void Update()
    {
        Run();
    }

    private void Run()
    {
        int movement = direction ? 1 : -1;
        
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * _speed;
        
        _spriteRenderer.flipX = movement > 0 ? true : false;
        
        _animator.SetFloat(AnimatorPlayerController.Params.Speed, Math.Abs(movement));
    }

    private void Turn()
    {
        direction = !direction;
    }
}
