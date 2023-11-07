using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;

public class Auto : MonoBehaviour
{
    [SerializeField] private float mergeTime;
    [SerializeField] private float burningMergeTime; //0.1초 이상으로 설정하기

    private float timer = 0f;
    private float burningTime = 30f; // 버닝 시간
    private int burningCount = 0; // 버닝 횟수
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

        List<int> minIndices = new List<int>(); // 최소값을 가지는 인덱스 리스트 초기화

        int minNumber = int.MaxValue; // 초기 최소값 설정

        for (int i = 0; i < CrabSpawnManager.Instance.crabs.Count; i++)
        {
            for (int j = i + 1; j < CrabSpawnManager.Instance.crabs.Count; j++)
            {
                if (CrabSpawnManager.Instance.crabs[i].crabData.Number == CrabSpawnManager.Instance.crabs[j].crabData.Number)
                {
                    // 현재 i와 j의 Number 값을 비교하여 최소인 경우에만 조건을 충족
                    if (CrabSpawnManager.Instance.crabs[i].crabData.Number < minNumber)
                    {
                        minNumber = CrabSpawnManager.Instance.crabs[i].crabData.Number; // 최소값 업데이트
                        minIndices.Clear(); // 최소값을 가지는 인덱스 리스트 초기화
                        minIndices.Add(i); // 최소값일 때의 i 인덱스 추가
                        minIndices.Add(j); // 최소값일 때의 j 인덱스 추가
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
            StartCoroutine(OnCheck(minIndices[0])); // 첫 번째 최소값을 가지는 인덱스에 대해만 코루틴 실행
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
