using UnityEngine;
using UnityEngine.UI;

public class cameraMove : MonoBehaviour
{
    public Transform player; // ����ٴ� �÷��̾��� Transform ������Ʈ
    public Vector3 offset = new Vector3(0f, 5f, -10f); // ī�޶�� �÷��̾� ���� �ʱ� ������
    public float smoothSpeed = 0.5f; // ī�޶� �̵� ������ �ӵ�
    public float stoppingZCoordinate = 20f; // �÷��̾ �����ϸ� ī�޶� ���� z �� ��ǥ
    public RaceGameManager raceGameManager;
    public Text finishText;

    private bool shouldFollow = true; // ī�޶� �÷��̾ ���󰡴��� ���θ� �����ϴ� �÷���

    private void LateUpdate()
    {
        float Speed = RaceGameManager.Speed;

        if (Speed >= 5000f) // �� �κп� ���ϴ� �ӵ��� ����
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
            // �÷��̾��� z�� ��ǥ�� Ȯ��
            float playerZCoordinate = player.position.z;

            // �÷��̾� ��ġ�� ���� ī�޶� �̵���Ŵ
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // �÷��̾��� z �� ��ǥ�� ���� ��ǥ(stoppingZCoordinate)�� �����ϸ� ī�޶� ����ϴ�.
            if (playerZCoordinate >= stoppingZCoordinate)
            {
                finishText.text = "Finish!";
                shouldFollow = false; // ī�޶� �� �̻� �÷��̾ ������ �ʵ��� �÷��׸� ��Ȱ��ȭ�մϴ�.
            }
        }
    }
}