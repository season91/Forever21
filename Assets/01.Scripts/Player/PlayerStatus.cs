using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatus : MonoBehaviour
{
    [Header("체력")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    private bool isDead = false;

    [Header("레벨")]
    [SerializeField] private int level = 1;
    [SerializeField] private int currentExp = 0;
    [SerializeField] private int expToNextLevel = 100;
    [Tooltip("레벨업 시 경험치 증가 비율 (예: 1.2 = 20% 증가)")]
    [SerializeField] private float expGrowthRate = 1.2f;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        // 테스트용 키 입력
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Heal(20);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GainExp(50);
        }
    }

    // ===============================
    // 체력 관련
    // ===============================

    public void TakeDamage(int amount)  //플레이어가 데미지 받을 때 호출되는 함수
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);
        Debug.Log($"[Status] {amount} 데미지를 입음 → 체력: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)    //플레이어가 회복할 때 호출되는 함수
    {
        if (isDead) return;

        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        Debug.Log($"[Status] {amount} 회복됨 → 체력: {currentHealth}/{maxHealth}");
    }

    private void Die()    //플레이어가 사망할 때 호출되는 함수
    {
        isDead = true;
        Debug.Log("[Status] 플레이어 사망");

        // FindObjectOfType<TimeManager>().TimeSet(false); // FindObjectOfType말고 다른 방법으로 가져오는게 좋음. Tag 방식으로 찾아라. 싱글톤으로

        // UIManager.Instance.ShowDeathPopup(); // 사망팝업 UI 필요시 연결
    }

    // ===============================
    // 경험치 / 레벨업 관련
    // ===============================

    public void GainExp(int amount) //플레이어가 경험치를 얻을 때 호출되는 함수
    {
        currentExp += amount;
        Debug.Log($"[Status] 경험치 획득: +{amount} → {currentExp}/{expToNextLevel}");

        while (currentExp >= expToNextLevel)
        {
            currentExp -= expToNextLevel;
            LevelUp();
        }
    }


    private void LevelUp()  // 플레이어가 레벨업할 때 호출되는 함수
    {
        level++;
        expToNextLevel = Mathf.RoundToInt(expToNextLevel * expGrowthRate);
        Debug.Log($"레벨업! 현재 레벨: {level} | 다음 필요 경험치: {expToNextLevel}");
    }

    // ===============================
    // 데이터를 가져갈 때 사용
    // ===============================

    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;
    public int GetLevel() => level;
    public int GetCurrentExp() => currentExp;
    public int GetExpToNextLevel() => expToNextLevel;
}
