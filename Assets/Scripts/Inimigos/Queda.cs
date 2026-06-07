using UnityEngine;

public class Queda : MonoBehaviour
{
      [SerializeField] Transform cameraTransform;
    [SerializeField] float offsetY = -8f;

    void LateUpdate()
    {
        transform.position = new Vector3(
            cameraTransform.position.x,
            cameraTransform.position.y + offsetY,
            transform.position.z
        );
    }

}
