using UnityEngine;

namespace Behaviours
{
    [CreateAssetMenu(fileName = "AllyData", menuName = "Scriptable Objects/AllyData")]
    public class AllyData : ScriptableObject
    {
        public float maxHealth;
        public float damage;
        public float moneyCost;
    }
}