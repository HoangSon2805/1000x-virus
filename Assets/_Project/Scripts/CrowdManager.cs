using System.Collections.Generic;
using UnityEngine;
using TMPro; // Thêm thư viện TextMeshPro

public class CrowdManager : MonoBehaviour {
    // === PUBLIC VARIABLES ===
    public static CrowdManager instance; // Singleton pattern để dễ dàng truy cập từ các script khác
    public TextMeshProUGUI virusCountText; // Ô Text để hiển thị số lượng virus

    // === PRIVATE VARIABLES ===
    private List<GameObject> activeViruses = new List<GameObject>();

    void Awake() {
        // Thiết lập Singleton
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    void Update() {
        // Cập nhật UI mỗi frame
        if (virusCountText != null)
        {
            virusCountText.text = activeViruses.Count.ToString();
        }
    }

    public void AddVirus(GameObject virus) {
        // Hàm để thêm virus vào danh sách quản lý
        activeViruses.Add(virus);
    }
}