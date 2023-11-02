using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSpawnManager : MonoBehaviour
{
    public static CrabSpawnManager Instance;

    public float spawnTimeMin;
    public float spawnTimeMax;

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
            int randX = Random.Range(-2, 2);
            int randY = Random.Range(-4, 4);
            Vector2 randPos = new Vector2(randX, randY);
            Crab obj = PoolManager.Instance.Pop(GameManager.Instance._spawnList.SpawnPairs[0].prefab.name) as Crab;
            crabs.Add(obj);

            //obj.crabData = CrabManager.Instance.CrabData[0];
            //obj.gameObject.GetComponent<SpriteRenderer>().sprite = CrabManager.Instance.CrabData[0].Image;
            //obj.GetComponent<Crab>().crabData.Number = CrabManager.Instance.CrabData[0].Number;
            obj.transform.position = randPos;

            float spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            yield return new WaitForSeconds(spawnTime);

            //리스트에 넣어주기
        }
    }

}
