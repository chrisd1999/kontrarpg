using System;
using Interfaces;
using UnityEngine;

namespace Enemies
{
    public class Witch : MonoBehaviour, IEnemy
    {
        public Spawner Spawner { get; set; }
        [SerializeField] private float maxHealth;
        private float _currentHealth;

        
        public void Die()
        {
            Spawner.Respawn();
            Destroy(gameObject);
        }

        public void TakeDamage(int amount)
        {
            throw new NotImplementedException();
        }

        public void DealDamage()
        {
            throw new NotImplementedException();
        }
    }
}
