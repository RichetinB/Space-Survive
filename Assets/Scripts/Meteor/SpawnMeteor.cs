using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{

    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private GameObject _meteor;

    private float _timer;
    private void Start()
    {
        MeteorSpawn();
    }

    private void Update()
    {
        if (_timer > _maxTime)
        {
            MeteorSpawn();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }

    private void MeteorSpawn()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        GameObject pipe = Instantiate(_meteor, spawnPos, Quaternion.identity);

        Destroy(pipe, 10f);
    }

}
