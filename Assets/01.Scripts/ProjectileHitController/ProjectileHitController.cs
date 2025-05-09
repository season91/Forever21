using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ProjectileHitController : MonoBehaviour
{
    [Tooltip("���� ���� ��� �±�")] [SerializeField] private string targetTag = StringClass.Monster;

    private IDamageDealer damageDealer;

    /// <summary>
    /// �߻�ü ���� �� ȣ���Ͽ� ���ݷ��� �����մϴ�
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
            Debug.LogError($"[ProjectileHitController] {gameObject.name}�� IDamageDealer�� �������� �ʾҽ��ϴ�.");
            return;
        }
        if (other.TryGetComponent<IDamageable>(out var target))
        {
            int dmg = damageDealer.GetDamage();
            target.TakeDamage(dmg);
            Debug.Log($"[Debug] {other.gameObject.name}���� {dmg}��ŭ ������ ����");
        }
        Destroy(gameObject);
    }
}
