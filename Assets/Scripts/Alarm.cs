using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speed;

    private AudioSource _audio;
    private bool iSinside = false;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0;
        _audio.Play();
    }

    private void Update()
    {
        if (iSinside && _audio.volume < 1)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, 1, _speed * Time.deltaTime);
        }

        if (iSinside == false && _audio.volume > 0)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, 0, _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            iSinside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            iSinside = false;
        }
    }
}
