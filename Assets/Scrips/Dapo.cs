using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dapo : MonoBehaviour
{
    public float deg; //각도
    public float turnSpeed;//대포 스피드
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
        if (Input.GetKey(KeyCode.E))  //e키를 누르면 
        {
            deg = deg + Time.deltaTime * turnSpeed;  //각도를 조정한다.
            float rad = deg * Mathf.Deg2Rad  ;  // 그 각도의 정도를 맞춰주기
           // turret.transform.rotation = Quaternion.Euler(rad, 0, 0);
           // turret.transform.localPosition = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));
            turret.transform.eulerAngles = new Vector3(deg, 0, 0);  // 각도 맞추기
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
        else if (Input.GetKey(KeyCode.R))  //r키를 누리면 각도를 조절하기
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
        if(Input.GetKeyDown(KeyCode.T) && isInside)   //만약 안에 들어가 있고 t키가 눌리면 탈 수 있다는 것이다
        {
            isRide = !isRide;
        }
        if (isRide) //탈 수 있다면 타고
        {
            player.GetComponent<Transform>().position = DapoPos.position; //위치를 포지션과 일치시킨다.
            player.GetComponent<Transform>().localRotation = DapoPos.transform.rotation;// Quaternion.Euler(deg, 0, 0);
            if (isFly) 
            {
                isRide = !isRide;  //탈 수 있고 없고를 가림
                rb.AddForce(DapoPos.transform.up *30 + new Vector3(0,90,0) , ForceMode.Impulse );
                //rb.AddForce(DapoPos.forward *80 , ForceMode.Impulse);
                Debug.Log("나 대포 쏠준비가 되었어");
            }
        }
        if(Input.GetKeyDown (KeyCode.Y))  //y키를 통해 날 수 있는지 없는지를 조절한다.
        {
            isFly = true;
        }
        //Debug.Log(isFly);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("안녕");
            isInside = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("나갈게");
            isInside = false;
            isFly = false;
        }
    }

}
