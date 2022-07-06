using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    float mvSpeed = 10.0f; //move(탱크가 앞뒤로 이동)
    float roSpeed = 150.0f; //rotate(탱크 좌우로 회전)

    public int playerNum = 1;  //탱크 번호
    private string mvAxisName; //이동축 이름 (Vertical1, Vertical2 : w,s,a,d)
    private string roAxisName; //회전축 이름 (Horizontal1, Horizontal2 : ↑,↓,←,→)


    // Start is called before the first frame update
    void Start()
    {
        mvAxisName = "Vertical" + playerNum;
        roAxisName = "Horizontal" + playerNum;
    }

    // Update is called once per frame
    void Update()
    {
        float mv = Input.GetAxis(mvAxisName) * mvSpeed * Time.deltaTime;
        float ro = Input.GetAxis(roAxisName) * roSpeed * Time.deltaTime;

        transform.Translate(0, 0, mv);
        transform.Rotate(0, ro, 0);
    }
}
