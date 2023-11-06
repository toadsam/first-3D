using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_Obstacle : MonoBehaviour
{

    [Header("Rotation Object")]
    public GameObject Center;

    [Header("Rotation")]
    public int rotateSpeed;
    public float speedUpTime;
    public int rotateSpeedUp;
    private float curTime;

    public Player player;

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
        Center.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        
    }

    private void SpeedUp()
    {
        curTime += Time.deltaTime;
        // Debug.Log(curTime);
        if (curTime > speedUpTime)
        {
            rotateSpeed += rotateSpeedUp;
            curTime = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<Rigidbody>().AddForce(transform.forward * 0.5f + new Vector3(0,20f,0), ForceMode.Impulse);

            Debug.Log("���� ��ֹ��� ��ҽ��ϴ�");
        }
    }
}
