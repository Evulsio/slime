using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class RandomizedRaceGameManager : MonoBehaviour
{
    public GameObject Player;
    public float Speed = 0f;
    private bool isSpaceKeyPressed = false;
    public InputActionReference spaceAction; // �����̽� �� �׼ǿ� ���� ����
    public GameObject fireParticle; // �Ҳ� ��ƼŬ GameObject�� Inspector���� ����

    private void OnEnable()
    {
        // Input System �׼��� Ȱ��ȭ
        spaceAction.action.Enable();
    }

    private void OnDisable()
    {
        // Input System �׼��� ��Ȱ��ȭ
        spaceAction.action.Disable();
    }

    private void Update()
    {
        // �����̽� �� �׼��� ����� ��
        if (spaceAction.action.triggered)
        {
            isSpaceKeyPressed = true;
        }
        else
        {
            isSpaceKeyPressed = false;
        }

        if (isSpaceKeyPressed)
        {
            // ������ ���ӵ��� �߰�
            float randomAcceleration = Random.Range(53f, 70f);
            Speed += randomAcceleration;

            Player.GetComponent<Rigidbody>().AddForce(0, 0, Speed * Time.deltaTime * 50);

            // ���� �ӵ� �̻��̸� �Ҳ� ��ƼŬ Ȱ��ȭ
            if (Speed >= 5000f) // �� �κп� ���ϴ� �ӵ��� ����
            {
                fireParticle.SetActive(true); // �Ҳ� ��ƼŬ GameObject Ȱ��ȭ

                // Stop the player's rotation
                Player.GetComponent<Rigidbody>().freezeRotation = true;
                Player.transform.rotation = Quaternion.identity;
            }
            else
            {
                // Resume the player's rotation
                Player.GetComponent<Rigidbody>().freezeRotation = false;
            }
        }
        else
        {
            // �����̽� �ٸ� ������ ���� �� �ӷ��� �پ��
            Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, Speed * Time.deltaTime);
        }

        // �ӵ��� ���� ���Ϸ� �������� �Ҳ� ��ƼŬ ��Ȱ��ȭ
        if (Speed <= 0.0f)
        {
            Speed = 0;
            fireParticle.SetActive(false); // �Ҳ� ��ƼŬ GameObject ��Ȱ��ȭ
        }

        // �ڷ� �Ȱ��� �ϱ����� ó��
        Speed -= (0.5f * Time.deltaTime) * 50;
        if (Speed <= 0.0f)
        {
            Speed = 0;
        }
    }
}