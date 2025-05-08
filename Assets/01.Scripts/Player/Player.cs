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
        
        controller.move.performed += ctx => Move(); // 이동
        controller.move.canceled += ctx => Stop(); // 이동 중지
        controller.look.performed += ctx => Rotate(); // 회전
    }

    private void Move()
    {
        movementDirection = controller.move.ReadValue<Vector2>().normalized;
        _rigidbody.velocity = movementDirection * 5;
    }

    private void Stop()
    {
        movementDirection = Vector2.zero;
        _rigidbody.velocity = movementDirection;
    }

    private void Rotate()
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

        float rotZ = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;
        characterRenderer.flipX = isLeft;
    }
}
