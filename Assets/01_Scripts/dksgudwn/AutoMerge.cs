using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class AutoMerge : MonoBehaviour
{


    public void Auto()
    {
        float randX = Random.Range(-2f, 2f);
        float randY = Random.Range(-4f, 4f);
        Vector2 randPos = new Vector2(randX, randY);

        List<int> minIndices = new List<int>(); // �ּҰ��� ������ �ε��� ����Ʈ �ʱ�ȭ

        int minNumber = int.MaxValue; // �ʱ� �ּҰ� ����

        for (int i = 0; i < CrabSpawnManager.Instance.crabs.Count; i++)
        {
            for (int j = i + 1; j < CrabSpawnManager.Instance.crabs.Count; j++)
            {
                if (CrabSpawnManager.Instance.crabs[i].crabData.Number == CrabSpawnManager.Instance.crabs[j].crabData.Number)
                {
                    // ���� i�� j�� Number ���� ���Ͽ� �ּ��� ��쿡�� ������ ����
                    if (CrabSpawnManager.Instance.crabs[i].crabData.Number < minNumber)
                    {
                        minNumber = CrabSpawnManager.Instance.crabs[i].crabData.Number; // �ּҰ� ������Ʈ
                        minIndices.Clear(); // �ּҰ��� ������ �ε��� ����Ʈ �ʱ�ȭ
                        minIndices.Add(i); // �ּҰ��� ���� i �ε��� �߰�
                        minIndices.Add(j); // �ּҰ��� ���� j �ε��� �߰�
                    }
                }
            }
        }

        foreach (int minI in minIndices)
        {
            CrabSpawnManager.Instance.crabs[minI].transform.DOMove(randPos, 1);
        }

        if (minIndices.Count > 0)
        {
            StartCoroutine(OnCheck(minIndices[0])); // ù ��° �ּҰ��� ������ �ε����� ���ظ� �ڷ�ƾ ����
        }


    }

    IEnumerator OnCheck(int index)
    {
        yield return new WaitForSeconds(1f);
        CrabSpawnManager.Instance.crabs[index].GetComponent<Crab>().ColliderCheck = true;
        yield return new WaitForSeconds(0.05f);
        CrabSpawnManager.Instance.crabs[index].GetComponent<Crab>().ColliderCheck = false;
    }

    int FindNum(string str)
    {
        string temp = Regex.Replace(str, @"\D", ""); //str�� ���ڿ��� �Ϲݹ��ڸ� ""���鹮�ڷ� ��ü�Ѵ� 
        return int.Parse(temp);
    }
}
