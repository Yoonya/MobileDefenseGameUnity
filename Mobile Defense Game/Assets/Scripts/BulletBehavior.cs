using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public float speed = 10.0f;
    public GameObject character;

    private int damage;

    public void setDamage(int input)
    {
        damage = input;
    }

	void Start () {
        Destroy(gameObject, 3.0f);
	}
	
	void Update () {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
            other.GetComponent<MonsterStat>().attacked(damage);
        }   
    }
}
