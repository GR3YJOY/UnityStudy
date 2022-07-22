using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite dmgSprite;
    public int hp = 3;

    public AudioClip hitSound1;
    public AudioClip hitSound2;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageWall(int loss)
    {
        SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
        spriteRenderer.sprite = dmgSprite;

        hp -= loss;

        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}

    