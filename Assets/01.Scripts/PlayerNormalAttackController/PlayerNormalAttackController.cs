using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerNormalAttackController : MonoBehaviour, IDamageDealer
{
    [Tooltip("�߻��� ����ü ������ (Prefab�� 'ProjectileHitController' ��ũ��Ʈ�� ���Ե��� �ʾҴٸ� ��Ÿ�ӿ� �߰��˴ϴ�)")]
    [SerializeField] private GameObject projectilePrefab;
    [Tooltip("�߻� ��ġ")]
    [SerializeField] private Transform firePoint;
    [Tooltip("�÷��̾� ���ݷ�")]
    [SerializeField] private int attackPower = 10;
    [Tooltip("����ü �ӵ�")]
    [SerializeField] private float projectileSpeed = 10f;
    [Tooltip("����ü �߻� ���� (��)")]
    [SerializeField] private float fireRate = 0.5f;
    [Tooltip("�߻�ü �ڵ� ���� �ð� (��)")]
    [SerializeField] private float lifetime = 5f;

#if UNITY_EDITOR
    private void Reset()
    {
        fireRate = 0.5f;
        lifetime = 5f;
    }
#endif

    private void Start()
    {
        if (fireRate <= 0) fireRate = 0.5f;
        if (lifetime <= 0) lifetime = 5f;
        InvokeRepeating(nameof(ShootProjectile), 0f, fireRate);
    }

    private void ShootProjectile()
    {
        if (projectilePrefab == null || firePoint == null) return;

        // �߻� ��ġ ������
        Vector3 spawnPos = firePoint.position + Vector3.up * 1f;
        var proj = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

        // Rigidbody2D ����
        var rb = proj.GetComponent<Rigidbody2D>() ?? proj.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.velocity = Vector2.up * projectileSpeed;

        // ProjectileHitController ���� (���� �߰� ���)
        var hitCtrl = proj.GetComponent<ProjectileHitController>();
        if (hitCtrl == null)
        {
            hitCtrl = proj.AddComponent<ProjectileHitController>();
        }
        hitCtrl.SetDamageDealer(this);

        // �ڵ� ����
        Destroy(proj, lifetime);
    }

    public int GetDamage() => attackPower;
}