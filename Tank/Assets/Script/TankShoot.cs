using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    public Rigidbody prefabShell;
    public Transform fireTransform;

    public int playerNum = 1;
    string fireName;

    // Start is called before the first frame update
    void Start()
    {
        fireName = "Fire" + playerNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(fireName)) //Fire1 : space bar
        {
            // Æ÷Åº ÇÁ¸®ÆÕ °´Ã¼ »ý¼º
            Rigidbody shellInstance = Instantiate(prefabShell, fireTransform.position, fireTransform.rotation) as Rigidbody;

            // Æ÷Åº ¹ß»ç
            shellInstance.velocity = 20.0f * fireTransform.forward;
        }
    }
}