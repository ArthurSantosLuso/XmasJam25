using System;
using System.Collections;
using UnityEngine;

namespace Behaviours
{
    public class EnemyStats : MonoBehaviour
    {
        [SerializeField] private EnemyData enemyData;
        [SerializeField] private float deathAnimationTime;
        [SerializeField] private Transform detectorTransform;
        [SerializeField] private float detectorRadius;
        [SerializeField] private LayerMask detectorLayerMask;
        private float _maxHealth;
        private float _currentHealth;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _maxHealth = enemyData.maxHealth;
            _currentHealth = _maxHealth;
            _rb =  GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _rb.linearVelocityX = CheckAllyUnit() ? 0.0f : -enemyData.moveSpeed * Time.deltaTime;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
                StartCoroutine(Die());
        }

        private IEnumerator Die()
        {
            YieldInstruction wait = new WaitForSeconds(deathAnimationTime);
            
            //play death animation

            yield return wait;
        }

        private bool CheckAllyUnit()
        {
            Collider2D detector = Physics2D.OverlapCircle(detectorTransform.position, detectorRadius, detectorLayerMask );
            //Irá checkar se o collider é de um aliado nosso
            return detector;
        }

        public void DoDamage()
        {
            //Event
            //enemyData.damage
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(detectorTransform.position, detectorRadius);
        }
    }
}
