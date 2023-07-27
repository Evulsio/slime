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

    // ���� ���۵� �� ȣ��Ǵ� �Լ�
    private void Start()
    {
        // ���� ��� �� ������Ʈ ������ ���� �ڷ�ƾ ����
        StartCoroutine(PlayMusicAndRestrictMovement());
    }

    // ���� ��� �� ������Ʈ ������ ���� �ڷ�ƾ
    private IEnumerator PlayMusicAndRestrictMovement()
    {
        // ī��Ʈ�ٿ� �ð� ���� (3��)
        float countdownTime = 3f;

        // ī��Ʈ�ٿ� �ؽ�Ʈ �ʱ�ȭ
        countdownText.text = Mathf.RoundToInt(countdownTime).ToString();

        // ���� ���
        musicAudioSource.Play();
        isMusicPlaying = true;

        // ������Ʈ1�� ������ ����
        objectToMove1.GetComponent<Rigidbody>().isKinematic = true;

        // ������Ʈ2�� ������ ����
        objectToMove2.GetComponent<Rigidbody>().isKinematic = true;

        // ī��Ʈ�ٿ� �ؽ�Ʈ ������Ʈ �ڷ�ƾ ����
        StartCoroutine(UpdateCountdownText(countdownTime));

        // ������ ���� ������ ��ٸ�
        while (musicAudioSource.isPlaying)
        {
            yield return null;
        }

        // ������ ������ ������Ʈ1�� ������Ʈ2�� ������ ���� ����
        objectToMove1.GetComponent<Rigidbody>().isKinematic = false;
        objectToMove2.GetComponent<Rigidbody>().isKinematic = false;
        isMusicPlaying = false;

        // ī��Ʈ�ٿ� �ؽ�Ʈ ����
        countdownText.enabled = false;
    }

    // ī��Ʈ�ٿ� �ؽ�Ʈ ������Ʈ �ڷ�ƾ
    private IEnumerator UpdateCountdownText(float countdownTime)
    {
        while (countdownTime > 0f)
        {
            // ī��Ʈ�ٿ� �ؽ�Ʈ ������Ʈ (������ ��ȯ)
            countdownText.text = Mathf.RoundToInt(countdownTime).ToString();

            // 0.1�ʸ��� ������Ʈ
            yield return new WaitForSeconds(1f);

            countdownTime -= 1f;
        }

        // ī��Ʈ�ٿ��� ������ �ؽ�Ʈ�� ��Ȱ��ȭ
        countdownText.enabled = false;
    }
}