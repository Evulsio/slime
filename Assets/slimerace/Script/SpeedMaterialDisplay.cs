using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMaterialDisplay : MonoBehaviour
{
    public Material speedMaterial; // 플레이어의 속도가 임계값 이상일 때 표시할 메테리얼
    public float speedThreshold = 5000f; // 메테리얼을 활성화할 속도 임계값

    private Renderer rendererComponent;
    private Material defaultMaterial;
    private bool isMaterialActive = false;

    private void Awake()
    {
        rendererComponent = GetComponent<Renderer>();
        if (rendererComponent != null)
        {
            defaultMaterial = rendererComponent.material;
        }
    }

    private void Update()
    {
        if (RaceGameManager.Speed >= speedThreshold && !isMaterialActive)
        {
            ActivateSpeedMaterial();
        }
        else if (RaceGameManager.Speed < speedThreshold && isMaterialActive)
        {
            DeactivateSpeedMaterial();
        }
    }

    private void ActivateSpeedMaterial()
    {
        if (rendererComponent != null && speedMaterial != null)
        {
            rendererComponent.material = speedMaterial;
            isMaterialActive = true;
        }
    }

    private void DeactivateSpeedMaterial()
    {
        if (rendererComponent != null)
        {
            rendererComponent.material = defaultMaterial;
            isMaterialActive = false;
        }
    }
}