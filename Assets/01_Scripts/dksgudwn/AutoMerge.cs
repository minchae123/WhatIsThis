using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class AutoMerge : MonoBehaviour
{


    public void Auto()
    {
        //enableCrab.Clear();
        //for (int i = 0; i < CrabSpawnManager.Instance.crabs.Count; i++)
        //{
        //    // Ȱ��ȭ�Ǿ� ������ ����Ʈ�� �߰�
        //    if (CrabSpawnManager.Instance.crabs[i].gameObject.activeSelf)
        //    {
        //        enableCrab.Add(CrabSpawnManager.Instance.crabs[i].gameObject);
        //    }
        //}
        for (int i = 0; i < CrabSpawnManager.Instance.crabs.Count; i++)
        {
            FindNum(CrabSpawnManager.Instance.crabs[i].name);
        }
    }

    int FindNum(string str)
    {
        string temp = Regex.Replace(str, @"\D", ""); //str�� ���ڿ��� �Ϲݹ��ڸ� ""���鹮�ڷ� ��ü�Ѵ� 
        return int.Parse(temp);
    }
}
