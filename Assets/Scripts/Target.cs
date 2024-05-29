using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private AudioClip _audio;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] public int Score;
    [SerializeField] private float _drag;

    private Rigidbody _rb;
    private AudioSource _audioSource;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.drag = _drag;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("CannonBall"))
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<Collider>().enabled = false;
                _audioSource.PlayOneShot(_audio);
                _particleSystem.Play();
                StartCoroutine(DestroyAfterSound());
            }

            if (collision.gameObject.CompareTag("Floor"))
            {
                Destroy(gameObject, 2);
            }
        }
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitWhile(() => _audioSource.isPlaying);
        Destroy(gameObject);
    }
}

