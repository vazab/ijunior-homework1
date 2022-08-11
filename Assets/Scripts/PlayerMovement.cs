using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _sprite;
    private float directionX;
    private Animator _animator;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        directionX = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        transform.Translate(directionX, 0, 0);

        if (directionX < 0)
        {
            _sprite.flipX = true;
        }
        else if (directionX > 0)
        {
            _sprite.flipX = false;
        }

        _animator.SetFloat("speed", Mathf.Abs(directionX));
    }
}
