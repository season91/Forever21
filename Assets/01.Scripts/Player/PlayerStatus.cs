using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    private bool isDead = false;

    private void Start()
    {
        // 초기 체력 설정
        currentHealth = maxHealth; 
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        // 체력바 UI를 위해 Mathf를 사용
        currentHealth = Mathf.Max(currentHealth - amount, 0);
        Debug.Log($"[피해] 현재 체력: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (isDead) return;

        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log($"[회복] 현재 체력: {currentHealth}");
    }


    private void Die()
    {
        isDead = true;
        Debug.Log("플레이어 사망");

        // 게임 멈추기
        FindObjectOfType<TimeManager>().TimeSet(false);

        // 사망 팝업 UI 호출
        // UIManager.Instance.DeathPopup(); 가정: UIManager에 ShowDeathPopup() 있음
    }

}
