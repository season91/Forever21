using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatus : MonoBehaviour
{
    [Header("ü��")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    private bool isDead = false;

    [Header("����")]
    [SerializeField] private int level = 1;
    [SerializeField] private int currentExp = 0;
    [SerializeField] private int expToNextLevel = 100;
    [Tooltip("������ �� ����ġ ���� ���� (��: 1.2 = 20% ����)")]
    [SerializeField] private float expGrowthRate = 1.2f;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        // �׽�Ʈ�� Ű �Է�
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
    // ü�� ����
    // ===============================

    public void TakeDamage(int amount)  //�÷��̾ ������ ���� �� ȣ��Ǵ� �Լ�
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);
        Debug.Log($"[Status] {amount} �������� ���� �� ü��: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)    //�÷��̾ ȸ���� �� ȣ��Ǵ� �Լ�
    {
        if (isDead) return;

        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        Debug.Log($"[Status] {amount} ȸ���� �� ü��: {currentHealth}/{maxHealth}");
    }

    private void Die()    //�÷��̾ ����� �� ȣ��Ǵ� �Լ�
    {
        isDead = true;
        Debug.Log("[Status] �÷��̾� ���");

        // FindObjectOfType<TimeManager>().TimeSet(false); // FindObjectOfType���� �ٸ� ������� �������°� ����. Tag ������� ã�ƶ�. �̱�������

        // UIManager.Instance.ShowDeathPopup(); // ����˾� UI �ʿ�� ����
    }

    // ===============================
    // ����ġ / ������ ����
    // ===============================

    public void GainExp(int amount) //�÷��̾ ����ġ�� ���� �� ȣ��Ǵ� �Լ�
    {
        currentExp += amount;
        Debug.Log($"[Status] ����ġ ȹ��: +{amount} �� {currentExp}/{expToNextLevel}");

        while (currentExp >= expToNextLevel)
        {
            currentExp -= expToNextLevel;
            LevelUp();
        }
    }


    private void LevelUp()  // �÷��̾ �������� �� ȣ��Ǵ� �Լ�
    {
        level++;
        expToNextLevel = Mathf.RoundToInt(expToNextLevel * expGrowthRate);
        Debug.Log($"������! ���� ����: {level} | ���� �ʿ� ����ġ: {expToNextLevel}");
    }

    // ===============================
    // �����͸� ������ �� ���
    // ===============================

    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;
    public int GetLevel() => level;
    public int GetCurrentExp() => currentExp;
    public int GetExpToNextLevel() => expToNextLevel;
}
