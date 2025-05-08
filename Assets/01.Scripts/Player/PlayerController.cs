using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Camera _camera;

    // ĳ���� ���� �̵� ó���� ���� ȣ��
    private Rigidbody2D _rigidbody;
    // ĳ����
    [SerializeField] private SpriteRenderer characterRenderer;

    // �̵��ϴ� ���� ���� Move
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }
    // �ٶ󺸴� ���� ���� Look
    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Rotate(lookDirection);
    }

    private void FixedUpdate()
    {
        Movment(movementDirection);
    }

    // InputSystem �Է½� �̵� ���� �ٶ󺸴� �� �ʱ�ȭ
    private void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    private void OnLook(InputValue inputValue)
    {
        if (_camera == null)
        {
            return;
        }

        Vector2 mousePosition = inputValue.Get<Vector2>();
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

    // �̵��� ���� ó��->���� �������� FixedUpdate���� ȣ��
    private void Movment(Vector2 direction)
    {
        // stat �ӵ� ���� �������� - ���߿� ���� �ʿ�
        direction = direction * 5;

        // ����
        _rigidbody.velocity = direction;
    }

    // �ٶ󺸴� �������� ĳ���� ȸ�� ó��
    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;
        if(isLeft) Debug.Log("Rotate");
        characterRenderer.flipX = isLeft;
    }
}
