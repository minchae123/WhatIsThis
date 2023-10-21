using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : MonoBehaviour
{
    [SerializeField] private GameObject _fishingLinestart;
    [SerializeField] private GameObject _bobber;
    
    private LineRenderer _lineRenderer;
        
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        _lineRenderer.SetPosition(0, _fishingLinestart.transform.position);
        _lineRenderer.SetPosition(1, _bobber.transform.position);
    }
}
