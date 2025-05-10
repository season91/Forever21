using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;


/// <summary>
/// 디버깅할 때 사용하시고
/// Input.GetKeyDown 이런거 다 여기로 옮기십시오!!!
/// 나중에 안지운거 걸리면 아영님의 따끔한 회초리가 기다립니다...
/// </summary>
public class DebugWindow : EditorWindow  // 유니티에서 윈도우를 띄울려면 상속받아야하는 클래스
{
    private int inputValue = 0;     //  디버깅할 때 사용할 변수 (임시)


    [MenuItem("Window/My Debug Tool")]   //  유니티 에디터 상의 메뉴에 버튼을 추가하고, 그 버튼을 눌렀을 때 호출될 함수를 밑에 구현
    public static void ShowWindow()    // 유니티 에디터의 window버튼을 누르면 my debug tool이라는 버튼이 새로 생겼을것이고, 그거 누르면 호출 될 함수임
    {
        GetWindow<DebugWindow>("Debug Tool");   // 유니티에서 윈도우 창을 띄워주는 함수
    }

    void OnGUI()  // 윈도우의 프레임 함수 update() 함수와 같음
    {
        EditorGUILayout.LabelField("Enter a number:");   //  한 줄 적기
        inputValue = EditorGUILayout.IntField("Number", inputValue);  //  변수 변환 (입력 창)

        if (GUILayout.Button("Print Number"))  // 버튼 생성
        {
            Debug.Log("Value of Number : " + inputValue);  // 버튼 눌렀을 때 호출될 로직
        }
        EditorGUILayout.Space();   // 한 줄 띄우기
        EditorGUILayout.Space();   // 한 줄 띄우기

        if (GUILayout.Button("Player Add Property"))  // 유성민 debug 함수이고, Player의 13번째 줄을 보면 설명이 있음
        {
            Player.Instance.Debug_GetPlayerAttackSystem().AddProperty(AttackHandlerEnum.Arrow, AttackSystemManager.instance.GetProperty(PropertyString.AddCounter));
        }

    }
}
