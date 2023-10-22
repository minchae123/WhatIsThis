using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StoreUITK : MonoBehaviour
{
    [SerializeField]
    private VisualTreeAsset item;

    private UIDocument _document;
    private VisualElement _root;
    private ListView _listView;


    private void Awake()
    {
        _document = GetComponent<UIDocument>();
    }

    private void Start()
    {
        _root = _document.rootVisualElement;
        VisualElement it = item.Instantiate();
        _listView.Add(it);
    }
}
