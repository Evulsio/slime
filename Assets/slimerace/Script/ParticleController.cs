using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject targetObject; // 따라갈 대상 오브젝트
    private ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        // 대상 오브젝트의 위치에 파티클 시스템을 이동
        transform.position = targetObject.transform.position;
    }
}