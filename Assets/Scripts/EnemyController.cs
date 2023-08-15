using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private UnityEvent _returned;
    [SerializeField] private float _speed;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private bool direction = true;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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

    public void Turn()
    {
        direction = !direction;
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out NavigationBorder navigationBorder))
            _returned.Invoke();
    }
}
