using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;

public class Auto : MonoBehaviour
{
    [SerializeField] private float mergeTime;
    [SerializeField] private float burningMergeTime; //0.1�� �̻����� �����ϱ�

    private float timer = 0f;
    private float burningTime = 30f; // ���� �ð�
    private int burningCount = 0; // ���� Ƚ��
    private Coroutine burningCoroutine;

    void Update()
    {
        if (burningCount > 0)
        {
            timer += Time.deltaTime;

            if (timer >= burningTime)
            {
                burningCount--;
                timer = 0f;
            }
        }
    }

    public void AutoMerge()
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
            CrabSpawnManager.Instance.crabs[minI].transform.DOMove(randPos, mergeTime);
        }

        if (minIndices.Count > 0)
        {
            StartCoroutine(OnCheck(minIndices[0])); // ù ��° �ּҰ��� ������ �ε����� ���ظ� �ڷ�ƾ ����
        }
    }

    IEnumerator OnCheck(int index)
    {
        yield return new WaitForSeconds(mergeTime);
        CrabSpawnManager.Instance.crabs[index].GetComponent<Crab>().ColliderCheck = true;
        yield return new WaitForSeconds(0.05f);
        CrabSpawnManager.Instance.crabs[index].GetComponent<Crab>().ColliderCheck = false;
    }

    public void BurningMode()
    {
        burningCount++;

        if (burningCoroutine != null)
        {
            StopCoroutine(burningCoroutine);
        }

        burningCoroutine = StartCoroutine(BurningCoroutine());
    }

    IEnumerator BurningCoroutine()
    {
        mergeTime = burningMergeTime;
        CrabSpawnManager.Instance.spawnTime = mergeTime;

        while (burningCount > 0)
        {
            AutoMerge();
            yield return new WaitForSeconds(mergeTime);
        }

        mergeTime = 1f;
        CrabSpawnManager.Instance.spawnTime = mergeTime;
    }
}
