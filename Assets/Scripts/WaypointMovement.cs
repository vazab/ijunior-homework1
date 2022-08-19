using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed = 50f;

    private Rigidbody2D _rigidbody;
    private Transform[] _points;
    private int _currentPoint;
    
    public float Direction { get; private set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(Direction * _speed * Time.deltaTime, _rigidbody.velocity.y);
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        Direction = Mathf.Sign(target.position.x - transform.position.x);

        bool isPointReached = Mathf.Abs(target.position.x - transform.position.x) < 0.1;
        if (isPointReached)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}