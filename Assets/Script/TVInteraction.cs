using UnityEngine;
using TMPro;

public class TVInteraction : MonoBehaviour
{
    public GameObject screenObject; // Referensi ke GameObject layar TV
    public TextMeshPro textMeshPro; // Referensi ke TextMeshPro terkait
    public Transform reticlePointer; // Referensi ke Transform pointer

    private Vector3 originalScale; // Menyimpan ukuran asli pointer

    void Start()
    {
        // Nonaktifkan TextMeshPro saat memulai
        if (textMeshPro != null)
        {
            textMeshPro.gameObject.SetActive(false);
        }

        // Menyimpan ukuran asli pointer
        if (reticlePointer != null)
        {
            originalScale = reticlePointer.localScale;
        }
    }

    void Update()
    {
        // Menggunakan input dari raycast VR
        if (Input.GetButtonDown("Fire1")) // Input untuk Cardboard VR
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Jika TV terkena objek dengan tag atau nama tertentu
                if (hit.collider.gameObject == gameObject)
                {
                    // Aktifkan TextMeshPro jika sebelumnya tidak aktif
                    if (textMeshPro != null && !textMeshPro.gameObject.activeSelf)
                    {
                        textMeshPro.gameObject.SetActive(true);
                    }
                    else if (textMeshPro != null && textMeshPro.gameObject.activeSelf)
                    {
                        textMeshPro.gameObject.SetActive(false);
                    }

                    // Mengatur ukuran pointer menjadi default saat mengenai TV
                    if (reticlePointer != null)
                    {
                        reticlePointer.localScale = originalScale;
                    }
                }
            }
        }
    }
}
