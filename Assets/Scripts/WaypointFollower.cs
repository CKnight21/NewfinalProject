using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f;

    // In each update call we check to see how close we are to each waypoint.
    // If the platform that is moving touches the waypoint, it will then head back to the other waypoint.
    void Update()
    {
        if(Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            // if this is true we want the floor to move to the next waypoint.
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                // If this is true then it starts to head back to the original position.
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
