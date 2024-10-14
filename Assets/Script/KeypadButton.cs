using UnityEngine;
using UnityEngine.UI;

public class KeypadButton : MonoBehaviour
{
    public string buttonValue;
    private Button button;
    private KeypadManager keypadManager;

    void Start()
    {
        button = GetComponent<Button>();
        keypadManager = FindObjectOfType<KeypadManager>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        keypadManager.EnterValue(buttonValue);
    }
}
