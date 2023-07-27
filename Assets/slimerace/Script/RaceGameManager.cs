using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class RaceGameManager : MonoBehaviour
{
    public GameObject Player;
    static public float Speed = 0f;
    public InputActionReference spaceAction; // 스페이스 바 액션에 대한 참조
    public GameObject fireParticle; // 불꽃 파티클 GameObject를 Inspector에서 연결

    private void OnEnable()
    {
        // Input System 액션을 활성화
        spaceAction.action.Enable();
    }

    private void OnDisable()
    {
        // Input System 액션을 비활성화
        spaceAction.action.Disable();
    }

    private void Update()
    {
        // 스페이스 바 액션이 실행될 때
        if (spaceAction.action.triggered)
        {
            //연타하면 속력이 붙음
            Speed += 60f;
            Player.GetComponent<Rigidbody>().AddForce(0, 0, Speed * Time.deltaTime * 50);

            // 일정 속도 이상이면 불꽃 파티클 활성화
            if (Speed >= 5000f) // 이 부분에 원하는 속도를 설정
            {
                fireParticle.SetActive(true); // 불꽃 파티클 GameObject 활성화

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
            //연타멈추면 속력이 줄어들음
            Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, Speed * Time.deltaTime);
        }

        // 속도가 일정 이하로 떨어지면 불꽃 파티클 비활성화
        if (Speed <= 0.0f)
        {
            Speed = 0;
            fireParticle.SetActive(false); // 불꽃 파티클 GameObject 비활성화
        }

        //뒤로 안가게 하기위한 처리
        Speed -= (0.5f * Time.deltaTime) * 50;
        if (Speed <= 0.0f)
        {
            Speed = 0;
        }
    }
}