using UnityEngine;
using UnityEngine.Events;

public class EntryChecker : MonoBehaviour
{
    public event UnityAction PlayerEntered;
    public event UnityAction PlayerLeft;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            PlayerEntered?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            PlayerLeft?.Invoke();
        }
    }
}
