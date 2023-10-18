using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;

public class StoreUI : MonoBehaviour
{
    private GameObject _content;
    public GameObject Item;
    private void Start()
    {
        _content = GameObject.Find("Content");
        print(_content);
        Instantiate(Item).transform.position = _content.transform.position;
        print(Item.transform.position);
    }
}
