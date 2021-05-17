using UnityEngine;

namespace Enemies
{
    public class Witch : MonoBehaviour, IEnemy
    {
        private readonly int _enemyId = 1;
        public Spawner Spawner { get; set; }
        public int EnemyId => _enemyId;

        public void Die()
        {
            Spawner.Respawn();
            Destroy(gameObject);
        }

        public void TakeDamage()
        {
            throw new System.NotImplementedException();
        }

        public void DealDamage()
        {
            throw new System.NotImplementedException();
        }
    }
}