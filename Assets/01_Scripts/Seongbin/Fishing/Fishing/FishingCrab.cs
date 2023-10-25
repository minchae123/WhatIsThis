using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class FishingCrab : MonoBehaviour
{
    [SerializeField] private float _minSpawnTime;
    [SerializeField] private float _maxSpawnTime;

    [SerializeField] private float _minBiteTime;
    [SerializeField] private float _maxBiteTime;

    public bool _isCasting = false;
    public bool _isBite = false;
    public bool _isCatch = false;


    private void Awake()
    {

    }

    private void Update()
    {
      
    }
}
