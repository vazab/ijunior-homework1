using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Vector2 position = transform.GetChild(i).transform.position;
            Instantiate(_prefab, position, Quaternion.identity);
        }
    }
}
