using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; //�⺻ ī�޶��� ���� ����ִ�. �÷��̾�� ������ �Ÿ��� �����ϱ� ���ؼ��̴�.
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
