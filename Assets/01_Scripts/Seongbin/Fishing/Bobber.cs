using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3.0f;
    public float MoveSpeed { get; set; }

    [SerializeField] private float _repeatSec;

    public WayPoint wayPoint { get; set; }

    public Vector3 CurrentPointPosition => wayPoint.GetWayPointPosition(_currentWayPointIndex);

    private int _currentWayPointIndex;
    private Vector3 _lastPointPosition;

    private bool RepeatOnce = false;

    private int _cnt = 0;
    private int _randomCnt;

    private void Start()
    {
        _currentWayPointIndex = 0;

        MoveSpeed = _moveSpeed;

        _lastPointPosition = transform.position;
    }

    private void Update()
    {
        Move();

        if (CurrentPointPositionReached())
        {
            UpdateCurrentPointIndex();
        }
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition, MoveSpeed * Time.deltaTime);
    }

    private bool CurrentPointPositionReached()
    {
        float distanceToNextPointPosition = (transform.position - CurrentPointPosition).magnitude;
        if (distanceToNextPointPosition < 0.1f)
        {
            return true;
        }
        return false;
    }

    private void UpdateCurrentPointIndex()
    {
        int LastWaypointIndex = wayPoint.Points.Length - 1;
        if (_currentWayPointIndex < LastWaypointIndex)
        {
            _currentWayPointIndex = Random.Range(1, LastWaypointIndex);
            _cnt++;
        }

        if (_cnt >= _randomCnt)
            _currentWayPointIndex = LastWaypointIndex;

        if (_currentWayPointIndex == LastWaypointIndex && !RepeatOnce)
            StartCoroutine(RepeatPos());
    }

    public void ResetPos()
    {
        _randomCnt = Random.Range(5,7);
        _currentWayPointIndex = 0;
    
    }

    private IEnumerator RepeatPos()
    {
        _cnt = 0;
        RepeatOnce = true;
        yield return new WaitForSeconds(_repeatSec);
        RepeatOnce = false;
        ResetPos();
    }

    public void Catch()
	{
        ResetPos();

	}
}
