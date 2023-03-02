using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _button;
    [SerializeField] private WaveNumberText _waveNumberText;


    private void OnEnable()
    {    
        _spawner.AllEnemySpawned += OnAllEnemySpawned;
        _button.onClick.AddListener(OnNextWaveButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawned;
        _button.onClick.RemoveListener(OnNextWaveButtonClick);
    }

    private void OnAllEnemySpawned()
    {
        _button.gameObject.SetActive(true);
    }

    private void OnNextWaveButtonClick()
    {
        _spawner.StarNextWave();
        _button.gameObject.SetActive(false);
    }


}
