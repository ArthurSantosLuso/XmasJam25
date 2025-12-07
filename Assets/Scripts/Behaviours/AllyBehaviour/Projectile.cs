using System.Collections;
using UnityEngine;

namespace Behaviours
{
     public class Projectile : MonoBehaviour
     {
          [SerializeField] private float damage;
          [SerializeField] private float lifeTime;

          private void Start()
          {
               StartCoroutine(TimeToDie());
          }

          private IEnumerator TimeToDie()
          {
               YieldInstruction wait = new WaitForSeconds(lifeTime);

               yield return wait;
               
               Destroy(gameObject);
          }

          private void OnCollisionEnter2D(Collision2D other)
          {
               if (other.gameObject.TryGetComponent(out EnemyStats enemy))
                    DoDamage(enemy);
               
               Destroy(gameObject);
          }

          protected virtual void DoDamage(EnemyStats enemy)
          {
               enemy.TakeDamage(damage);
          }
     }
}
