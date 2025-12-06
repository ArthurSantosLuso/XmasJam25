using System;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    private float _time;
    private float _currentMoney;
    private float _score;
    public Action OnChangeMoney;
    public Action OnChangeScore;

    public void EarnMoney(float amount)
    {
        _currentMoney += amount;
    }
    
    public void SpendMoney(float amount)
    {
        _currentMoney -= amount;
    }

    public void AddScore(float amount)
    {
        _score += amount;
    }

    public void ResetScore()
    {
        _score = 0f;
    }
    
    public float GetCurrentMoney() => _currentMoney;
    public float GetCurrentTime() => Mathf.CeilToInt(_time);
    public float GetCurrentScore() => _score;

    private void Awake()
    {
        _time = 0f;
    }

    private void Update()
    {
        _time += Time.deltaTime;
    }
}
