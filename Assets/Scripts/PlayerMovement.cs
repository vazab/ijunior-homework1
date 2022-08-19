using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 150f;
    [SerializeField] private float _jumpForce = 3f;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidody;

    public float Move { get; private set; }
    public bool Jump { get; private set; }

    public bool CheckGround()
    {
        return _groundChecker.IsGrounded;
    }

    private void Start()
    {
        _rigidody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidody.velocity = new Vector2(Move * _speed * Time.deltaTime, _rigidody.velocity.y);

        if (Jump)
        {
            _rigidody.velocity = new Vector2(_rigidody.velocity.x, _jumpForce);
        }
    }

    private void Update()
    {
        Move = Input.GetAxisRaw("Horizontal");
        Jump = Input.GetKey(KeyCode.W) && _groundChecker.IsGrounded == true;
    }
}