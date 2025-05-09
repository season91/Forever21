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
        // �ʱ� ü�� ����
        currentHealth = maxHealth; 
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        // ü�¹� UI�� ���� Mathf�� ���
        currentHealth = Mathf.Max(currentHealth - amount, 0);
        Debug.Log($"[����] ���� ü��: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (isDead) return;

        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log($"[ȸ��] ���� ü��: {currentHealth}");
    }


    private void Die()
    {
        isDead = true;
        Debug.Log("�÷��̾� ���");

        // ���� ���߱�
        FindObjectOfType<TimeManager>().TimeSet(false);

        // ��� �˾� UI ȣ��
        // UIManager.Instance.DeathPopup(); ����: UIManager�� ShowDeathPopup() ����
    }

}
