using TMPro;

public interface IEnemy
{
    Spawner Spawner { get; set; }
    int EnemyId { get; }
    void Die();
    void TakeDamage(); 
    void DealDamage();
}
