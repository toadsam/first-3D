using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lebu : MonoBehaviour
{
    Rigidbody rb;
    public Transform LebuAddforce;
    float curzPos;
    public Transform WallPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
       // rb.AddForce(LebuAddforce.forward * 20f, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
            curzPos = LebuAddforce.position.z;          
           // Debug.Log(curzPos);       
    }

    private void FixedUpdate()
    {
        rb.AddForce(LebuAddforce.forward * -2f, ForceMode.Force);
        WallPos.position = new Vector3(WallPos.position.x,  12 + curzPos, WallPos.position.z);
    }
}
//��ü�� �߰��ؼ� ������ z���� +�� ���� ���� ��ġ�� ������
//�ѹ� ���� ���� �����غ���