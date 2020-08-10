using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestMove : MonoBehaviour
{
    public float speed;
    public int health;
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;


    public GameObject chunbae;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
      

    }

    void OnHit(int dmg)
    {
        health -= dmg;
        //피격당했을 때 이미지가 바뀐다.
        spriteRenderer.sprite = sprites[1];

        //0.1초 후에 이 함수를 호출해주세요.
        Invoke("ReturnSprite", 0.1f);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    //나간 후에 삭제하는 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderGuest")
        {
            Destroy(this.gameObject);
            print("삭제완료");
        }


        /* 콜리전에 충돌이 감지된 오브젝트의 게임오브젝트에서 겟컴포넌트하는것
          else if(collision.gameObject.tag == "Bullet")
         {
             Bullet bullet = colision.getObject.GetComponent<Bullet>();
             OnHit(bullet.dmg);
         }*/
    }
}