using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBallController : MonoBehaviour
{
    private Rigidbody ballRd;
    public float speed = 0.0f;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        ballRd = GetComponent<Rigidbody>();
        ballRd.AddForce(Random.Range(-500.0f, 500.0f), 0f, speed * 0.7f);

        startPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WALL") || collision.gameObject.CompareTag("RACKET"))
        {
            Vector3 currPos = transform.position;

            Vector3 incomVec = currPos - startPos;
            Vector3 normalVec = collision.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);
            reflectVec = reflectVec.normalized;

            ballRd.AddForce(reflectVec * speed);
        }

        if (collision.gameObject.CompareTag("BLOCK"))
        {
            Vector3 currPos = transform.position;

            Vector3 incomVec = currPos - startPos;
            Vector3 normalVec = collision.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);
            reflectVec = reflectVec.normalized;

            ballRd.AddForce(reflectVec * speed);

            // ºí·Ï ÆÄ±«
            Destroy(collision.gameObject);
        }

        startPos = transform.position;
    }
}
