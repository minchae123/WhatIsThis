using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PoolingListSO poolingListSO;

    [SerializeField]
    private SpawnListSO _spawnList;

    [Header("CrapSpawn")]
    public float spawnTimeMin;
    public float spawnTimeMax;

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
        StartCoroutine(StartSpawn());
    }

    private void MakePool()
    {
        PoolManager.Instance = new PoolManager(transform);

        poolingListSO.list.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount)); //리스트에 있는 모든
    }

    IEnumerator StartSpawn()
    {
        while (true)
        {
            int randX = Random.Range(-2, 2);
            int randY = Random.Range(-4, 4);
            Vector2 randPos = new Vector2(randX, randY);
            Crab obj = PoolManager.Instance.Pop(_spawnList.SpawnPairs[0].prefab.name) as Crab;
            //obj.crabData = CrabManager.Instance.CrabData[0];
            //obj.gameObject.GetComponent<SpriteRenderer>().sprite = CrabManager.Instance.CrabData[0].Image;
            //obj.GetComponent<Crab>().crabData.Number = CrabManager.Instance.CrabData[0].Number;
            obj.transform.position = randPos;

            float spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
