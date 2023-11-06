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

    private bool isDot = false;
    private RectTransform rt;
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

    private void Update()
    {
        if((Input.touchCount > 0 || Input.GetMouseButtonDown(0)) && !isDot)
            explain.GetComponent<RectTransform>().DOSizeDelta(Vector2.zero, 1);
    }

    public void ShowExplain()
    {
        Debug.Log("asfghjhgfwerthvc");

        //Vector3 mousePosition = Input.mousePosition;

        //// 스크린 좌표를 월드 좌표로 변환합니다.
        //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //// 대상 RectTransform의 위치와 크기를 가져옵니다.
        //Vector3 rectPosition = explain.GetComponent<RectTransform>().position;
        //Vector2 rectSize = explain.GetComponent<RectTransform>().sizeDelta;

        //// 스크린 좌표를 RectTransform 로컬 좌표로 변환합니다.
        //Vector2 localMousePosition = new Vector2(
        //    (int)(mousePosition.x - rectPosition.x) / rectSize.x,
        //    (int)(mousePosition.y - rectPosition.y) / rectSize.y
        //);

       //GameObject clickGameObject = EventSystem.current.currentSelectedGameObject;
        MoveUI();
    }
    //private void MoveUI(Vector2 trm)
    private void MoveUI()
    {
        rt = explain.GetComponent<RectTransform>();
        //explain.GetComponent<RectTransform>().localPosition = trm.GetComponent<RectTransform>().localPosition;

        rt.DOSizeDelta(new Vector2(800, 1400), 1);
        rt.DOAnchorPosX(0, 1);
        rt.DOAnchorPosX(0, 1);

        isDot = true;
    }
}
