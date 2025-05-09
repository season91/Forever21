using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ProjectileHitController : MonoBehaviour
{
    [Tooltip("���� ���� ��� �±�")] [SerializeField] private string targetTag = StringClass.Monster;

    private IDamageDealer damageDealer;

    public void SetDamageDealer(IDamageDealer dealer) // �߻�ü ���� �� ȣ���Ͽ� ���ݷ� ����
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
        if (!other.CompareTag(targetTag)) return; // ��� �ڵ�
        if (damageDealer == null) // �� ���� ó��
        {
            Debug.LogError($"[ProjectileHitController] {gameObject.name}�� IDamageDealer�� �������� �ʾҽ��ϴ�.");
            return;
        }
        if (other.TryGetComponent<IDamageable>(out var target)) // IDamageable �ִ� 
        {
            int dmg = damageDealer.GetDamage();
            target.TakeDamage(dmg);
            Debug.Log($"[Debug] {other.gameObject.name}���� {dmg}��ŭ ������ ����");
        }
        Destroy(gameObject);
    }
}
