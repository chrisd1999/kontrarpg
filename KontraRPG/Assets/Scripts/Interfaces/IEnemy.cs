namespace Interfaces
{
    public interface IEnemy
    {
        Spawner Spawner { get; set; }
        void Die();
        void TakeDamage(int amount); 
        void DealDamage();
    }
}

