using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIdx = 0;

    [SerializeField] private float speed = 10f;

    private SpriteRenderer sprite;
    [SerializeField] private bool leftright = false;


    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointIdx].transform.position, transform.position) < .1f)
        {
            currentWaypointIdx++;
            if(currentWaypointIdx >= waypoints.Length)
            {
                currentWaypointIdx = 0;
            }

            if(leftright)
                sprite.flipX = !sprite.flipX;
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIdx].transform.position, Time.deltaTime * speed);
    }
}
