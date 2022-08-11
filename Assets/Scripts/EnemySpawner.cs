using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform[] _points;
    

    private void Start()
    {
        _points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i);
        }
    }


}
