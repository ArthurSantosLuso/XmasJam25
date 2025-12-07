using Behaviours;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class Lost : MonoBehaviour
    {
        [SerializeField] private Canvas gameOverCanvas;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out EnemyStats enemie))
            {
                gameOverCanvas.enabled = true;
            }
        }
    }
}