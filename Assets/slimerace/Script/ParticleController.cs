using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject targetObject; // ���� ��� ������Ʈ
    private ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        // ��� ������Ʈ�� ��ġ�� ��ƼŬ �ý����� �̵�
        transform.position = targetObject.transform.position;
    }
}