using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Dictionaly : MonoBehaviour
{
    [SerializeField] private PoolingListSO _poolingSO;
    [SerializeField] private CrabSO[] _crabSO;
    [SerializeField] private GameObject BtnImage;
    [SerializeField] private Transform contentTr;
    [SerializeField] private GameObject explain;

    private readonly string _imageName = "Visual";
    private RectTransform rt;

    private void OnEnable()
    {
        for (int i = 0; i < _poolingSO.list.Count; i++)
        {
            GameObject obj = Instantiate(BtnImage);

            obj.transform.parent = contentTr;
            obj.transform.localScale = Vector3.one;


            for (int j = 0; j < obj.GetComponentsInChildren<Image>().Length; j++)
            {
                if (obj.GetComponentsInChildren<Image>()[j].name == _imageName)
                {
                    Image visual = obj.GetComponentsInChildren<Image>()[j];
                    visual.sprite = _crabSO[i].Image;
                }
            }
        }
    }

    private void Awake()
    {
        //explain = GetComponent<RectTransform>();
    }

    public void ShowExplain()
    {
        Debug.Log("asfghjhgfwerthvc");

        GameObject clickGameObject = EventSystem.current.currentSelectedGameObject;
        print(clickGameObject.transform.position);
        MoveUI(clickGameObject.transform);
    }

    private void MoveUI(Transform trm)
    {
        rt = explain.GetComponent<RectTransform>();

        //explain.GetComponent<RectTransform>().localPosition = trm.GetComponent<RectTransform>().localPosition;
        rt.anchoredPosition = trm.GetComponent<RectTransform>().anchoredPosition;

        rt.DOSizeDelta(new Vector2(800, 1400), 1);
        rt.DOAnchorPosX(transform.position.x, 1);
        rt.DOAnchorPosX(transform.position.y, 1);
    }
}
