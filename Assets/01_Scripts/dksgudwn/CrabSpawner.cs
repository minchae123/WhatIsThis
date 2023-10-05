using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSpawner : MonoBehaviour
{
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
            GameObject obj = Instantiate(CrabManager.Instance.crabPrefab, randPos, Quaternion.identity);
            obj.GetComponent<Crab>().crabData = CrabManager.Instance.CrabData[0];
            obj.GetComponent<SpriteRenderer>().sprite = CrabManager.Instance.CrabData[0].Image;
            //obj.GetComponent<Crab>().crabData.Number = CrabManager.Instance.CrabData[0].Number;

            int spawnTime = Random.Range(1, 3);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
