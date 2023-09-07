using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ScreenTouch : MonoBehaviour
{
    int count = 0;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Ease ease;
    // Start is called before the first frame update
    void Start()
    {
        text.transform.DOScale(1.05f, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    public void BtnClick()
    {
        Sequence seq = DOTween.Sequence();

        count++;
        Debug.Log(count);
        Debug.Log(count);
        text.transform.DOKill(false);
        text.transform.DOKill(true);
        text.transform.DOScale(1.05f, 0.1f).SetLoops(-1, LoopType.Yoyo);
    }
}
