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
    private Sequence seq;
    // Start is called before the first frame update
    void Start()
    {
        seq = DOTween.Sequence();
        seq.Append(text.transform.DOScale(1.05f, 0.5f).SetLoops(-1, LoopType.Yoyo));
    }

    // Update is called once per frame
    public void BtnClick()
    {
        seq.Kill();
        
        Sequence s = DOTween.Sequence();
        s.Kill();

        s.Append(text.transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo));
        //count++;
    }
}
