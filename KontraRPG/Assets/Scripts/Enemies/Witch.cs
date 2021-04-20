using UnityEngine;

namespace Enemies
{
    public class Witch : MonoBehaviour, IEnemy
    {
        public Spawner Spawner { get; set; }

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