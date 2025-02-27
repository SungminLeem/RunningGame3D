using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // 따라갈 플레이어
    public Vector3 offset = new Vector3(0, 10, -10); // 카메라 위치 조정
    public float smoothSpeed = 0.125f;  // 부드러운 이동 속도

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(player); // 카메라가 플레이어를 바라보게 함
        }
    }
}
