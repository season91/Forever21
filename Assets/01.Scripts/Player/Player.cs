using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera _camera;
    private Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;

    private PlayerController controller;
    private Vector2 movementDirection = Vector2.zero;
    private Vector2 lookDirection = Vector2.zero;

    private void Start()
    {
        _camera = Camera.main;

        _rigidbody = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
        
        controller.move.performed += ctx => HandleMoveInput(); // 이동 값 최신화
        controller.move.canceled += ctx => HandleMoveCanceled(); // 이동 중지
        controller.look.performed += ctx => HandleLookInput(); // 회전 최신화
    }
    private void Update()
    {
        Rotate();
    }

    private void FixedUpdate()
    {
        Movment();
    }

    // movementDirection 값 최신화
    private void HandleMoveInput()
    {
        movementDirection = controller.move.ReadValue<Vector2>().normalized;
    }

    // movementDirection 값 중지
    private void HandleMoveCanceled()
    {
        movementDirection = Vector2.zero;
    }

    // lookDirection 값 최신화
    private void HandleLookInput()
    {
        if (_camera == null)
        {
            return;
        }
        
        Vector2 mousePosition = controller.look.ReadValue<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }

    // movementDirection 이동 처리
    private void Movment()
    {
        _rigidbody.velocity = movementDirection * 5;
    }

    // 바라보는 방향으로 캐릭터 회전 처리
    private void Rotate()
    {
        float rotZ = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;
        characterRenderer.flipX = isLeft;
    }

}
