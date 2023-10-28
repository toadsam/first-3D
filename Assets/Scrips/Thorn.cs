using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Transform ThornPos;
    // Start is called before the first frame update
    void Start()
    {
        ThornPos.position = pos1.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ThornPos.position);
        if (ThornPos.position == pos1.position)
        {
            ThornPos.position = Vector3.MoveTowards(ThornPos.position, pos2.position, 1);
        }
        else if (ThornPos.position == pos2.position)
        {
            ThornPos.position = Vector3.MoveTowards(ThornPos.position, pos1.position, 1);
        }
    }
}
