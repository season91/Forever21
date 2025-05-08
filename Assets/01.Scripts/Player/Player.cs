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
        
        controller.move.performed += ctx => HandleMoveInput(); // �̵� �� �ֽ�ȭ
        controller.move.canceled += ctx => HandleMoveCanceled(); // �̵� ����
        controller.look.performed += ctx => HandleLookInput(); // ȸ�� �ֽ�ȭ
    }
    private void Update()
    {
        Rotate();
    }

    private void FixedUpdate()
    {
        Movment();
    }

    // movementDirection �� �ֽ�ȭ
    private void HandleMoveInput()
    {
        movementDirection = controller.move.ReadValue<Vector2>().normalized;
    }

    // movementDirection �� ����
    private void HandleMoveCanceled()
    {
        movementDirection = Vector2.zero;
    }

    // lookDirection �� �ֽ�ȭ
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

    // movementDirection �̵� ó��
    private void Movment()
    {
        _rigidbody.velocity = movementDirection * 5;
    }

    // �ٶ󺸴� �������� ĳ���� ȸ�� ó��
    private void Rotate()
    {
        float rotZ = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;
        characterRenderer.flipX = isLeft;
    }

}
