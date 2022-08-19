using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundChecker : MonoBehaviour
{
    private const string LayerName = "Solid";
    private int _layerNumber;

    public bool IsGrounded { get; private set; }

    private void Start()
    {
        _layerNumber = LayerMask.NameToLayer(LayerName);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IsGrounded = collision.gameObject.layer == _layerNumber;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        IsGrounded = false;
    }
}
