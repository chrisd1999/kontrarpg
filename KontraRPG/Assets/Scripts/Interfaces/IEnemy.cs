using TMPro;

public interface IEnemy
{
    public Spawner Spawner { get; set; }
    void Die();
    void TakeDamage(); 
    void DealDamage();
}
