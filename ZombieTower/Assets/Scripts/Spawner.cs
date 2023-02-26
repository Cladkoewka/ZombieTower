using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private float _delayBetweenWaves;

    private bool _isLastWaveEnded = true;
    private int _waveCounter = 0;

    private void Update()
    {
        if (_isLastWaveEnded)
        {
            _isLastWaveEnded = false;
            StartCoroutine(Spawn(_waves[_waveCounter]));
            _waveCounter++;
        }
    }

    IEnumerator Spawn(Wave wave)
    {
        for (int i = 0; i < wave._countZombie; i++)
        {
            Instantiate(wave._enemyPrefab, _spawnPoints[Random.RandomRange(0, _spawnPoints.Count)].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(wave._delayBetweenSpawn);
        } 
        yield return new WaitForSeconds(_delayBetweenWaves);
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
