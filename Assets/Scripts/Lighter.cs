using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private Transform _lightTransform;

    private Vector3 _direction;

    private bool isChangingDirection;

    private void Start()
    {
        _lightTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (!isChangingDirection)
            StartCoroutine(ChangeDirection());
        _lightTransform.Rotate(_direction * (_rotationSpeed * Time.deltaTime));
    }

    private IEnumerator ChangeDirection()
    {
        isChangingDirection = true;

        yield return new WaitForSeconds(2);

        isChangingDirection = false;

        int xRotate;

        if (_lightTransform.rotation.x >= 165)
        {
            xRotate = -100;
        }
        else if (_lightTransform.rotation.x <= -15)
        {
            xRotate = 100;
        }
        else
        {
            xRotate = Random.Range(0, 20);
        }

        _direction = new Vector3(xRotate, Random.Range(-20, 20), 0);
        _direction = _direction.normalized;
        

        StartCoroutine(ChangeDirection());
    }
}
