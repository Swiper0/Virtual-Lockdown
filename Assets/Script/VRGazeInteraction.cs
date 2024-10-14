using UnityEngine;
using UnityEngine.UI;

public class VRGazeInteraction : MonoBehaviour
{
    public Image imgGaze; // Gaze reticle image
    public float totalTime = 2; // Time required to trigger interaction
    public int distanceOfRay = 20; // Raycast distance

    private bool gvrStatus;
    private float gvrTimer;
    private RaycastHit _hit;

    void Start()
    {
        // Pastikan imgGaze dihubungkan
        if (imgGaze == null)
        {
            Debug.LogError("imgGaze tidak dihubungkan di Inspector");
        }
    }

    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            if (imgGaze != null)
            {
                imgGaze.fillAmount = gvrTimer / totalTime;
            }

            if (imgGaze != null && imgGaze.fillAmount == 1)
            {
                Interact();
                ResetGaze();
            }
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Interact();
            }
        }
    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        ResetGaze();
    }

    private void ResetGaze()
    {
        gvrTimer = 0;
        if (imgGaze != null)
        {
            imgGaze.fillAmount = 0;
        }
    }

    private void Interact()
    {
        if (_hit.transform != null && _hit.transform.CompareTag("Interactable"))
        {
            LemariInteractionVR lemari = _hit.transform.GetComponent<LemariInteractionVR>();
            if (lemari != null)
            {
                lemari.Interact();
            }
        }
    }
}
