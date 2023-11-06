using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Dictionaly : MonoBehaviour
{
    [SerializeField] private PoolingListSO _poolingSO;
    [SerializeField] private CrabSO[] _crabSO;
    [SerializeField] private GameObject BtnImage;
    [SerializeField] private Transform contentTr;
    [SerializeField] private GameObject explain;

    private readonly string _imageName = "Visual";

    private void Awake()
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

    public void ShowExplain()
    {
        Debug.Log("asfghjhgfwerthvc");

        explain = GameObject.Find("Explain");

        explain.GetComponent<RectTransform>().DOSizeDelta(new Vector2(800, 1400), 1);
        //explain.transform.DOScale(new Vector3(800, 1400, 1), 1);
        explain.GetComponent<RectTransform>().DOAnchorPosX(transform.position.x, 1);
        explain.GetComponent<RectTransform>().DOAnchorPosX(transform.position.y, 1);
        //explain.GetComponent<RectTransform>().DOAnchorPosX(0, 1);
    }
}
