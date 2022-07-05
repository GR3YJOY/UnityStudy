using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class BulletGenerator2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float time = 0.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 0.5�ʸ��� ����
        this.time += Time.deltaTime;

        if (this.time > 0.5f)
        {
            // �������� �̿��ؼ� ������Ʈ(�Ѿ�) ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // BulletController���� Shoot �޼��� ȣ��(�Ѿ� �߻�)
            bullet.GetComponent<BulletController>().ShootToPlayer();

            this.time = 0.0f;
        }

        /*
        if (Input.GetMouseButtonDown(0))
        {
            // �������� �̿��ؼ� ������Ʈ(�Ѿ�) ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // BulletController���� Shoot �޼��� ȣ��(�Ѿ� �߻�)
            bullet.GetComponent<BulletController>().ShootToPlayer();
        }
        */
    }
}
