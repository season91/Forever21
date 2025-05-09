using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int amount);
}


public interface IDamageDealer
{
    int GetDamage();
}

[RequireComponent(typeof(Collider2D))]
public abstract class HitSystem : MonoBehaviour
{
    [Tooltip("Ÿ�� ��� �±� (��: StringClass.Monster)")]
    [SerializeField] protected string targetTag;

    protected Collider2D collider2d;

    protected virtual void Awake()
    {
        collider2d = GetComponent<Collider2D>();
        collider2d.isTrigger = true;
        if (string.IsNullOrEmpty(targetTag))
            Debug.LogError($"[HitSystem2D] {gameObject.name}�� targetTag�� �������� �ʾҽ��ϴ�.");
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(targetTag))
            return;
        HandleHit(other);
    }

    // ���� Ÿ�� ó��: �ڽ� Ŭ�������� ����
    protected abstract void HandleHit(Collider2D other);
}