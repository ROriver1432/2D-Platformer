using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float LifeTime = 0.5f;
    void Start()
    {
        Destroy(gameObject,LifeTime);
    }
    private void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //총알이 Player 태그를 가지지 않는 물체를 맞추면 사라짐, Enemy 태그를 가진 물체를 맞추면 맞췄다는 문구가 뜨고 사라짐
        if (collision.gameObject.tag == "Enemy")
        {
            //적을 맞출 때 발생하는 이벤트, 이후 적이 구현되면 나중에 수정할 부분임
            Debug.Log("적을 맞춤");
            Destroy(this.gameObject);
        }

        //벽이나 바닥에 닿았을 때(Platform 또는 OneWayPlatform 태그를 가진 물체) 총알이 사라짐
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "OneWayPlatform" )
        {
            Destroy(this.gameObject);
        }
    }
}
