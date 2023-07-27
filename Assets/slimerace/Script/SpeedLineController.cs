using UnityEngine;

public class SpeedLineController : MonoBehaviour
{
    public Transform playerObject;
    public Material speedLineMaterial;
    public Color activeColor; // Ȱ��ȭ�� ���ǵ� ���� ���� ��
    public Color inactiveColor; // ��Ȱ��ȭ�� ���ǵ� ���� ���� ��
    public float speedThreshold = 5f; // ���� �ӵ� �̻��� �� Ȱ��ȭ�� �ӵ� ��

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

        // �÷��̾� �ӵ��� ���� ���ǵ� ���� ���׸����� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ�մϴ�.
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