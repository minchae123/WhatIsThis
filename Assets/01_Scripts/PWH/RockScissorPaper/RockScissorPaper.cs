using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using RcpEnum;

namespace RcpEnum
{
    public enum RCP
    {
        rock,
        scissor,
        paper
    }

}
public class RockScissorPaper : AutoRCP
{
    private float timeLimit = 4;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private Button[] buttons;

    private bool isUI;
    public bool isBtn;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isBtn);
        countText.text = (Timer() == null)? "" : Timer()[0].ToString();
        ShowUI();
    }

    private string Timer()
    {
        float curruntTime = Time.deltaTime;
        timeLimit -= curruntTime;
        isUI = timeLimit < 1;
        return timeLimit < 1? " " : timeLimit.ToString();
    }

    private void ShowUI()
    {
        if(isUI)
            foreach(var i in buttons)
                i.gameObject.SetActive(true);
    }

    #region UI-Button
    public void Rock()
    {
        rcpState = RCP.rock;
        InitRcp();
    }
    public void Scissor()
    {
        rcpState = RCP.scissor;
        InitRcp();
    }
    public void Papper()
    {
        rcpState = RCP.paper;
        InitRcp();
    }
    #endregion
}
