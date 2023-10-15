using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;

public class MainUiController : MonoBehaviour
{
    [Header("�̸�")]
    [SerializeField] private string[] Name;
    [Header("����")]
    [SerializeField] private string[] Explain;
    private UIDocument _doc;

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
        }
    }

    private void ClickList(ClickEvent evt, Label label)
    {
        string name = Regex.Replace(label.name, @"\D", ""); //str�� ���ڿ��� �Ϲݹ��ڸ� ""���鹮�ڷ� ��ü�Ѵ� 
        int _num = int.Parse(name);
        string print = Explain[_num - 1];
        label.text = print;
    }

    // Update is called once per frame
    void Update()
    {

    }
}