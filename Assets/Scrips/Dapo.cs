using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dapo : MonoBehaviour
{
    public float deg; //����
    public float turnSpeed;//���� ���ǵ�
    public GameObject turret;
    public Player player;
    Rigidbody rb;
    public Transform DapoPos;
    public Transform DapoRot;
    bool isRide;
    bool isInside;
    bool isFly;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpCannon();
        DownCannom();
        Ride();
        CheckIsFly();     
    }

    private void FixedUpdate()
    {
        Fly();    
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isInside = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInside = false;
            isFly = false;
        }
    }

    void UpCannon()
    {
        if (Input.GetKey(KeyCode.E))  //eŰ�� ������ 
        {
            deg = deg + Time.deltaTime * turnSpeed;  //������ �����Ѵ�.
            float rad = deg * Mathf.Deg2Rad;  // �� ������ ������ �����ֱ�         
            turret.transform.eulerAngles = new Vector3(deg, 0, 0);  // ���� ���߱�
            if (deg > 0)
            {
                deg = 0;
            }
            else if (deg < -60)
            {
                deg = -60;
            }
        }
    }

    void DownCannom()
    {
        if (Input.GetKey(KeyCode.R))  //rŰ�� ������ ������ �����ϱ�
        {
            deg = deg - Time.deltaTime * turnSpeed;
            float rad = deg * Mathf.Deg2Rad;
            turret.transform.eulerAngles = new Vector3(deg, 0, 0);
            if (deg > 0)
            {
                deg = 0;
            }
            else if (deg < -60)
            {
                deg = -60;
            }
        }
    }

    void CheckIsFly()
    {
        if (Input.GetKeyDown(KeyCode.Y))  //yŰ�� ���� �� �� �ִ��� �������� �����Ѵ�.
        {
            isFly = true;
        }
    }

    void Fly()
    {
        if (isFly)
        {

            rb.AddForce(DapoPos.transform.up * 20, ForceMode.Impulse);   // new Vector3(0, 90, 0)
            Debug.Log("�� ���� ���غ� �Ǿ���");
        }
    }

    void Ride()
    {
        if (Input.GetKeyDown(KeyCode.T) && isInside)   //���� �ȿ� �� �ְ� tŰ�� ������ Ż �� �ִٴ� ���̴�
        {
            isRide = !isRide;
        }
        if (isRide) //Ż �� �ִٸ� Ÿ��
        {
            player.GetComponent<Transform>().position = DapoPos.position; //��ġ�� �����ǰ� ��ġ��Ų��.
            player.GetComponent<Transform>().localRotation = DapoPos.transform.rotation;// Quaternion.Euler(deg, 0, 0);
            if (isFly)
            {
                isRide = !isRide;  //Ż �� �ְ� ���� ����

            }
        }

    }



}
