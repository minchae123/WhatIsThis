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
            // Ȱ��ȭ�Ǿ� ������ ����Ʈ�� �߰�
            if (CrabSpawnManager.Instance.crabs[i].gameObject.activeSelf)
            {
                enableCrab.Add(CrabSpawnManager.Instance.crabs[i].gameObject);
            }
        }
    }
}
