using TMPro;

public interface IEnemy
{
    Spawner Spawner { get; set; }
    void Die();
    void TakeDamage(); 
    void DealDamage();
}
