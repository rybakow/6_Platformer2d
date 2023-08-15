using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private Transform _groundControlPoint;
    [SerializeField] private Text _coinHUDValue;

    private int _coins = 0;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    public int Coins => _coins;

    public void AddCoin()
    {
        _coins += 1;
        _coinHUDValue.text = _coins.ToString();
    }
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Run();
        Jump();
    }

    private void Run()
    {
        float movement = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * _speed;
        
        _spriteRenderer.flipX = movement < 0 ? true : false;
        
        _animator.SetFloat(AnimatorPlayerController.Params.Speed, Math.Abs(movement));
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(_groundControlPoint.position, Vector2.down);
            
            if (hit.collider != null && hit.distance < 0.05f)
                _rigidbody.AddForce(new Vector2(0, _jumpPower), ForceMode2D.Impulse);
        }
    }
}
