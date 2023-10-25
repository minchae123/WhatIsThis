using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    [SerializeField] private GameObject _item;
    //[SerializeField] private GameObject _itemBar;
    [SerializeField] private GameObject ScrollContent1;
    [SerializeField] private GameObject ScrollContent2;
    [SerializeField] private GameObject ScrollContent3;
    [SerializeField] private GameObject ScrollContent4;

    [SerializeField] List<CrabSO> crabSOs = new List<CrabSO>();

    List<GameObject> Items = new List<GameObject>();

    private void Awake()
    {
        ItemVarButton1();
        //_content = transform.Find("ShopItems/ScrollContent/Content").gameObject;
    }

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(_item);
            obj.transform.parent = _content.transform;

            Image image = obj.transform.Find("Background/ImageSprite").GetComponent<Image>();

            image.sprite = crabSOs[i].Image;

            Items.Add(obj);
        }
    }

    private void InitScrollContent1()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(_item);
            obj.transform.parent = _content.transform;

            Image image = obj.transform.Find("Background/ImageSprite").GetComponent<Image>();

            image.sprite = crabSOs[i].Image;

            Items.Add(obj);
        }
    }

    private void InitScollContent2()
    {

    }

    private void InitScollContent3()
    {

    }

    private void InitScollContent4()
    {

    }

    public void ItemVarButton1()
    {
        ScrollContent1.SetActive(true);
        ScrollContent2.SetActive(false);
        ScrollContent3.SetActive(false);
        ScrollContent4.SetActive(false);
    }

    public void ItemVarButton2()
    {
        ScrollContent1.SetActive(false);
        ScrollContent2.SetActive(true);
        ScrollContent3.SetActive(false);
        ScrollContent4.SetActive(false);
    }

    public void ItemVarButton3()
    {
        ScrollContent1.SetActive(false);
        ScrollContent2.SetActive(false);
        ScrollContent3.SetActive(true);
        ScrollContent4.SetActive(false);
    }

    public void ItemVarButton4()
    {
        ScrollContent1.SetActive(false);
        ScrollContent2.SetActive(false);
        ScrollContent3.SetActive(false);
        ScrollContent4.SetActive(true);
    }
}
