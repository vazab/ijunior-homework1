using UnityEngine;

[RequireComponent(typeof(WaypointMovement))]
public class Enemy : MonoBehaviour
{
    private WaypointMovement _waypointMovement;

    private void Start()
    {
        _waypointMovement = GetComponent<WaypointMovement>();
    }

    private void Update()
    {
        if (_waypointMovement.Direction < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (_waypointMovement.Direction > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
