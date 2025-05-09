using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothSpeed = 5f; // �ε巯�� �̵� �ӵ�
    private Vector3 offset; // �ʱ� �Ÿ�

    private void Reset()
    {
        playerTransform = FindObjectOfType<Player>().gameObject.transform;
    }

    private void Start()
    {
        if (playerTransform == null) playerTransform = GameObject.FindWithTag(StringClass.Player).transform;
        offset = transform.position - playerTransform.position;
    }

    // �̵��� ���� �� ����
    private void LateUpdate()
    {
        if (playerTransform == null) return;

        Vector3 pos = playerTransform.position + offset;
        pos.z = transform.position.z;

        // �ε巯�� �̵� ó��
        transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed * Time.deltaTime);
    }
}
