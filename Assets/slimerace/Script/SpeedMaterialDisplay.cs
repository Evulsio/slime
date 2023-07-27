using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMaterialDisplay : MonoBehaviour
{
    public Material speedMaterial; // �÷��̾��� �ӵ��� �Ӱ谪 �̻��� �� ǥ���� ���׸���
    public float speedThreshold = 5000f; // ���׸����� Ȱ��ȭ�� �ӵ� �Ӱ谪

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