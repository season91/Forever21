using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ProjectileHitController : MonoBehaviour
{
    [Tooltip("피해 판정 대상 태그")] [SerializeField] private string targetTag = StringClass.Monster;

    private IDamageDealer damageDealer;

    public void SetDamageDealer(IDamageDealer dealer) // 발사체 생성 후 호출하여 공격력 설정
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
        if (!other.CompareTag(targetTag)) return; // 방어 코딩
        if (damageDealer == null) // 널 예외 처리
        {
            Debug.LogError($"[ProjectileHitController] {gameObject.name}에 IDamageDealer가 설정되지 않았습니다.");
            return;
        }
        if (other.TryGetComponent<IDamageable>(out var target)) // IDamageable 있는 
        {
            int dmg = damageDealer.GetDamage();
            target.TakeDamage(dmg);
            Debug.Log($"[Debug] {other.gameObject.name}에게 {dmg}만큼 데미지 적용");
        }
        Destroy(gameObject);
    }
}
