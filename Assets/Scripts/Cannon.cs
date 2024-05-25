using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform _tubeTransform;
    [SerializeField] private Transform _tableTransform;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _cannonBallPrefab;
    [SerializeField] private float _fireForce = 10f;
    [SerializeField] private float _rotationSpeed = 50f;
    [SerializeField] private float _maxVerticalAngle = 45f;
    [SerializeField] private float _minVerticalAngle = -5f;

    private Vector3 _inputHorizontal;
    private Vector3 _inputVertical;


    private void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        _inputHorizontal = new Vector3(0, 0, UnityEngine.Input.GetAxisRaw("Horizontal"));
        _inputHorizontal = _inputHorizontal.normalized;

        _tableTransform.Rotate(_inputHorizontal * (_rotationSpeed * Time.deltaTime));

        _inputVertical = new Vector3(0, UnityEngine.Input.GetAxisRaw("Vertical"), 0);
        _inputVertical = _inputVertical.normalized;

        _tubeTransform.Rotate(_inputVertical * (_rotationSpeed * Time.deltaTime));
    }

    private void Shoot()
    {
        if (UnityEngine.Input.GetButtonDown("Fire1"))
        {
            GameObject cannonBall = Instantiate(_cannonBallPrefab, _spawnPoint.position, _spawnPoint.rotation);

            // ƒобавл€ем силу €дру по направлению дула
            Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
            rb.AddForce(_spawnPoint.forward * (_fireForce * 100));

            Destroy(cannonBall, 3f);
        }
    }
}

