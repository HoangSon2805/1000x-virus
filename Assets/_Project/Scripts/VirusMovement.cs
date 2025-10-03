using UnityEngine;

public class VirusMovement : MonoBehaviour {
    // Biến public để có thể chỉnh tốc độ của virus trong Inspector
    public float speed = 10f;

    void Update() {
        // Tương tự Player, mỗi con virus sẽ tự di chuyển về phía trước
        // Vector3.forward là trục Z (hướng tới)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}