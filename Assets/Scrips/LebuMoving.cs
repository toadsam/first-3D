using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LebuMoving : MonoBehaviour
{
    private bool isMove;
    private Vector3 MovePos;
    
    private void OnEnable()
    {
        StartSetting();
    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, MovePos, 0.25f);//0.15f_pos1Time
        }
        if (transform.position == MovePos)
        {
            isMove = false;
        }
    }

    private void StartSetting()
    {
        MovePos = transform.position + new Vector3(0, 0, -10);
        isMove = true;
    }

    
}
