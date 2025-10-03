using UnityEngine;

public class PlayerController : MonoBehaviour {
    // === PUBLIC VARIABLES ===
    // Các biến public sẽ hiện ra trong Inspector để chúng ta dễ dàng tinh chỉnh
    [Header("Movement Settings")]
    public float forwardSpeed = 8f;     // Tốc độ di chuyển tới trước
    public float moveSpeed = 15f;       // Độ nhạy khi di chuyển ngang
    public float horizontalLimit = 4.5f;// Giới hạn di chuyển hai bên

    // === PRIVATE VARIABLES ===
    // Biến private ẩn trong Inspector, chỉ dùng trong script này
    private Vector3 lastMousePosition;

    void Update() {
        // Hàm này được gọi mỗi khung hình

        //HandleForwardMovement();
        HandleHorizontalMovement();
    }

    //private void HandleForwardMovement() {
    //    // Luôn di chuyển Player về phía trước (trục Z)
    //    transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    //}

    private void HandleHorizontalMovement() {
        // Kiểm tra nếu người dùng đang nhấn và giữ chuột trái
        if (Input.GetMouseButton(0))
        {
            // Lấy vị trí chuột hiện tại
            Vector3 currentMousePosition = Input.mousePosition;

            // Nếu đây là lần đầu nhấn chuột trong chuỗi kéo thả, hãy khởi tạo vị trí
            if (Input.GetMouseButtonDown(0))
            {
                lastMousePosition = currentMousePosition;
            }

            // Tính toán sự khác biệt so với vị trí chuột ở khung hình trước
            Vector3 delta = currentMousePosition - lastMousePosition;

            // Di chuyển Player sang ngang (trục X) dựa trên sự thay đổi của chuột
            transform.Translate(delta.x * moveSpeed * Time.deltaTime * Vector3.right);

            // Cập nhật lại vị trí chuột cho lần kiểm tra ở khung hình sau
            lastMousePosition = currentMousePosition;
        }

        ApplyBounds();
    }

    private void ApplyBounds() {
        // Giới hạn Player không bị văng ra khỏi Path
        Vector3 currentPosition = transform.position;

        // Sử dụng Mathf.Clamp để kẹp giá trị của trục X trong khoảng [-limit, +limit]
        currentPosition.x = Mathf.Clamp(currentPosition.x, -horizontalLimit, horizontalLimit);

        // Gán lại vị trí đã được giới hạn
        transform.position = currentPosition;
    }
}