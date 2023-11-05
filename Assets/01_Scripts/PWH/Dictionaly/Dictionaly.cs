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
    [SerializeField] private RectTransform rty;

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

        //explain.transform.position = transform.position;

        //explain.transform.DOScale(new Vector2(800, 1400), 1);
        //explain.transform.DOMove(Vector2.zero, 1);

        var seq = DOTween.Sequence();

        // DOScale 의 첫 번째 파라미터는 목표 Scale 값, 두 번째는 시간입니다.
        seq.Append(explain.transform.DOScale(1.1f, 0.2f));
        seq.Append(explain.transform.DOScale(1f, 0.1f));

        seq.Play();
    }
}
