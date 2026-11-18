using UnityEngine;

public class RandomMove : MonoBehaviour {

    public float timer;
    public float speed = 10f;
    public int period = 1;
    private Vector3 randVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int random = Random.Range(0, 11);
        float randomF = Random.Range(0f, 10f);
        createDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > period)
        {
            createDirection();
            MoveSomewhere();
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
            period = Random.Range(1, 6);
        }
        MoveSomewhere();
        print(timer);
    }

    private void MoveSomewhere() {
        transform.position += randVector * speed * Time.deltaTime;
    }

    private void createDirection ()
    {
        randVector = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;
    }
}
