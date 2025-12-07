using UnityEngine;

namespace Behaviours
{
    public class Attacker : MonoBehaviour, IAttack
    {
        [SerializeField] private float endPosition;
        [SerializeField] private LayerMask enemyLayer;
        
        public bool CheckEnemyUnit()
        {
            return Physics2D.Raycast(transform.position, Vector2.right, CalculateStartToEndPosition(), enemyLayer);
        }
        
        private float CalculateStartToEndPosition()
        {
            float distance = Mathf.Abs(endPosition - transform.position.x);
            
            return distance;
        }
    }
}