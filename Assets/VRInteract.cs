using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRInteract : MonoBehaviour
{
    public Image imgGaze;
    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer = 0;

    public int distanceOfRay = 20;
    private RaycastHit _hit;
    private Button currentButton;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

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

            // Pastikan imgGaze tidak null
            if (imgGaze != null)
            {
                imgGaze.fillAmount = gvrTimer / totalTime;
            }
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        // Gaze Input
        if (Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if (imgGaze != null && imgGaze.fillAmount == 1)
            {
                if (_hit.transform.CompareTag("Teleport"))
                {
                    _hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
                    ResetGaze();
                }

                if (_hit.transform.CompareTag("Button"))
                {
                    currentButton = _hit.transform.GetComponent<Button>();
                    if (currentButton != null)
                    {
                        currentButton.onClick.Invoke();
                        ResetGaze();
                    }
                }
            }
        }

        // Click Input
        if (Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (_hit.transform.CompareTag("Enemy"))
                {
                    Destroy(_hit.transform.gameObject);
                }

                if (_hit.transform.CompareTag("Button"))
                {
                    currentButton = _hit.transform.GetComponent<Button>();
                    if (currentButton != null)
                    {
                        currentButton.onClick.Invoke();
                    }
                }
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

        // Pastikan imgGaze tidak null
        if (imgGaze != null)
        {
            imgGaze.fillAmount = 0;
        }
    }
}
