using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckTarget : MonoBehaviour
{
    [SerializeField] private AudioClip _audio;
    [SerializeField] private ParticleSystem _particleSystem;

    private GameObject _duck;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _duck = gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("CannonBall"))
            {
                _audioSource.PlayOneShot(_audio);
                _particleSystem.Play();
                StartCoroutine(DestroyAfterSound());
            }
        }
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitWhile(() => _audioSource.isPlaying);
        Destroy(_duck);
    }
}

