using System.Collections.Generic;
using UnityEngine;

namespace Behaviours
{
    [CreateAssetMenu(fileName = "LeaderboardData", menuName = "Scriptable Objects/LeaderboardData")]
    public class LeaderboardData : ScriptableObject
    {
        public List<float> score;
    }
}