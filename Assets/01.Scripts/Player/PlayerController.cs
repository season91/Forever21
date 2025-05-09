using UnityEngine;
using UnityEngine.InputSystem;

// 입력 처리만 담당
public class PlayerController : MonoBehaviour
{
    public InputAction move;
    public InputAction look;
    public PlayerInput playerInput;

    // controller가 바인딩 해주는 구조는 지양하기 위해, 사용하고자 하는 곳에서 바인딩
    public void Init()
    {
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];
        look = playerInput.actions["Look"];

        move.Enable();
        look.Enable();
    }
}
