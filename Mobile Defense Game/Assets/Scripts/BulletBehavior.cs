using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public BulletStat bulletStat { get; set; }

    public BulletBehavior()
    {
        bulletStat = new BulletStat(0, 0); //프로퍼티는 무조건 생성자, start에서 하면 오류 걸림
    }
    public GameObject character;

	void Start () {
        Destroy(gameObject, 3.0f);
	}
	
	void Update () {
        transform.Translate(Vector2.right * bulletStat.speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
            other.GetComponent<MonsterStat>().attacked(bulletStat.damage);
        }   
    }
}
