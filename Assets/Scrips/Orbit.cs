using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform target;
    public float orbitSpeed;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position; //자신가 타겟의 거리를 구함
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset; //자신의 위치를 유지 -> 벡터는 크기와 방향을 가지고 있기 때문에 가능하다.
        transform.RotateAround(target.position,Vector3.up,orbitSpeed * Time.deltaTime);

        offset = transform.position - target.position; //백터의 크기와 방향 때문에 계속해서 지속적으로 업데이트 해주어야함.
    }
}
