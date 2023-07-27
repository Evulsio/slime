using UnityEngine;
using UnityEngine.UI;

public class TextDisplayOnTrigger : MonoBehaviour
{
    public GameObject triggerObject; // 트리거 컬라이더가 있는 GameObject
    public Text displayText; // Text UI 객체

    public Rigidbody rb; // Rigidbody 컴포넌트

    private bool isTriggered = false;
    public string newMessage = "New message to display"; // 캐릭터가 트리거를 지나갈 때 표시될 새로운 메시지

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == triggerObject)
        {
            isTriggered = true;
            displayText.text = newMessage; // 텍스트 업데이트
            rb.velocity = Vector3.zero; // Rigidbody 속도를 0으로 설정하여 멈춤
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == triggerObject)
        {
            isTriggered = false;
            displayText.text = "Finish!"; // 캐릭터가 트리거를 지나갈 때 초기 메시지로 변경
        }
    }
}