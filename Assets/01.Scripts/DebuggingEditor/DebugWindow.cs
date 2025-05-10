using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;


/// <summary>
/// ������� �� ����Ͻð�
/// Input.GetKeyDown �̷��� �� ����� �ű�ʽÿ�!!!
/// ���߿� ������� �ɸ��� �ƿ����� ������ ȸ�ʸ��� ��ٸ��ϴ�...
/// </summary>
public class DebugWindow : EditorWindow  // ����Ƽ���� �����츦 ������ ��ӹ޾ƾ��ϴ� Ŭ����
{
    private int inputValue = 0;     //  ������� �� ����� ���� (�ӽ�)


    [MenuItem("Window/My Debug Tool")]   //  ����Ƽ ������ ���� �޴��� ��ư�� �߰��ϰ�, �� ��ư�� ������ �� ȣ��� �Լ��� �ؿ� ����
    public static void ShowWindow()    // ����Ƽ �������� window��ư�� ������ my debug tool�̶�� ��ư�� ���� ���������̰�, �װ� ������ ȣ�� �� �Լ���
    {
        GetWindow<DebugWindow>("Debug Tool");   // ����Ƽ���� ������ â�� ����ִ� �Լ�
    }

    void OnGUI()  // �������� ������ �Լ� update() �Լ��� ����
    {
        EditorGUILayout.LabelField("Enter a number:");   //  �� �� ����
        inputValue = EditorGUILayout.IntField("Number", inputValue);  //  ���� ��ȯ (�Է� â)

        if (GUILayout.Button("Print Number"))  // ��ư ����
        {
            Debug.Log("Value of Number : " + inputValue);  // ��ư ������ �� ȣ��� ����
        }
        EditorGUILayout.Space();   // �� �� ����
        EditorGUILayout.Space();   // �� �� ����

        if (GUILayout.Button("Player Add Property"))  // ������ debug �Լ��̰�, Player�� 13��° ���� ���� ������ ����
        {
            Player.Instance.Debug_GetPlayerAttackSystem().AddProperty(AttackHandlerEnum.Arrow, AttackSystemManager.instance.GetProperty(PropertyString.AddCounter));
        }

    }
}
