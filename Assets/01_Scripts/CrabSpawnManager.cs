using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSpawnManager : MonoBehaviour
{
    public static CrabSpawnManager Instance;

    public float spawnTime;

    public int crabMaxCount;

    public List<Crab> crabs = new List<Crab>();

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple CrabSpawnManager is running! Check!");
        }
        Instance = this;
    }

    public void StartSpawn()
    {
        StartCoroutine(StartSpawnCoroutine());
    }

    IEnumerator StartSpawnCoroutine()
    {
        while (true)
        {
            if (crabs.Count <= crabMaxCount)
            {
                int randX = Random.Range(-2, 2);
                int randY = Random.Range(-4, 4);
                Vector2 randPos = new Vector2(randX, randY);
                Crab obj = PoolManager.Instance.Pop(GameManager.Instance._spawnList.SpawnPairs[0].prefab.name) as Crab;
                crabs.Add(obj);

                obj.transform.position = randPos;

                yield return new WaitForSeconds(spawnTime);
            }
            yield return new WaitForSeconds(0.1f);

            Debug.Log("df");
        }
    }
}
