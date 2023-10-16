using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSpawner : MonoBehaviour
{
    public float spawnTimeMin;
    public float spawnTimeMax;
    void Start()
    {
        StartCoroutine(RandSpawn());
    }

    IEnumerator RandSpawn()
    {
        while (true)
        {
            int randX = Random.Range(-2, 2);
            int randY = Random.Range(-4, 4);
            Vector2 randPos = new Vector2(randX, randY);
            Crab obj = Instantiate(CrabManager.Instance.crabPrefab, randPos, Quaternion.identity);
            obj.crabData = CrabManager.Instance.CrabData[0];
            obj.gameObject.GetComponent<SpriteRenderer>().sprite = CrabManager.Instance.CrabData[0].Image;
            //obj.GetComponent<Crab>().crabData.Number = CrabManager.Instance.CrabData[0].Number;

            float spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
