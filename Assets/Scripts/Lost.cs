using System;
using Behaviours;
using Behaviours.EnemyBehaviour;
using UnityEngine;

public class Lost : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private LeaderboardData leaderboardData;
    private float _finalScore;
    public float GetFinalScore() => _finalScore;
    public void OnUpdateScore(float scoreEarned) { _finalScore += scoreEarned;  }
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyStats>(out _))
        {
            leaderboardData.score.Add(_finalScore);
            gameOverCanvas.enabled = true;
        }
    }
}