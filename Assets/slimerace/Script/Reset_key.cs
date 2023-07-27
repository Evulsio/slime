using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Reset_key : MonoBehaviour
{
    public Slider progressBar;
    public float incrementAmount = 1f;
    public InputActionReference increaseAction; // 증가 액션에 대한 참조
    public InputActionReference resetAction;    // 초기화 액션에 대한 참조
    public GameObject particlePrefab;           // 파티클 시스템이 들어있는 프리팹을 Inspector에서 연결해주세요.
    public RandomizedRaceGameManager raceGameManager; // RandomizedRaceGameManager 스크립트에 접근하기 위한 변수

    private void OnEnable()
    {
        // Input System 액션들을 활성화합니다.
        increaseAction.action.Enable();
        resetAction.action.Enable();
    }

    private void OnDisable()
    {
        // Input System 액션들을 비활성화합니다.
        increaseAction.action.Disable();
        resetAction.action.Disable();
    }

    private void Update()
    {
        // 증가 액션이 실행될 때
        if (increaseAction.action.triggered)
        {
            // incrementAmount만큼 프로그레스 바 값을 증가시킵니다.
            progressBar.value += incrementAmount;

            // 최소값과 최대값 범위 내에서 값을 조정합니다.
            progressBar.value = Mathf.Clamp(progressBar.value, progressBar.minValue, progressBar.maxValue);
        }

        // 초기화 액션이 실행될 때
        if (resetAction.action.triggered)
        {
            // 게이지 바의 값이 100 이상일 때만 초기화합니다.
            if (progressBar.value >= 100f)
            {
                // 프로그레스 바 값을 초기화합니다.
                progressBar.value = progressBar.minValue;

                // 파티클 시스템을 발동시킬 위치를 대상의 위치로 설정합니다.
                Vector3 targetPosition = transform.position;

                // 파티클 시스템 프리팹을 대상 위치에 인스턴스화합니다.
                GameObject particleInstance = Instantiate(particlePrefab, targetPosition, Quaternion.identity);

                // RandomizedRaceGameManager 스크립트의 Speed 값을 감소시킵니다.
                if (raceGameManager != null)
                {
                    // 원하는 값으로 수정해주세요.
                    float decreaseAmount = 150f;
                    raceGameManager.Speed -= decreaseAmount;
                }
            }
        }
    }
}