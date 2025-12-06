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
            float distance = transform.position.x + endPosition;
            
            return distance;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, new Vector2(CalculateStartToEndPosition(),transform.position.y));
        }
    }
}