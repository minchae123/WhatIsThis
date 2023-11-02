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
        //    // 활성화되어 있으면 리스트에 추가
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
        string temp = Regex.Replace(str, @"\D", ""); //str에 문자열중 일반문자를 ""공백문자로 대체한다 
        return int.Parse(temp);
    }
}
