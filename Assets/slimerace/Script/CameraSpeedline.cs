using UnityEngine;

public class CameraSpeedline : MonoBehaviour
{
    public Material speedlineMaterial; // ���ǵ�������� ����� ���׸���
    public RaceGameManager raceGameManager; // RaceGameManager ��ũ��Ʈ�� ���� ����

    private Camera mainCamera; // ���� ī�޶� ������ ����

    private void Start()
    {
        // ���� ī�޶� ������Ʈ�� �����ɴϴ�.
        mainCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        // RaceGameManager���� �÷��̾��� �ӵ��� �����ɴϴ�.
        float Speed = RaceGameManager.Speed;

        // �÷��̾��� �ӵ��� ���ϴ� �ӵ�(5000f) �̻����� Ȯ���Ͽ� ���ǵ���� ȿ���� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ�մϴ�.
        if (Speed >= 5000f) // ���ϴ� �ӵ��� �°� �����ϼ���.
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
        // ���� ī�޶� ���ǵ���� ���׸����� �����մϴ�.
        mainCamera.SetReplacementShader(speedlineMaterial.shader, null);
    }

    private void DisableSpeedlineEffect()
    {
        // ���� ī�޶��� ������ ���̴��� �⺻ ���̴��� �����Ͽ� ���ǵ���� ȿ���� ��Ȱ��ȭ�մϴ�.
        mainCamera.ResetReplacementShader();
    }
}