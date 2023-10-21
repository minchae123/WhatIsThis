using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    private Button _shopButton;
    private Button _dictionaryButton;
    private Button _miniGameButton;

    private UIDocument _mainUI;
    [SerializeField] private UIDocument _dictionaryUI;
    [SerializeField] private UIDocument _miniGameUI;

    private void Awake()
    {
        _mainUI = GetComponent<UIDocument>();
    }

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _shopButton = root.Q<Button>("ShopButton");
        _shopButton.RegisterCallback<ClickEvent>(OnShopingButtonClicked);

        _dictionaryButton = root.Q<Button>("DictionaryButton");
        _dictionaryButton.RegisterCallback<ClickEvent>(OnDictionaryButtonClicked);

        _miniGameButton = root.Q<Button>("MiniGameButton");
        _miniGameButton.RegisterCallback<ClickEvent>(OnMiniGameButtonClicked);
    }

    private void OnShopingButtonClicked(ClickEvent evt)
    {
        Debug.Log("shoping");


    }
    private void OnDictionaryButtonClicked(ClickEvent evt)
    {
        Debug.Log("dictionary");
        if (_dictionaryUI.enabled)
        {
            Time.timeScale = 1.0f;
            _dictionaryUI.enabled = false;
            _mainUI.enabled = true;
        }
        else
        {
            Time.timeScale = 0f;
            _dictionaryUI.enabled = true;
            _mainUI.enabled = false;
        }
    }
    private void OnMiniGameButtonClicked(ClickEvent evt)
    {
        Debug.Log("minigame");
        if (_miniGameUI.enabled)
        {
            Time.timeScale = 1.0f;
            _miniGameUI.enabled = false;
            _mainUI.enabled = true;
        }
        else
        {
            Time.timeScale = 0f;
            _miniGameUI.enabled = true;
            _mainUI.enabled = false;
        }
    }
}
