using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; //기본 카메라의 값이 들어있다. 플레이어와 일정한 거리를 유지하기 위해서이다.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  transform.position = target.position + offset;
       // transform.LookAt(target.transform);
    }
}
