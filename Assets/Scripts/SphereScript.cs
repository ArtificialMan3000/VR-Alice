using UnityEngine;

public class SphereScript : MonoBehaviour
{

    public Rigidbody rbody;
    public SphereCollider cldr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        cldr = GetComponent<SphereCollider>();
        //cldr.isTrigger = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.collider.name);
        rbody.AddForce(new Vector3(10, 20, 30));
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        //rbody.useGravity = false;
        rbody.isKinematic = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
