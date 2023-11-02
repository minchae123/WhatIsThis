using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;

public class MainUiController : MonoBehaviour
{
    [Header("이름")]
    [SerializeField] private string[] Name;
    [Header("설명")]
    [SerializeField] private string[] Explain;

    public PoolingListSO poolingListSO;

    private UIDocument _doc;

    Dictionary<string, bool> keyBtn = new Dictionary<string, bool>();

    // Start is called before the first frame update
    void Start()
    {
        _doc = GetComponent<UIDocument>();

        for (int i = 1; i <= 10; i++)
        {
            VisualElement visual = _doc.rootVisualElement.Q<VisualElement>($"image{i}");
            Label label = visual.Q<Label>($"explain{i}");
            label.text = Name[i - 1];
            visual.RegisterCallback<ClickEvent>(evt => ClickList(evt, label));
            visual.RegisterCallback<ClickEvent>(evt => Regist(visual));

            //if(poolingListSO.list[i].prefab.name == GameManager.Instance.CrabName)
                
        }
    }

    private void Regist(VisualElement visual)
    {

    }

    private void ClickList(ClickEvent evt, Label label)
    {

        string name = Regex.Replace(label.name, @"\D", ""); //str에 문자열중 일반문자를 ""공백문자로 대체한다 
        int _num = int.Parse(name);

        if (keyBtn.ContainsKey(name))
        {
            keyBtn[name] = !keyBtn[name];
        }
        else
            keyBtn.Add(name, true);

        string printExplain = Explain[_num - 1];
        string printName = Name[_num - 1];

        if (keyBtn[name] == true) label.text = printExplain;
        else label.text = printName;
    }

    // Update is called once per frame
    void Update()
    {

    }
}