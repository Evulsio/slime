using UnityEngine;

public class CameraSpeedline : MonoBehaviour
{
    public Material speedlineMaterial; // 스피드라인으로 사용할 메테리얼
    public RaceGameManager raceGameManager; // RaceGameManager 스크립트에 대한 참조

    private Camera mainCamera; // 메인 카메라를 저장할 변수

    private void Start()
    {
        // 메인 카메라 컴포넌트를 가져옵니다.
        mainCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        // RaceGameManager에서 플레이어의 속도를 가져옵니다.
        float Speed = RaceGameManager.Speed;

        // 플레이어의 속도가 원하는 속도(5000f) 이상인지 확인하여 스피드라인 효과를 활성화 또는 비활성화합니다.
        if (Speed >= 5000f) // 원하는 속도에 맞게 조절하세요.
        {
            EnableSpeedlineEffect();
        }
        else
        {
            DisableSpeedlineEffect();
        }
    }

    private void EnableSpeedlineEffect()
    {
        // 메인 카메라에 스피드라인 메테리얼을 적용합니다.
        mainCamera.SetReplacementShader(speedlineMaterial.shader, null);
    }

    private void DisableSpeedlineEffect()
    {
        // 메인 카메라의 렌더링 셰이더를 기본 셰이더로 변경하여 스피드라인 효과를 비활성화합니다.
        mainCamera.ResetReplacementShader();
    }
}