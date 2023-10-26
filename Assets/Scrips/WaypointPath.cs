using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
  public Transform GetWaypoint(int waypointIndex) //��θ� ���ϴ� ����
    {
        return transform.GetChild(waypointIndex); // 
    }

    public int GetNextWaypointIndex(int currentWaypointIndex) //������θ� �ҷ����� �޼���
    {
        int nextWaypointIndex = currentWaypointIndex + 1;

        if (nextWaypointIndex == transform.childCount)
        {
            nextWaypointIndex = 0;
        }

        return nextWaypointIndex;

    }
}
