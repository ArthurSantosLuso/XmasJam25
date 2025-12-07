using System.Collections;
using UnityEngine;

namespace Behaviours
{
    public class ProjectileWithSlow : Projectile
    {
        [SerializeField] private float slowingTime;
        
        protected override void DoDamage(EnemyStats enemy)
        {
            StartCoroutine(SlowingEnemy(enemy));
            
            base.DoDamage(enemy);
        }

        private IEnumerator SlowingEnemy(EnemyStats enemy)
        {
            YieldInstruction wait = new WaitForSeconds(slowingTime);
            
            enemy.MoveSpeed /= 2;
            
            yield return wait;
            
            enemy.MoveSpeed *= 2;
        }
    }
}