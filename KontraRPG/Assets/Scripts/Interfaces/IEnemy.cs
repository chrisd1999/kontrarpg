namespace Interfaces
{
    public interface IEnemy
    {
        Spawner Spawner { get; set; }
        int EnemyId { get; }
        void Die();
        void TakeDamage(int amount); 
        void DealDamage();
    }
}

