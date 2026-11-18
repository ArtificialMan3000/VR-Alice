using UnityEngine;

public class CubeScript : MonoBehaviour
{

    public Transform form;
    public Vector3 position;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        form = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        position = form.position;
        position.y += 0.01f;
        form.position = position;
    }
}
