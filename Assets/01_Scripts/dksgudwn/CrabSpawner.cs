using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSpawner : MonoBehaviour
{
    public GameObject CrabPrefab;
    [SerializeField] CrabSO[] _crabList;

    private void Awake()
    {
        CrabPrefab.GetComponent<Crab>().crabData = _crabList[0];
    }
}
