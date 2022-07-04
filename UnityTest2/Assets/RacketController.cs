using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    private Rigidbody racketRd;
    public float speed = 10.0f;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        racketRd = GetComponent<Rigidbody>();

        startPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            // Rigidbody 물리엔진을 이용한 이동
            //racketRd.AddForce(-speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            // Rigidbody 물리엔진을 이용한 이동
            //racketRd.AddForce(+speed, 0, 0);
        }
    }
}
