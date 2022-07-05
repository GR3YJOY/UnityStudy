using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 1.0f;

    public float x;
    private float length = 2.0f;
    private float timeAfterMove;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterMove += Time.deltaTime;
        x = Mathf.Sin(timeAfterMove) * length;

        transform.position = new Vector3(x * speed, transform.position.y, transform.position.z);
     }
}
