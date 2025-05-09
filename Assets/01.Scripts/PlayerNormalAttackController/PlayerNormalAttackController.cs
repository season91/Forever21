using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerNormalAttackController : MonoBehaviour, IDamageDealer
{
    [Tooltip("발사할 투사체 프리팹 (Prefab에 'ProjectileHitController' 스크립트가 포함되지 않았다면 런타임에 추가됩니다)")]
    [SerializeField] private GameObject projectilePrefab;
    [Tooltip("발사 위치")]
    [SerializeField] private Transform firePoint;
    [Tooltip("플레이어 공격력")]
    [SerializeField] private int attackPower = 10;
    [Tooltip("투사체 속도")]
    [SerializeField] private float projectileSpeed = 10f;
    [Tooltip("투사체 발사 간격 (초)")]
    [SerializeField] private float fireRate = 0.5f;
    [Tooltip("발사체 자동 제거 시간 (초)")]
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

        // 발사 위치 오프셋
        Vector3 spawnPos = firePoint.position + Vector3.up * 1f;
        var proj = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

        // Rigidbody2D 세팅
        var rb = proj.GetComponent<Rigidbody2D>() ?? proj.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.velocity = Vector2.up * projectileSpeed;

        // ProjectileHitController 세팅 (동적 추가 허용)
        var hitCtrl = proj.GetComponent<ProjectileHitController>();
        if (hitCtrl == null)
        {
            hitCtrl = proj.AddComponent<ProjectileHitController>();
        }
        hitCtrl.SetDamageDealer(this);

        // 자동 제거
        Destroy(proj, lifetime);
    }

    public int GetDamage() => attackPower;
}