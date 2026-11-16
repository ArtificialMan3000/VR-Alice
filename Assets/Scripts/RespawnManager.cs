using UnityEngine;
using Unity.XR.CoreUtils;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance;

    [Header("Player")]
    public XROrigin player;

    [Header("Respawn Settings")]
    public float fallThreshold = -10f;

    private Vector3 checkpointPosition;
    private Quaternion checkpointRotation;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (player != null)
        {
            // Запоминаем начальную позицию игрока
            checkpointPosition = player.transform.position;
            checkpointRotation = player.transform.rotation;
        }
        else
        {
            Debug.LogError("RespawnManager: не назначен XR Origin!");
        }
    }

    private void Update()
    {
        if (player != null &&
            player.transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        checkpointPosition = checkpoint.position;
        checkpointRotation = checkpoint.rotation;

        Debug.Log("Checkpoint activated!");
    }

    private void Respawn()
    {
        CharacterController controller =
            player.GetComponent<CharacterController>();

        // Временно отключаем Character Controller,
        // чтобы он не мешал перемещению XR Origin
        if (controller != null)
        {
            controller.enabled = false;
        }

        player.transform.SetPositionAndRotation(
            checkpointPosition,
            checkpointRotation
        );

        if (controller != null)
        {
            controller.enabled = true;
        }

        Debug.Log("Player respawned!");
    }
}