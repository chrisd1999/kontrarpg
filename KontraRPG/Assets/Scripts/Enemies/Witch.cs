using UnityEngine;

namespace Enemies
{
    public class Witch : MonoBehaviour, IEnemy
    {
        private readonly int _enemyId = 1;
        private int _currentHealth = 100;
        
        private QuestManager _questManager;
        public Spawner Spawner { get; set; }
        public int EnemyId => _enemyId;


        private void Start()
        {
            _questManager = QuestManager.Instance;
        }
        
        public void Die()
        {
            // Spawner.Respawn();

            _questManager.UpdateQuestProgress(_enemyId);
            Destroy(gameObject);
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        public void DealDamage()
        {
            throw new System.NotImplementedException();
        }
    }
}