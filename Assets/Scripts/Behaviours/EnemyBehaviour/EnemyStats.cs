using System.Collections;
using UnityEngine;

namespace Behaviours.EnemyBehaviour
{
    public class EnemyStats : MonoBehaviour
    {
        [SerializeField] private EnemyData enemyData;
        [SerializeField] private float deathAnimationTime;
        [SerializeField] private AudioClip deathSound;
        [SerializeField] private AudioClip walkSound;
        [SerializeField] private float damageInterval;
        [SerializeField] private Transform detectorTransform;
        [SerializeField] private float detectorRadius;
        [SerializeField] private LayerMask detectorLayerMask;
        private float _maxHealth;
        private float _currentHealth;
        private bool _foundEnemy;
        private Rigidbody2D _rb;
        private Collider2D _detector;
        private AudioManager audioManager;
        private Lost toScore;
        public float MoveSpeed { get; set; }

        private void Awake()
        {
            _maxHealth = enemyData.maxHealth;
            _currentHealth = _maxHealth;
            MoveSpeed = enemyData.moveSpeed;
            _rb =  GetComponent<Rigidbody2D>();
            _foundEnemy = false;
            audioManager = AudioManager.Instance;
            toScore = FindAnyObjectByType<Lost>();
        }

        private void Update()
        {
            _rb.linearVelocityX = CheckAllyUnit() ? 0.0f : -MoveSpeed * Time.deltaTime;
            if(_rb.linearVelocityX > 0.0f) audioManager.PlaySound(walkSound);
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            Debug.Log($"{gameObject.name}: {_currentHealth} / {_maxHealth}");
            if (_currentHealth <= 0)
                StartCoroutine(Die());
        }

        private IEnumerator Die()
        {
            YieldInstruction wait = new WaitForSeconds(deathAnimationTime);
            
            toScore.OnUpdateScore(enemyData.scoreGiven);
            
            audioManager.PlaySound(deathSound);

            yield return wait;
            
            StopAllCoroutines();
            Destroy(gameObject);
        }

        private bool CheckAllyUnit()
        {
            _detector = Physics2D.OverlapCircle(detectorTransform.position, detectorRadius, detectorLayerMask );
            if (_detector && !_foundEnemy) StartCoroutine(DoDamage(_detector));
            return _detector;
        }

        private IEnumerator DoDamage(Collider2D alley)
        {
            YieldInstruction  wait = new WaitForSeconds(damageInterval);

            _foundEnemy = true;
            
            while (CheckAllyUnit())
            {
                alley.GetComponent<AllyStats>().TakeDamage(enemyData.damage);
                
                yield return wait;
            }
            
            _foundEnemy = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(detectorTransform.position, detectorRadius);
        }
    }
}
