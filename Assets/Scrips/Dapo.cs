using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dapo : MonoBehaviour
{
    public float deg; //각도
    public float turnSpeed;//대포 스피드
    public GameObject turret;
    public Player player;
    Rigidbody rb;
    public Transform DapoPos;
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
        if (Input.GetKey(KeyCode.E))
        {
            deg = deg + Time.deltaTime * turnSpeed;
            float rad = deg * Mathf.Deg2Rad  ;
           // turret.transform.rotation = Quaternion.Euler(rad, 0, 0);
           // turret.transform.localPosition = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));
            turret.transform.eulerAngles = new Vector3(deg, 0, 0);
          //  DapoPos.localPosition = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));
           // DapoPos.eulerAngles = new Vector3(deg, 0, 0);
            if (deg > 60)
            {
                deg = 60;
            }
            else if(deg < -60)
            {
                deg = -60;
            }
        }
        else if (Input.GetKey(KeyCode.R))
        {
            deg = deg - Time.deltaTime * turnSpeed;
            float rad = deg * Mathf.Deg2Rad ;
          //  turret.transform.rotation = Quaternion.Euler(rad, 0, 0);
          //  turret.transform.localPosition = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));
            turret.transform.eulerAngles = new Vector3(deg, 0, 0);
          //  DapoPos.localPosition = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));
           // DapoPos.eulerAngles = new Vector3(deg, 0, 0);
            if (deg > 180)
            {
                deg = 180;
            }
            else if (deg < -180)
            {
                deg = -180;
            }
        }
        if(Input.GetKeyDown(KeyCode.T) && isInside) 
        {
            isRide = !isRide;
        }
        if (isRide)
        {
            player.GetComponent<Transform>().position = DapoPos.position;
            //rb.velocity = transform.position * 5;
            //Debug.Log("나 대포 쏠준비가 되었어");
            //isRide = !isRide;
            if (isFly)
            {
                isRide = !isRide;
                rb.AddForce(DapoPos.forward *50 , ForceMode.Impulse);
                Debug.Log("나 대포 쏠준비가 되었어");
            }
        }
        if(Input.GetKeyDown (KeyCode.Y)) 
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
        }
    }

}
