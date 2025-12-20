using UnityEngine;

[DefaultExecutionOrder(10000)]
public class ForceCapsuleHeight4 : MonoBehaviour
{
    [SerializeField] float height = 4f;
    [SerializeField] float radius = 0.25f;

    CapsuleCollider cap;

    void Awake() => cap = GetComponent<CapsuleCollider>();

    void LateUpdate()
    {
        if (!cap) return;

        cap.height = height;
        cap.radius = radius;
        cap.center = new Vector3(0f, height * 0.5f, 0f);
        cap.direction = 1; // Y-axis
    }
}
