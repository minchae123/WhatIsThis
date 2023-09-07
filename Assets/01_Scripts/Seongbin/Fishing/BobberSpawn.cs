using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobberSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _bobber;

    private WayPoint _wayPoint;
    
    private void Awake()
    {
        _wayPoint = (WayPoint)GetComponent("WayPoint");
    }

    private void Start()
    {
        MoveBobber();
    }

    private void MoveBobber()
    {
        Bobber bobber = _bobber.GetComponent<Bobber>();
        bobber.wayPoint = _wayPoint;

        bobber.transform.localPosition = transform.position;
        bobber.ResetPos();
    }
}