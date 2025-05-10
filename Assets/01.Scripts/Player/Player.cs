using UnityEngine;
using UnityEngine.InputSystem;

// 1. property manager �� ��� �Ӽ��� �����ִ�.
// 2. baseattackhander�� �ִ� dictionary�� ��� ����Ÿ���� �����ִ�.
// 3. ����ҰŸ� enum�����, projectile����� stringclass property�� �װ� �߰��ϰ�
// �ڷᱸ���� �� �������



public class Player : MonoBehaviour
{
    public static Player Instance;

    private Camera _camera;
    private Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;

    private PlayerController controller;
    private PlayerStatus status;

    //������ �߰�
    [SerializeField] PlayerAttackSystem playerAttackSystem;

    //������ �߰�
    private void Update()
    {
        playerAttackSystem.Attack();
        //debug
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAttackSystem.AddProperty(AttackHandlerEnum.Arrow, AttackSystemManager.instance.GetProperty(PropertyString.AddCounter));
            playerAttackSystem.AddAttack(AttackHandlerEnum.Dager);
            playerAttackSystem.AddAttack(AttackHandlerEnum.Axe);
            playerAttackSystem.AddAttack(AttackHandlerEnum.Hammer);
            playerAttackSystem.AddAttack(AttackHandlerEnum.Sword);
        }
    }

    private Vector2 movementDirection = Vector2.zero;
    private Vector2 lookDirection = Vector2.zero;

    protected void Reset()
    {
        // characterRenderer�� Player Object���� ����� Player ��ũ��Ʈ�� ������
        // characterRenderer�� Player �ڽ� MainSprite�� �־��ִ� �ڵ�
        characterRenderer = GetComponentInChildren<SpriteRenderer>();
        InputActionAsset inputAsset = Resources.Load<InputActionAsset>("Input/PlayerInputControls");

        // PlayerInput�� �Ҵ�
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.actions = inputAsset;

        controller = GetComponent<PlayerController>();
        controller.playerInput = playerInput;

        //�������� ����
        playerAttackSystem = GetComponent<PlayerAttackSystem>();
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
        controller.Init(); // ����� �ʱ�ȭ

        controller.move.performed += ctx => Move(); // �̵�
        controller.move.canceled += ctx => Stop(); // �̵� ����
        controller.look.performed += ctx => Rotate(); // ȸ��

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

    // ����ġ ȹ�� ó��
    public void GetExp(int exp)
    {
        status.GainExp(exp);
    }

    // ���� �浹 ó��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // PlayetStatus �ǰ� ó�� ȣ�� ����
        if (collision.gameObject.CompareTag(StringClass.Monster))
        {
            status.TakeDamage(20);
        }
    }

}
