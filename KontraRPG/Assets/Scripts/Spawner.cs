using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _monster;
    [SerializeField] private float _spawnDelay;
    private float _currentTime;
    private bool _respawn;
    private bool _spawning;

    private void Start()
    {
        Spawn();
        _currentTime = _spawnDelay;
    }

    private void Update()
    {
        if (!_spawning) return;

        _currentTime -= _spawnDelay;
        if (_currentTime <= 0)
        {
            Spawn();
        }
    }

    public void Respawn()
    {
        _spawning = true;
        _currentTime = _spawnDelay;
    }
    
    private void Spawn()
    {
        IEnemy instance = Instantiate(_monster, transform.position, Quaternion.identity).GetComponent<IEnemy>();
        instance.Spawner = this;
        
        _spawning = false;

        throw new System.NotImplementedException();
    }
}
