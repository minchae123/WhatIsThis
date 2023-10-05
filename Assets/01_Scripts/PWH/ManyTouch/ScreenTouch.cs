using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class ScreenTouch : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] protected TextMeshProUGUI Score;

    [SerializeField] Ease ease;
    private Sequence seq;

    protected string Scoretext;
    [SerializeField] private float timeLimit = 20;

    [SerializeField] protected int totalScore;
    private int clickCount;

    private int minCount = 3;
    private int maxCount = 7;

    private bool isClick = false;
    void Start()
    {
        seq = DOTween.Sequence();
        seq.Append(text.transform.DOScale(1.05f, 0.5f).SetLoops(-1, LoopType.Yoyo));

        StartCoroutine(Timer());
    }

    // Update is called once per frame
    public void BtnClick()
    {
        StartCoroutine(ClickDotween());

        clickCount = Random.Range(minCount, maxCount);
        totalScore += clickCount;

        text.text = totalScore.ToString();

        isClick = true;
    }

    private IEnumerator ClickDotween()
    {
        seq.Append(text.transform.DOScale(1.05f, 0.5f).SetLoops(-1, LoopType.Yoyo));
        yield return new WaitForSeconds(.1f);
        seq.Append(text.transform.DOScale(1.5f, 0.1f).SetLoops(2, LoopType.Yoyo));
    }

    private void Update()
    {
        Score.text = timeLimit.ToString();
        Debug.Log(Score.text);
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            if (isClick)
            {
                timeLimit--;
                seq.Kill();

                Sequence s = DOTween.Sequence();
                s.Kill();

                if (timeLimit <= 0)
                {
                    transform.GetComponent<Button>().interactable = false;
                    StopAllCoroutines();
                }
            }
        }
        //s.Append(text.transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo));
        //count++;
    }
}