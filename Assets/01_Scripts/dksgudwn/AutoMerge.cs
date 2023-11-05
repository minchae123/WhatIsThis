using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class AutoMerge : MonoBehaviour
{
    Sequence seq = DOTween.Sequence();


    public void Auto()
    {
        int randX = Random.Range(-2, 2);
        int randY = Random.Range(-4, 4);
        Vector2 randPos = new Vector2(randX, randY);

        for (int i = 0; i < CrabSpawnManager.Instance.crabs.Count; i++)
        {
            for (int j = i + 1; j < CrabSpawnManager.Instance.crabs.Count; j++)
            {
                if (CrabSpawnManager.Instance.crabs[i].crabData.Number == CrabSpawnManager.Instance.crabs[j].crabData.Number)
                {
                    seq.Append(CrabSpawnManager.Instance.crabs[i].transform.DOMove(randPos, 1));
                    seq.Join(CrabSpawnManager.Instance.crabs[j].transform.DOMove(randPos, 1));

                    StartCoroutine(OnCheck(i));
                    //CrabSpawnManager.Instance.crabs[i].GetComponent<Crab>().ColliderCheck = true;
                    //CrabSpawnManager.Instance.crabs[j].GetComponent<Crab>().ColliderCheck = true;
                }
            }
        }
    }

    IEnumerator OnCheck(int index)
    {
        ///////////seq.Append(CrabSpawnManager.Instance.crabs[index].GetComponent<Crab>().ColliderCheck = true);
        yield return new WaitForSeconds(0.05f);
        CrabSpawnManager.Instance.crabs[index].GetComponent<Crab>().ColliderCheck = false;
    }

    int FindNum(string str)
    {
        string temp = Regex.Replace(str, @"\D", ""); //str에 문자열중 일반문자를 ""공백문자로 대체한다 
        return int.Parse(temp);
    }
}
