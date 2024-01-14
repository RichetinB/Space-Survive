using System.Collections;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _spawnHeight = 10f;
    [SerializeField] private GameObject _meteorPrefab;

    private void OnEnable()
    {
        InvokeRepeating("MeteorSpawn", 0f, _maxTime);
    }

    private void OnDisable()
    {
        CancelInvoke("MeteorSpawn");
    }

    private void MeteorSpawn()
    {
        float randomX = Random.Range(-10f, 10f);
        Vector3 spawnPos = new Vector3(randomX, _spawnHeight, 0f);

        GameObject meteor = Instantiate(_meteorPrefab, spawnPos, Quaternion.identity);
    }
}
