using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainUiController : MonoBehaviour
{
    [SerializeField]
    private string[] Explain;
    private UIDocument _doc;

    // Start is called before the first frame update
    void Start()
    {
        _doc = GetComponent<UIDocument>();

        for (int i = 1; i <= 10; i++)
        {
            VisualElement visual = _doc.rootVisualElement.Q<VisualElement>($"image{i}");
            Label label = visual.Q<Label>($"explain{i}");
            visual.RegisterCallback<ClickEvent>(evt => ClickList(evt, label));
        }
    }

    private void ClickList(ClickEvent evt, Label label)
    {
        string name = label.name;
        int idx = (int)name[^1] - '0';
        string print = Explain[idx];
        label.text = print;
    }

    // Update is called once per frame
    void Update()
    {

    }
}