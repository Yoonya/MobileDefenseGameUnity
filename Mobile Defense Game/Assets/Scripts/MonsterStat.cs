using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : MonoBehaviour {

    public float speed = 1.0f;
    public int damage;
    public float coolTime = 2.0f;
    public int hp = 20;
    public int maxHp = 20;
    public Animator animator;

	void Start () {
        animator = gameObject.GetComponent<Animator>();
	}
	
    public int attacked(int damage)
    {
        hp = hp - damage;
        if (hp <= 0)
        {
            animator.SetTrigger("Die");
            Destroy(gameObject, 1.0f);
            gameObject.GetComponent<MonsterBehavior>().died = true;
        }
        return hp;
    }

	void Update () {
		
	}
}
