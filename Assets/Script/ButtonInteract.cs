using UnityEngine;
using UnityEngine.UI;

public class ButtonInteract : MonoBehaviour
{
    public Transform playerCamera; // Kamera yang terhubung ke objek pemain
    public float interactDistance = 10f; // Jarak maksimal interaksi
    public GameObject reticlePrefab; // Prefab untuk reticle pointer

    private GameObject reticleInstance; // Instance dari prefab reticle pointer
    private Button currentButton;
    private Color defaultReticleColor; // Warna reticle default

    void Start()
    {
        // Mendapatkan komponen Camera dari objek pemain jika belum diatur
        if (playerCamera == null)
        {
            playerCamera = Camera.main.transform; // Menggunakan kamera utama jika tidak diatur
        }

        // Instansiasi prefab reticle pointer
        if (reticlePrefab != null)
        {
            reticleInstance = Instantiate(reticlePrefab);
            reticleInstance.transform.SetParent(transform); // Atur parent ke objek ini (atau objek pemain)
            reticleInstance.transform.localPosition = Vector3.zero; // Letakkan di tengah
            reticleInstance.SetActive(false); // Mulai tidak aktif
        }

        // Simpan warna reticle default
        if (reticleInstance != null)
        {
            defaultReticleColor = reticleInstance.GetComponent<Image>().color;
        }
    }

    void Update()
    {
        // Lakukan raycasting dari tengah layar (reticle pointer)
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            // Jika terkena objek dengan komponen Button
            Button button = hit.collider.GetComponent<Button>();
            if (button != null)
            {
                // Ubah posisi reticle sesuai dengan hit dari raycast
                if (reticleInstance != null)
                {
                    reticleInstance.SetActive(true);
                    reticleInstance.transform.position = hit.point;
                }

                // Jika tombol berbeda dari tombol sebelumnya
                if (button != currentButton)
                {
                    // Hapus seleksi dari tombol sebelumnya
                    if (currentButton != null)
                    {
                        currentButton.OnDeselect(null);
                    }

                    // Set tombol saat ini dan seleksi
                    currentButton = button;
                    currentButton.Select();

                    // Ubah warna reticle saat menatap tombol
                    if (reticleInstance != null)
                    {
                        reticleInstance.GetComponent<Image>().color = Color.red; // Ganti dengan warna yang diinginkan
                    }
                }

                // Jika tombol ditekan
                if (Input.GetButtonDown("Fire1")) // Tombol default untuk Google VR SDK
                {
                    currentButton.onClick.Invoke();
                }
            }
            else
            {
                // Sembunyikan reticle jika tidak ada objek yang terkena
                if (reticleInstance != null)
                {
                    reticleInstance.SetActive(false);
                }

                // Hapus seleksi jika tidak ada tombol yang terkena
                if (currentButton != null)
                {
                    currentButton.OnDeselect(null);
                    currentButton = null;
                }
            }
        }
        else
        {
            // Sembunyikan reticle jika tidak ada objek yang terkena
            if (reticleInstance != null)
            {
                reticleInstance.SetActive(false);
            }

            // Hapus seleksi jika tidak ada objek yang terkena
            if (currentButton != null)
            {
                currentButton.OnDeselect(null);
                currentButton = null;
            }
        }
    }
}
