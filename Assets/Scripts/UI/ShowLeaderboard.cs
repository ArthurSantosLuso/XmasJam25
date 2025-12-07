using System;
using Behaviours;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace UI
{
    public class ShowLeaderboard : MonoBehaviour
    {
        [SerializeField] private LeaderboardData leaderboardData;
        private List<float> leaderboard;
        public List<float> GetLeaderboard() => leaderboard;
        
        private void OnEnable()
        {
            leaderboard = leaderboardData.score.OrderByDescending(n => n).ToList();
        }
        
        
    }
}