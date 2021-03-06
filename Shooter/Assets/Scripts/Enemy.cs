using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float health;

    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;

    Rigidbody2D rd;

    public float curBulletDelay = 0f;
    public float maxBulletDelay;

    public GameObject goBullet;
    public GameObject goPlayer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        rd = GetComponent<Rigidbody2D>();
        rd.velocity = Vector2.down * speed;    //velocity : 속도
    }

    // Update is called once per frame
    void Update()
    {
        fire();
        ReloadBullet();
    }

    void fire()
    {
        if (curBulletDelay < maxBulletDelay)
            return;

        GameObject createBullet = Instantiate(goBullet, transform.position, Quaternion.identity);
        Rigidbody2D rd = createBullet.GetComponent<Rigidbody2D>();

        Vector3 dirVec = goPlayer.transform.position - transform.position;

        rd.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);

        curBulletDelay = 0;
    }

    void ReloadBullet()
    {
        curBulletDelay += Time.deltaTime;
    }


    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BORDER")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "PLAYERBULLET")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.power);

            Destroy(collision.gameObject);
        }
    }

    void OnHit(float playerBulletPower)
    {
        health -= playerBulletPower;

        spriteRenderer.sprite = sprites[1];

        Invoke("ReturnSprite", 0.1f); //이벤트함수, StartCouroutine으로도 써보자.

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
