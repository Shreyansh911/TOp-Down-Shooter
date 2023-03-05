public interface IHealth
{
    int CurrentHelth { get; }
    void TakeDamage(int Damage);

    void Die();
}
