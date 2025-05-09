using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private Camera _camera;
    private Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;

    private PlayerController controller;
    private PlayerStatus status;

    private Vector2 movementDirection = Vector2.zero;
    private Vector2 lookDirection = Vector2.zero;

    protected void Reset()
    {
        // characterRenderer는 Player Object에서 사용할 Player 스크립트의 변수임
        // characterRenderer에 Player 자식 MainSprite를 넣어주는 코드
        characterRenderer = GetComponentInChildren<SpriteRenderer>();
        InputActionAsset inputAsset = Resources.Load<InputActionAsset>("Input/PlayerInputControls");

        // PlayerInput에 할당
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.actions = inputAsset;

        controller = GetComponent<PlayerController>();
        controller.playerInput = playerInput;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        _camera = Camera.main;

        _rigidbody = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>(); 
        controller.Init(); // 명시적 초기화

        controller.move.performed += ctx => Move(); // 이동
        controller.move.canceled += ctx => Stop(); // 이동 중지
        controller.look.performed += ctx => Rotate(); // 회전

        status = GetComponent<PlayerStatus>();
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

    // 경험치 획득 처리
    public void GetExp(int exp)
    {
        status.GainExp(exp);
    }

    // 몬스터 충돌 처리
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // PlayetStatus 피격 처리 호출 에정
        if (collision.gameObject.CompareTag(StringClass.Monster))
        {
            status.TakeDamage(20);
        }
    }

}
