using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator), typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _sprite;
    private PlayerMovement _movement;

    public int Money { get; private set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        SetAnimations();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Destroy(gameObject);
        }

        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(coin.gameObject);
            Money++;
            Debug.Log(Money);
        }
    }

    private void SetAnimations()
    {
        if (_movement.Move < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (_movement.Move > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        _animator.SetFloat(PlayerAnimator.Params.Speed, Mathf.Abs(_rigidbody.velocity.x));
        _animator.SetBool(PlayerAnimator.Params.IsGrounded, _movement.CheckGround());
        _animator.SetBool(PlayerAnimator.Params.Jump, _movement.Jump);
        _animator.SetBool(PlayerAnimator.Params.Fall, _rigidbody.velocity.y < -0.1);
    }
}