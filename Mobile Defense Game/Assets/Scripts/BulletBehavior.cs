using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public BulletStat bulletStat { get; set; }
    public float activeTime = 3.0f;
    public float spawnTime;

    public BulletBehavior()
    {
        bulletStat = new BulletStat(0, 0); //프로퍼티는 무조건 생성자, start에서 하면 오류 걸림
    }
    public GameObject character;

    public void Spawn()
    {
        gameObject.SetActive(true);
        spawnTime = Time.time;
    }

	void Start () {
        Spawn();
	}
	
	void Update () {
        if (Time.time - spawnTime >= activeTime)
        {
            gameObject.SetActive(false);
        }
        else
        {
            transform.Translate(Vector2.right * bulletStat.speed * Time.deltaTime);
        }
       
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            gameObject.SetActive(false);
            other.GetComponent<MonsterStat>().attacked(bulletStat.damage);
        }   
    }
}
