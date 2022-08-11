using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private EntryChecker _entryChecker;

    private AudioSource _audio;
    private Coroutine _volumeUpJob;
    private Coroutine _volumeDownJob;

    private void OnEnable()
    {
        _entryChecker.PlayerEntered += StartVolumeUp;
        _entryChecker.PlayerLeft += StartVolumeDown;
    }

    private void OnDisable()
    {
        _entryChecker.PlayerEntered -= StartVolumeUp;
        _entryChecker.PlayerLeft -= StartVolumeDown;
    }

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0;
        _audio.Play();
    }

    private void StartVolumeUp()
    {
        _volumeUpJob = StartCoroutine(VolumeUp());
    }

    private void StartVolumeDown()
    {
        _volumeDownJob = StartCoroutine(VolumeDown());
    }

    private IEnumerator VolumeUp()
    {
        if (_volumeDownJob != null)
        {
            StopCoroutine(_volumeDownJob);
        }

        while (_audio.volume < 1)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, 1, _speed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator VolumeDown()
    {
        if (_volumeUpJob != null)
        {
            StopCoroutine(_volumeUpJob);
        }

        while (_audio.volume > 0)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, 0, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
