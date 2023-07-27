using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicController : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public GameObject objectToMove1;
    public GameObject objectToMove2;
    public Text countdownText;
    private bool isMusicPlaying = false;

    // 씬이 시작될 때 호출되는 함수
    private void Start()
    {
        // 음악 재생 및 오브젝트 움직임 제한 코루틴 시작
        StartCoroutine(PlayMusicAndRestrictMovement());
    }

    // 음악 재생 및 오브젝트 움직임 제한 코루틴
    private IEnumerator PlayMusicAndRestrictMovement()
    {
        // 카운트다운 시간 설정 (3초)
        float countdownTime = 3f;

        // 카운트다운 텍스트 초기화
        countdownText.text = Mathf.RoundToInt(countdownTime).ToString();

        // 음악 재생
        musicAudioSource.Play();
        isMusicPlaying = true;

        // 오브젝트1의 움직임 제한
        objectToMove1.GetComponent<Rigidbody>().isKinematic = true;

        // 오브젝트2의 움직임 제한
        objectToMove2.GetComponent<Rigidbody>().isKinematic = true;

        // 카운트다운 텍스트 업데이트 코루틴 시작
        StartCoroutine(UpdateCountdownText(countdownTime));

        // 음악이 끝날 때까지 기다림
        while (musicAudioSource.isPlaying)
        {
            yield return null;
        }

        // 음악이 끝나면 오브젝트1과 오브젝트2의 움직임 제한 해제
        objectToMove1.GetComponent<Rigidbody>().isKinematic = false;
        objectToMove2.GetComponent<Rigidbody>().isKinematic = false;
        isMusicPlaying = false;

        // 카운트다운 텍스트 삭제
        countdownText.enabled = false;
    }

    // 카운트다운 텍스트 업데이트 코루틴
    private IEnumerator UpdateCountdownText(float countdownTime)
    {
        while (countdownTime > 0f)
        {
            // 카운트다운 텍스트 업데이트 (정수로 변환)
            countdownText.text = Mathf.RoundToInt(countdownTime).ToString();

            // 0.1초마다 업데이트
            yield return new WaitForSeconds(1f);

            countdownTime -= 1f;
        }

        // 카운트다운이 끝나면 텍스트를 비활성화
        countdownText.enabled = false;
    }
}