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
            // 자식 오브젝트가 활성화되어 있으면 리스트에 추가
            if (child.gameObject.activeSelf)
            {
                enableCrab.Add(child.gameObject);
            }
        }

    }
}
