using UnityEngine;

public class Shooter : MonoBehaviour {
    [Header("Shooting Settings")]
    public GameObject virusPrefab; // Prefab của virus để bắn ra
    public float fireRate = 0.2f;  // Thời gian giữa mỗi lần bắn (0.2 giây = 5 viên/giây)

    private float fireTimer; // Bộ đếm thời gian
    public Transform spawnPoint; // Vị trí điểm bắn

    void Update() {
        // Cộng dồn thời gian trôi qua vào bộ đếm
        fireTimer += Time.deltaTime;

        // Kiểm tra xem đã đến lúc bắn viên tiếp theo chưa
        if (fireTimer >= fireRate)
        {
            // Nếu đã đến lúc, thực hiện bắn
            Shoot();

            // Reset bộ đếm về 0 để bắt đầu đếm lại
            fireTimer = 0f;
        }
    }

    void Shoot() {
        if (virusPrefab != null && spawnPoint != null)
        {
            Instantiate(virusPrefab, spawnPoint.position, spawnPoint.rotation);
        } else
        {
            Debug.LogWarning("Virus Prefab or Spawn Point has not been assigned!");
        }
    }
}