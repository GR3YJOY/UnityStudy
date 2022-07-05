using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator2 : MonoBehaviour
{
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Shoot()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 0.5초마다 실행
        this.time += Time.deltaTime;

        if (this.time > 0.5f)
        {
            //프리펩을 이용해서 오브젝트(총알) 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // BulleController에서 Shoot 메서드 호출(총알 발사)
            bullet.GetComponent<BulletController>().ShootToEnemy();

            this.time = 0.0f;
        }

        /*
        if (Input.GetMouseButtonDown(0))
        {
            //프리펩을 이용해서 오브젝트(총알) 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // BulleController에서 Shoot 메서드 호출(총알 발사)
            bullet.GetComponent<BulletController>().ShootToPlayer();
        }
        */
    }
}
