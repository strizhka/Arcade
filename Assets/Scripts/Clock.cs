using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private GameObject _minutes;
    [SerializeField] private GameObject _seconds;
    [SerializeField] private GameObject _light;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private AudioClip _audio;

    private AudioSource _audioSource;

    private bool _isRinging = false;

    private void Start()
    {
        _isRinging = false;
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(SpawnRinging());
    }

    private void Update()
    {
        Ring();
    }

    private IEnumerator SpawnRinging()
    {
        yield return new WaitForSeconds(Random.Range(10,20));
        _isRinging = true;
        yield return null;
    }

    private void Ring()
    {
        if (_isRinging)
        {
            _audioSource.mute = false;
            _minutes.GetComponent<Transform>().Rotate(new Vector3(0, 1, 0).normalized * (_rotationSpeed * Time.deltaTime));
            _seconds.GetComponent<Transform>().Rotate(new Vector3(0, 1, 0).normalized * (-_rotationSpeed * Time.deltaTime));
            _light.SetActive(true);
        }

        if (!_isRinging)
        {
            _isRinging = false;
            _minutes.GetComponent<Transform>().Rotate(new Vector3(0, 0, 0));
            _seconds.GetComponent<Transform>().Rotate(new Vector3(0, 0, 0));
            _light.SetActive(false);
            _audioSource.mute = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("CannonBall") && _isRinging)
            {
                Timer._remainingTime += 20;
                _isRinging = false;
                StartCoroutine(SpawnRinging());
            }
        }
    }
}
