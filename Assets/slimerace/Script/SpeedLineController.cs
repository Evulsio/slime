using UnityEngine;

public class SpeedLineController : MonoBehaviour
{
    public Transform playerObject;
    public Material speedLineMaterial;
    public Color activeColor; // 활성화될 스피드 라인 색상 값
    public Color inactiveColor; // 비활성화될 스피드 라인 색상 값
    public float speedThreshold = 5f; // 일정 속도 이상일 때 활성화할 속도 값

    private Renderer speedLineRenderer;
    private Rigidbody playerRigidbody;

    private void Start()
    {
        speedLineRenderer = GetComponent<Renderer>();
        playerRigidbody = playerObject.GetComponent<Rigidbody>();
        speedLineRenderer.material.color = inactiveColor;
    }

    private void Update()
    {
        float playerSpeed = playerRigidbody.velocity.magnitude;

        // 플레이어 속도에 따라 스피드 라인 메테리얼을 활성화 또는 비활성화합니다.
        if (playerSpeed >= speedThreshold)
        {
            if (speedLineRenderer.material.color != activeColor)
            {
                speedLineRenderer.material.color = activeColor;
            }
        }
        else
        {
            if (speedLineRenderer.material.color != inactiveColor)
            {
                speedLineRenderer.material.color = inactiveColor;
            }
        }
    }
}