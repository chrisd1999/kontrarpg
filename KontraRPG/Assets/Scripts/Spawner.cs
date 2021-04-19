using Interfaces;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private float spawnDelay;
    [SerializeField] private bool respawn;
    private float _currentTime;
    private bool _spawning;

    private void Start()
    {
        Spawn();
        _currentTime = spawnDelay;
    }

    private void Update()
    {
        if (!_spawning) return;

        _currentTime -= spawnDelay;
        if (_currentTime <= 0)
        {
            Spawn();
        }
    }

    public void Respawn()
    {
        _spawning = true;
        _currentTime = spawnDelay;
    }
    
    private void Spawn()
    {
        IEnemy instance = Instantiate(monster, transform.position, Quaternion.identity).GetComponent<IEnemy>();
        if (instance != null) instance.Spawner = this;

        _spawning = false;
    }
}
