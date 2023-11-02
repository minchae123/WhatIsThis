using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMerge : MonoBehaviour
{
    public List<GameObject> enableCrab;

    public void Auto()
    {
        enableCrab.Clear();
        for (int i = 0; i < CrabSpawnManager.Instance.crabs.Count; i++)
        {
            // 활성화되어 있으면 리스트에 추가
            if (CrabSpawnManager.Instance.crabs[i].gameObject.activeSelf)
            {
                enableCrab.Add(CrabSpawnManager.Instance.crabs[i].gameObject);
            }
        }
    }
}
