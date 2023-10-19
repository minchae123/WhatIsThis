using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    private GameObject _content;
    public GameObject Item;
    List<GameObject> Items = new List<GameObject>();
    [SerializeField]
    List<CrabSO> crabSOs = new List<CrabSO>();

    private void Awake()
    {
        _content = transform.Find("ShopItems/ScrollContent/Content").gameObject;
    }

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(Item);
            obj.transform.parent = _content.transform;

            Image image = obj.transform.Find("Background/ImageSprite").GetComponent<Image>();

            image.sprite = crabSOs[i].Image;

            Items.Add(obj);
        }
    }
}
