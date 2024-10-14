using System.Collections;
using UnityEngine;

public class LemariInteractionVR : MonoBehaviour
{
    public Transform door; // Referensi ke transformasi pintu lemari
    public Vector3 openPosition = new Vector3(0.147f, 0, 0.445f); // Posisi terbuka pintu lemari
    public Vector3 openRotation = new Vector3(0, 63.94f, 0); // Rotasi terbuka pintu lemari
    public float openSpeed = 1.0f; // Kecepatan membuka pintu

    private Vector3 closedPosition; // Posisi tertutup pintu lemari
    private Vector3 closedRotation; // Rotasi tertutup pintu lemari
    private bool isOpening = false; // Status apakah pintu sedang dibuka

    void Start()
    {
        // Menyimpan posisi dan rotasi tertutup pintu
        if (door != null)
        {
            closedPosition = door.localPosition;
            closedRotation = door.localEulerAngles;
        }
        else
        {
            Debug.LogError("Referensi door tidak dihubungkan di Inspector.");
        }
    }

    public void Interact()
    {
        if (!isOpening)
        {
            StartCoroutine(OpenDoorCoroutine());
        }
    }

    private IEnumerator OpenDoorCoroutine()
    {
        isOpening = true;

        float elapsedTime = 0;
        while (elapsedTime < 1)
        {
            if (door != null)
            {
                door.localPosition = Vector3.Lerp(closedPosition, openPosition, elapsedTime);
                door.localEulerAngles = Vector3.Lerp(closedRotation, openRotation, elapsedTime);
                elapsedTime += Time.deltaTime * openSpeed;
            }
            yield return null;
        }

        if (door != null)
        {
            door.localPosition = openPosition;
            door.localEulerAngles = openRotation;
        }

        isOpening = false;
    }
}
