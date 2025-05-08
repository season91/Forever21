using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Camera _camera;

    // 캐릭터 실제 이동 처리를 위한 호출
    private Rigidbody2D _rigidbody;
    // 캐릭터
    [SerializeField] private SpriteRenderer characterRenderer;

    // 이동하는 방향 지정 Move
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }
    // 바라보는 방향 지정 Look
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

    // InputSystem 입력시 이동 값과 바라보는 값 초기화
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

    // 이동에 대한 처리->물리 연산으로 FixedUpdate에서 호출
    private void Movment(Vector2 direction)
    {
        // stat 속도 변수 가져오기 - 나중에 수정 필요
        direction = direction * 5;

        // 적용
        _rigidbody.velocity = direction;
    }

    // 바라보는 방향으로 캐릭터 회전 처리
    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;
        if(isLeft) Debug.Log("Rotate");
        characterRenderer.flipX = isLeft;
    }
}
