using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10.0f;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShootToEnemy()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, speed));
    }

    public void ShootToPlayer()
    {
        player = GameObject.Find("Player");

        Vector3 dir = player.transform.position - this.transform.position;
        GetComponent<Rigidbody>().AddForce(dir * speed / 10);
    }

    public void OnCollisionEnter(Collision coll)
    {
        print("name : " + coll.collider.name);

        if (coll.collider.tag == "ENEMY")
        {
            // UI Ä«¿îÅÍ +1
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<ScoreScript>().IncScore();

            // ÃÑ¾Ë ÆÄ±«
            Destroy(gameObject);
        }

        if (coll.collider.name == "Target1")
        {
            // UI Ä«¿îÅÍ +1
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<ScoreScript>().IncScore(2);

            // ÃÑ¾Ë ÆÄ±«
            Destroy(gameObject, 0.0f);
        }

        if (coll.collider.name == "Target2")
        {
            // UI Ä«¿îÅÍ +1
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<ScoreScript>().IncScore(3);

            // ÃÑ¾Ë ÆÄ±«
            Destroy(gameObject, 0.0f);
        }

        if (coll.collider.name == "Target3")
        {
            // UI Ä«¿îÅÍ +1
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<ScoreScript>().IncScore(5);

            // ÃÑ¾Ë ÆÄ±«
            Destroy(gameObject, 0.0f);
        }

    }

}
