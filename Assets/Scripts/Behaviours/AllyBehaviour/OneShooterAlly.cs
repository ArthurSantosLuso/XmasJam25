using UnityEngine;
using System.Collections;

namespace Behaviours
{
    public class OneShooterAlly : AllyStats
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform projectileSpawnPoint;
        [SerializeField] private float projectileTimeBetweenAttacks;
        private bool _isAttacking;
        private IAttack _attacker;

        protected override void Awake()
        {
            base.Awake();
            
            _isAttacking = false;
            _attacker = GetComponent<IAttack>();
        }
        protected override void DoSomething()
        {
            if(!_attacker.CheckEnemyUnit())
                return;
            if (!_isAttacking)
                StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            YieldInstruction wait = new WaitForSeconds(projectileTimeBetweenAttacks);
            _isAttacking = true;
            
            while (_attacker.CheckEnemyUnit())
            {
                Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

                yield return wait;
            }
            
            _isAttacking = false;
        }
    }
}