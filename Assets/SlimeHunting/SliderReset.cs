using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SliderReset : MonoBehaviour
{
    public Slider progressBar;
    public float incrementAmount = 1f;
    public InputActionReference increaseAction; // ���� �׼ǿ� ���� ����
    public InputActionReference resetAction;    // �ʱ�ȭ �׼ǿ� ���� ����
    public GameObject particlePrefab;           // ��ƼŬ �ý����� ����ִ� �������� Inspector���� �������ּ���.

    private void OnEnable()
    {
        // Input System �׼ǵ��� Ȱ��ȭ�մϴ�.
        increaseAction.action.Enable();
        resetAction.action.Enable();
    }

    private void OnDisable()
    {
        // Input System �׼ǵ��� ��Ȱ��ȭ�մϴ�.
        increaseAction.action.Disable();
        resetAction.action.Disable();
    }

    private void Update()
    {
        // ���� �׼��� ����� ��
        if (increaseAction.action.triggered)
        {
            // incrementAmount��ŭ ���α׷��� �� ���� ������ŵ�ϴ�.
            progressBar.value += incrementAmount;

            // �ּҰ��� �ִ밪 ���� ������ ���� �����մϴ�.
            progressBar.value = Mathf.Clamp(progressBar.value, progressBar.minValue, progressBar.maxValue);
        }

        // �ʱ�ȭ �׼��� ����� ��
        if (resetAction.action.triggered)
        {
            // ������ ���� ���� 100 �̻��� ���� �ʱ�ȭ�մϴ�.
            if (progressBar.value >= 100f)
            {
                // ���α׷��� �� ���� �ʱ�ȭ�մϴ�.
                progressBar.value = progressBar.minValue;

                // ��ƼŬ �ý����� �ߵ���ų ��ġ�� ����� ��ġ�� �����մϴ�.
                Vector3 targetPosition = transform.position;

                // ��ƼŬ �ý��� �������� ��� ��ġ�� �ν��Ͻ�ȭ�մϴ�.
                GameObject particleInstance = Instantiate(particlePrefab, targetPosition, Quaternion.identity);

                
            }
        }
    }
}