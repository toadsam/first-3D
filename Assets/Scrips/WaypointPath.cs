using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
  public Transform GetWaypoint(int waypointIndex) //경로를 정하는 것음
    {
        return transform.GetChild(waypointIndex); // 
    }

    public int GetNextWaypointIndex(int currentWaypointIndex) //다음경로를 불러오는 메서드
    {
        int nextWaypointIndex = currentWaypointIndex + 1;

        if (nextWaypointIndex == transform.childCount)
        {
            nextWaypointIndex = 0;
        }

        return nextWaypointIndex;

    }
}
