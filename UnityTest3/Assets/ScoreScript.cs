using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text score;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        this.score = GameObject.Find("Score").GetComponent<Text>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncScore()
    {
        count++;
        score.text = count.ToString();
    }

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "")
        {
            //UI Ä«¿îÅÍ +1
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<ScoreScript>().IncScore();

            //ÃÑ¾Ë ÆÄ±«
            Destroy(gameObject);
        }
    }
}
