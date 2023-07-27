using UnityEngine;
using UnityEngine.UI;

public class TextDisplayOnTrigger : MonoBehaviour
{
    public GameObject triggerObject; // Ʈ���� �ö��̴��� �ִ� GameObject
    public Text displayText; // Text UI ��ü

    public Rigidbody rb; // Rigidbody ������Ʈ

    private bool isTriggered = false;
    public string newMessage = "New message to display"; // ĳ���Ͱ� Ʈ���Ÿ� ������ �� ǥ�õ� ���ο� �޽���

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == triggerObject)
        {
            isTriggered = true;
            displayText.text = newMessage; // �ؽ�Ʈ ������Ʈ
            rb.velocity = Vector3.zero; // Rigidbody �ӵ��� 0���� �����Ͽ� ����
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == triggerObject)
        {
            isTriggered = false;
            displayText.text = "Finish!"; // ĳ���Ͱ� Ʈ���Ÿ� ������ �� �ʱ� �޽����� ����
        }
    }
}