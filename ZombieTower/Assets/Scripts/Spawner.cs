using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private float _delayBetweenWaves;

    private bool _isLastWaveEnded = true;
    private Wave _currentWave;
    private int _waveCounter = 0;
    private int _spawnedEnemy = 0;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;
    private void Update()
    {
        if (_isLastWaveEnded)
        {
            _isLastWaveEnded = false;
            _currentWave = _waves[_waveCounter];
            EnemyCountChanged?.Invoke(0, 1);
            StartCoroutine(Spawn(_currentWave));
            _waveCounter++;
        }
    }

    
    IEnumerator Spawn(Wave wave)
    {
        for (int i = 0; i < wave._countZombie; i++)
        {
            Instantiate(wave._enemyPrefab, _spawnPoints[Random.Range(0, _spawnPoints.Count)].transform.position, Quaternion.identity);
            _spawnedEnemy++;
            EnemyCountChanged?.Invoke(_spawnedEnemy, _currentWave._countZombie);
            yield return new WaitForSeconds(wave._delayBetweenSpawn);
        }
        _spawnedEnemy = 0;
        yield return new WaitForSeconds(_delayBetweenWaves);
        AllEnemySpawned?.Invoke();
    }

    public void StarNextWave()
    {
        _isLastWaveEnded = true;
    }
}


[System.Serializable]
public class Wave
{
    public int _countZombie;
    public float _delayBetweenSpawn;
    public GameObject _enemyPrefab;
}
