using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PoolingListSO poolingListSO;

    public SpawnListSO _spawnList;

    

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple GameManager is running! Check!");
        }
        Instance = this;
    }

    private void OnEnable()
    {
        MakePool();
        CrabSpawnManager.Instance.StartSpawn();
    }

    private void MakePool()
    {
        PoolManager.Instance = new PoolManager(transform);

        poolingListSO.list.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount)); //리스트에 있는 모든
    }
}
