using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lebu : MonoBehaviour
{
    Rigidbody rb;
    public Transform LebuAddforce;
    float zPos;
    float curzPos;
    public GameObject Wall;
    public Transform WallPos;
    public float WallPoss;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        zPos = LebuAddforce.position.z;
        rb.AddForce(LebuAddforce.forward * 20f, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("zPos" + zPos);
       // Debug.Log("curzPos" + curzPos);
        curzPos = LebuAddforce.position.z;
        //WallPoss = Wall.transform.position
        if (zPos > curzPos)
        {
            Debug.Log(curzPos);
            rb.AddForce(LebuAddforce.forward * 5f, ForceMode.Force);
            WallPoss = curzPos;
            WallPos.position = new Vector3(WallPos.position.x, 10 + 3 * LebuAddforce.position.y, WallPos.position.z);   
            //WallPoss = curzPos;
        }
    }
}
//객체를 추가해서 레버의 z값의 +에 따라 문이 닫치는 식으로
//한번 축을 조금 변경해보자