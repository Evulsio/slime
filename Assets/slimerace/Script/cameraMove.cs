using UnityEngine;
using UnityEngine.UI;

public class cameraMove : MonoBehaviour
{
    public Transform player; // 따라다닐 플레이어의 Transform 컴포넌트
    public Vector3 offset = new Vector3(0f, 5f, -10f); // 카메라와 플레이어 간의 초기 오프셋
    public float smoothSpeed = 0.5f; // 카메라 이동 스무딩 속도
    public float stoppingZCoordinate = 20f; // 플레이어가 도달하면 카메라를 멈출 z 축 좌표
    public RaceGameManager raceGameManager;
    public Text finishText;

    private bool shouldFollow = true; // 카메라가 플레이어를 따라가는지 여부를 결정하는 플래그

    private void LateUpdate()
    {
        float Speed = RaceGameManager.Speed;

        if (Speed >= 5000f) // 이 부분에 원하는 속도를 설정
        {
            gameObject.GetComponent<CustomPostProcessing>().enabled = true;
        }
        else
        {
            // Resume the player's rotation
            gameObject.GetComponent<CustomPostProcessing>().enabled = false;
        }
        if (shouldFollow)
        {
            // 플레이어의 z축 좌표를 확인
            float playerZCoordinate = player.position.z;

            // 플레이어 위치에 따라 카메라를 이동시킴
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // 플레이어의 z 축 좌표가 일정 좌표(stoppingZCoordinate)에 도달하면 카메라를 멈춥니다.
            if (playerZCoordinate >= stoppingZCoordinate)
            {
                finishText.text = "Finish!";
                shouldFollow = false; // 카메라를 더 이상 플레이어를 따라가지 않도록 플래그를 비활성화합니다.
            }
        }
    }
}