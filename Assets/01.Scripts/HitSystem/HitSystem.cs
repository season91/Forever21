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
    [Tooltip("타격 대상 태그 (예: StringClass.Monster)")]
    [SerializeField] protected string targetTag;

    protected Collider2D collider2d;

    protected virtual void Awake()
    {
        collider2d = GetComponent<Collider2D>();
        collider2d.isTrigger = true;
        if (string.IsNullOrEmpty(targetTag))
            Debug.LogError($"[HitSystem2D] {gameObject.name}에 targetTag가 설정되지 않았습니다.");
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(targetTag))
            return;
        HandleHit(other);
    }

    // 실제 타격 처리: 자식 클래스에서 구현
    protected abstract void HandleHit(Collider2D other);
}