using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Camera camera;

    private void LateUpdate()
    {
        Vector3 cameraPos = camera.transform.position;
        float cameraZ = cameraPos.z;

        camera.transform.position = new Vector3(transform.position.x, transform.position.y, cameraZ);
    }
}
