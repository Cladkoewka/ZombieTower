using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveNumberText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private float _animationTime;


    private void OnEnable()
    {
        _spawner.WaveChanged += OnWaveChanged;
    }

    private void OnDisable()
    {
        _spawner.WaveChanged -= OnWaveChanged;
    }

    private void OnWaveChanged(int waveNumber)
    {
        _text.text = ("Wave " + waveNumber.ToString());
    }
}
