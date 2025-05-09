using UnityEngine;
using UnityEngine.InputSystem;

// 입력 처리만 담당
public class PlayerController : MonoBehaviour
{
    public InputAction move;
    public InputAction look;
    public PlayerInput playerInput;

    public void Init()
    {
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];
        look = playerInput.actions["Look"];

        move.Enable();
        look.Enable();
    }
}
