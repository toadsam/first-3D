using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{

    public float force = 500.0f;

    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");

        Rigidbody rb;
        //rb = GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * force, ForceMode.Force);
       // rb.useGravity = true;
    }
} //일정 포인트 지점을 정하고 y축이 내려갈때 마다 문이 열리는 구조로 가기 
