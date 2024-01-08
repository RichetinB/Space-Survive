using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMeteor : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _spawnHeight = 10f;
    [SerializeField] private GameObject _meteorPrefab;
    [SerializeField] private Canvas _gameOverCanvas;

    private float _timer;

    private void Start()
    {
        Time.timeScale = 1.0f; // Assure que le temps n'est pas en pause au d�but
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

        CheckPlayerCollision();
    }

    private void MeteorSpawn()
    {
        float randomX = Random.Range(-10f, 10f);
        Vector3 spawnPos = new Vector3(randomX, _spawnHeight, 0f);

        GameObject meteor = Instantiate(_meteorPrefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = meteor.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = meteor.AddComponent<Rigidbody2D>();
        }

        rb.gravityScale = 1.0f;

        Destroy(meteor, 10f);
    }

    private void CheckPlayerCollision()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Meteor"))
            {
                _gameOverCanvas.gameObject.SetActive(true);
                Time.timeScale = 0f; 
                gameObject.SetActive(false);
                enabled = false;
                break;
            }
        }
    }
}
