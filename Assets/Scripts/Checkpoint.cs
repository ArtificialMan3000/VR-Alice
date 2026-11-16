using UnityEngine;
using Unity.XR.CoreUtils;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, вошёл ли в зону XR Origin
        XROrigin player = other.GetComponentInParent<XROrigin>();

        if (player != null && RespawnManager.Instance != null)
        {
            RespawnManager.Instance.SetCheckpoint(transform);
        }
    }
}
