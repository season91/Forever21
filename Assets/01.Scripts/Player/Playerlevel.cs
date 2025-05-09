using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerlevel : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private int currentExp = 0;
    [SerializeField] private int expToNextLevel = 100;

    public void GainExp(int amount)
    {
        currentExp += amount;
        Debug.Log($"경험치 획득: {amount} (총: {currentExp}/{expToNextLevel})");

        while (currentExp >= expToNextLevel)
        {
            currentExp -= expToNextLevel;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        expToNextLevel = Mathf.RoundToInt(expToNextLevel * 1.2f); // 경험치 통 증가
        Debug.Log($"레벨업! 현재 레벨: {level}");
    }
}
