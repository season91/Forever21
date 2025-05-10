using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;

public class DebugWindow : EditorWindow
{
    private int inputValue = 0;


    [MenuItem("Window/My Debug Tool")]
    public static void ShowWindow()
    {
        GetWindow<DebugWindow>("Debug Tool");
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Enter a number:");
        inputValue = EditorGUILayout.IntField("Number", inputValue);

        if (GUILayout.Button("Print Number"))
        {
            Debug.Log("Value of Number : " + inputValue);
        }
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        if (GUILayout.Button("Player Add Property"))
        {
            Player.Instance.Debug_GetPlayerAttackSystem().AddProperty(AttackHandlerEnum.Arrow, AttackSystemManager.instance.GetProperty(PropertyString.AddCounter));
        }

    }
}
