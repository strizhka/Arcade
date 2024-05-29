using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _targets = new List<GameObject>();
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private Transform _spawnParent;
    [SerializeField] private Vector2 _xRange;
    [SerializeField] private Vector2 _yRange;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator<WaitForSeconds> Spawn()
    {
        Vector3 randomPoint = new Vector3(UnityEngine.Random.Range(_xRange.x, _xRange.y), _spawnParent.position.y, UnityEngine.Random.Range(_yRange.x, _yRange.y));
        GameObject target = Instantiate(_targets[UnityEngine.Random.Range(0, _targets.Count)], randomPoint, Quaternion.Euler(UnityEngine.Random.Range(0, 360), 0, 0), _spawnParent);
        yield return new WaitForSeconds(_spawnCooldown);
        StartCoroutine(Spawn());
    }


}
