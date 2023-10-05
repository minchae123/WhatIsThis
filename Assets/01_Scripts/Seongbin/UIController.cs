using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    private Button _settingButton;
    private Button _dictionaryButton;
    private Button _miniGameButton;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _settingButton = root.Q<Button>("SettingButton");
        _settingButton.RegisterCallback<ClickEvent>(OnSettingButtonClicked);

        _dictionaryButton = root.Q<Button>("DictionaryButton");
        _dictionaryButton.RegisterCallback<ClickEvent>(OnDictionaryButtonClicked);

        _miniGameButton = root.Q<Button>("MiniGameButton");
        _miniGameButton.RegisterCallback<ClickEvent>(OnMiniGameButtonClicked);
    }

    private void OnSettingButtonClicked(ClickEvent evt)
    {
        Debug.Log("setting");
    }
    private void OnDictionaryButtonClicked(ClickEvent evt)
    {
        Debug.Log("dictionary");
    }
    private void OnMiniGameButtonClicked(ClickEvent evt)
    {
        Debug.Log("minigame");
    }
}
