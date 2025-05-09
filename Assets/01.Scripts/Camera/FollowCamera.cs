using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothSpeed = 5f; // 부드러운 이동 속도
    private Vector3 offset; // 초기 거리

    private void Reset()
    {
        playerTransform = FindObjectOfType<Player>().gameObject.transform;
    }

    private void Start()
    {
        if (playerTransform == null) playerTransform = GameObject.FindWithTag(StringClass.Player).transform;
        offset = transform.position - playerTransform.position;
    }

    // 이동이 끝난 후 실행
    private void LateUpdate()
    {
        if (playerTransform == null) return;

        Vector3 pos = playerTransform.position + offset;
        pos.z = transform.position.z;

        // 부드러운 이동 처리
        transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed * Time.deltaTime);
    }
}
