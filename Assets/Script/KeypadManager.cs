using UnityEngine;
using UnityEngine.UI;

public class KeypadManager : MonoBehaviour
{
    public Text displayText;
    private string enteredCode = "";
    public string correctCode = "318";  // Ganti dengan kode yang diinginkan
    public DoorController doorController;

    void Start()
    {
        if (displayText == null)
        {
            Debug.LogError("displayText tidak dihubungkan di Inspector.");
        }

        if (doorController == null)
        {
            Debug.LogError("DoorController tidak dihubungkan di Inspector.");
        }
    }

    public void EnterValue(string value)
    {
        enteredCode += value;

        if (displayText != null)
        {
            displayText.text = enteredCode;
        }

        if (enteredCode.Length >= correctCode.Length)
        {
            CheckCode();
        }
    }

    private void CheckCode()
    {
        if (enteredCode == correctCode)
        {
            // Kode benar, buka pintu
            Debug.Log("Kode benar!");
            doorController.OpenDoor();
        }
        else
        {
            // Kode salah
            Debug.Log("Kode salah!");
        }

        // Reset kode yang dimasukkan
        enteredCode = "";

        if (displayText != null)
        {
            displayText.text = "";
        }
    }
}
