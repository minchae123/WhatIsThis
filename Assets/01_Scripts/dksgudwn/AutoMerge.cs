using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMerge : MonoBehaviour
{
    public List<GameObject> enableCrab;

    public void Auto()
    {
        enableCrab.Clear();
        foreach (Transform child in transform)
        {
            // �ڽ� ������Ʈ�� Ȱ��ȭ�Ǿ� ������ ����Ʈ�� �߰�
            if (child.gameObject.activeSelf)
            {
                enableCrab.Add(child.gameObject);
            }
        }

    }
}
