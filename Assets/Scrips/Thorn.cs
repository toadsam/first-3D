using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Transform ThornPos;
    int count;
    public float pos1Time;
    public float pos2Time;
    // Start is called before the first frame update
    void Start()
    {
        ThornPos.position = pos2.position;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
       // ThornPos.position = Vector3.MoveTowards(ThornPos.position, pos2.position, 0.1f);
       // Debug.Log(ThornPos.position);

        if (count == 0)
        {
            ThornPos.position = Vector3.MoveTowards(ThornPos.position, pos1.position, pos1Time);//0.15f
            if (ThornPos.position == pos1.position) 
            {
                count++;
            }
            
        }
        if (count == 1)
        {
            ThornPos.position = Vector3.MoveTowards(ThornPos.position, pos2.position, pos2Time);// 0.01f
            if (ThornPos.position == pos2.position)
            {
                count--;
            }
            
        }
    }
}
