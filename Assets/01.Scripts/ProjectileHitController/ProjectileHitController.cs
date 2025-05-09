using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ProjectileHitController : MonoBehaviour
{
    [Tooltip("피해 판정 대상 태그")] [SerializeField] private string targetTag = StringClass.Monster;

    private IDamageDealer damageDealer;

    /// <summary>
    /// 발사체 생성 후 호출하여 공격력을 설정합니다
    /// </summary>
    public void SetDamageDealer(IDamageDealer dealer)
    {
        damageDealer = dealer;
    }

    private void Awake()
    {
        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(targetTag)) return;
        if (damageDealer == null)
        {
            Debug.LogError($"[ProjectileHitController] {gameObject.name}에 IDamageDealer가 설정되지 않았습니다.");
            return;
        }
        if (other.TryGetComponent<IDamageable>(out var target))
        {
            int dmg = damageDealer.GetDamage();
            target.TakeDamage(dmg);
            Debug.Log($"[Debug] {other.gameObject.name}에게 {dmg}만큼 데미지 적용");
        }
        Destroy(gameObject);
    }
}
