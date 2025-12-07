using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private LevelData firstWaveData;
    [SerializeField] private float quantityOfEnemiesBetweenGaps = 3.0f;
    [SerializeField] private float waitNextEnemies = 5.0f;
    [SerializeField] private float waitEnemiesInTheSameWave = 0.5f;
    [SerializeField] private List<Transform> waveSpawnPoints; 
    private List<GameObject> _enemiesThisWave;
    private List<GameObject> _quantityOfEnemiesThisWave;
    private Transform _spawn;
    private Transform _lastSpawnedPoint;
    private readonly int _waveIndex = 1;
    private float _timeThisWave;
    

    private void Awake()
    {
        StartNewWave(firstWaveData);
    }

    private void StartNewWave(LevelData wave)
    {
        _enemiesThisWave = wave.enemiesThisWave;
        _timeThisWave = wave.waveTime;
        _quantityOfEnemiesThisWave = new List<GameObject>();

        for (int i = 0; i < firstWaveData.quantityOfEnemies; i++)
        {
            _quantityOfEnemiesThisWave.Add(_enemiesThisWave[Random.Range(0, _enemiesThisWave.Count)]);
        }

        StartCoroutine(InstantiatingEnemies());
    }

    private IEnumerator InstantiatingEnemies()
    {
        YieldInstruction wait = new WaitForSeconds(waitNextEnemies);
        float quantityMultiplier = 0;
        float quantityOfEnemies = quantityOfEnemiesBetweenGaps;
        float timer = 0.0f;

        yield return wait;
        
        while (timer < _timeThisWave )
        {
            List<GameObject> enemiesThisWave = new List<GameObject>();
            timer += Time.deltaTime;
            quantityMultiplier++;

            for (int i = 0; i < quantityOfEnemies * quantityMultiplier; i++)
                try
                {
                    enemiesThisWave.Add(_quantityOfEnemiesThisWave[0]);
                    _quantityOfEnemiesThisWave.RemoveAt(0);
                }
                catch (ArgumentOutOfRangeException) { }
            
            
            foreach (GameObject enemy in enemiesThisWave)
            {
                List<Transform> availableSpawnTransforms = waveSpawnPoints;
                if(!_lastSpawnedPoint) availableSpawnTransforms.Remove(_lastSpawnedPoint);
                
                _spawn = availableSpawnTransforms[Random.Range(0, availableSpawnTransforms.Count)];
                _lastSpawnedPoint = _spawn;
    
                Instantiate(enemy, _spawn.position, Quaternion.identity);
                yield return new WaitForSeconds(waitEnemiesInTheSameWave);
                timer += waitEnemiesInTheSameWave;
            }

            yield return wait;
            timer += waitNextEnemies;
        }

        string wave = $"Wave{_waveIndex + 1}";
        LevelData nextWave = Resources.Load($"Assets/Resources/LevelData/{wave}") as  LevelData;
        if (nextWave) StartNewWave(nextWave);
    }
}
