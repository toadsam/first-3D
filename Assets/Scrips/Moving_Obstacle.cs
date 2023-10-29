using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Obstacle : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Transform Moving_ObstaclePos;
    int count;
    public float oneSpeed;
    public float twoSpeed;
    public float time;
    bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        Moving_ObstaclePos.position = pos2.position;
        count = 0;
        isStart = false;
        StartCoroutine(StartMoving());
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isStart)
        Moving();
    }

    void Moving()
    {
        if (count == 0)
        {
            Moving_ObstaclePos.position = Vector3.MoveTowards(Moving_ObstaclePos.position, pos1.position, oneSpeed);
            if (Moving_ObstaclePos.position == pos1.position)
            {
                count++;
            }

        }
        if (count == 1)
        {
            Moving_ObstaclePos.position = Vector3.MoveTowards(Moving_ObstaclePos.position, pos2.position, twoSpeed);
            if (Moving_ObstaclePos.position == pos2.position)
            {
                count--;
            }

        }
    }

    IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(time);
        isStart = true;
    }
}
