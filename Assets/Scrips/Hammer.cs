using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [Header("Rotation Object")]
    public GameObject Center;
    public GameObject Rotation_right;
    public GameObject Rotation_left;

    [Header("Rotation")]
    public int rotateSpeed;
    public float speedUpTime;
    public int rotateSpeedUp;
    private float curTime;
    //public float curTime;
    // Start is called before the first frame update
    void Start()
    {
        curTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        SpeedUp();
    }

    private void Rotate()
    {
        //Center.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        //transform.localRotation = Quaternion.Euler(0, 40f, 0);
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);

    }

    private void SpeedUp()
    {
        curTime += Time.deltaTime;
        //Debug.Log(curTime);
        if (curTime > speedUpTime)
        {
            rotateSpeed += rotateSpeedUp;
            curTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("데미지를 입었다");
        }
    }
}
