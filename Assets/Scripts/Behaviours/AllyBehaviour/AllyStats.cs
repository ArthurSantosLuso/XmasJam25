using UnityEngine;
using System.Collections;

namespace Behaviours
{
    public abstract class AllyStats : MonoBehaviour
    {
        [SerializeField] private AllyData allyData;
        [SerializeField] private float deathAnimationTime;
        private float _maxHealth;
        private float _currentHealth;
        private float _cost;
        
        protected virtual void Awake()
        {
            _maxHealth = allyData.maxHealth;
            _currentHealth = _maxHealth;
            _cost = allyData.moneyCost;
        }

        protected virtual void Update()
        {
            DoSomething();
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
            
            StopAllCoroutines();
            Destroy(gameObject);
        }

        protected abstract void DoSomething();
    }
}
