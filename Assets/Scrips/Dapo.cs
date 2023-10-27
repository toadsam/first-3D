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
        //rb.velocity = transform.position * 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))  //eŰ�� ������ 
        {
            deg = deg + Time.deltaTime * turnSpeed;  //������ �����Ѵ�.
            float rad = deg * Mathf.Deg2Rad  ;  // �� ������ ������ �����ֱ�
           // turret.transform.rotation = Quaternion.Euler(rad, 0, 0);
           // turret.transform.localPosition = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));
            turret.transform.eulerAngles = new Vector3(deg, 0, 0);  // ���� ���߱�
          //  DapoPos.localPosition = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));
           // DapoPos.eulerAngles = new Vector3(deg, 0, 0);
            if (deg > 0)
            {
                deg = 0;
            }
            else if(deg < -60)
            {
                deg = -60;
            }
        }
        else if (Input.GetKey(KeyCode.R))  //rŰ�� ������ ������ �����ϱ�
        {
            deg = deg - Time.deltaTime * turnSpeed;
            float rad = deg * Mathf.Deg2Rad ;
          //  turret.transform.rotation = Quaternion.Euler(rad, 0, 0);
          //  turret.transform.localPosition = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));
            turret.transform.eulerAngles = new Vector3(deg, 0, 0);
          //  DapoPos.localPosition = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));
           // DapoPos.eulerAngles = new Vector3(deg, 0, 0);
            if (deg > 0)
            {
                deg = 0;
            }
            else if (deg < -60)
            {
                deg = -60;
            }
        }
        if(Input.GetKeyDown(KeyCode.T) && isInside)   //���� �ȿ� �� �ְ� tŰ�� ������ Ż �� �ִٴ� ���̴�
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
                rb.AddForce(DapoPos.transform.up *30 + new Vector3(0,90,0) , ForceMode.Impulse );
                //rb.AddForce(DapoPos.forward *80 , ForceMode.Impulse);
                Debug.Log("�� ���� ���غ� �Ǿ���");
            }
        }
        if(Input.GetKeyDown (KeyCode.Y))  //yŰ�� ���� �� �� �ִ��� �������� �����Ѵ�.
        {
            isFly = true;
        }
        //Debug.Log(isFly);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("�ȳ�");
            isInside = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("������");
            isInside = false;
            isFly = false;
        }
    }

}
