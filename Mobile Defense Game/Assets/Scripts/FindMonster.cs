using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMonster : MonoBehaviour {

    public GameObject character;
    private CharacterBehavior characterBehavior;
    private float coolTime;
    private float lastAttackTime;

	void Start () {
        characterBehavior = character.GetComponent<CharacterBehavior>();
        coolTime = character.GetComponent<CharacterStat>().coolTime;
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            if(Time.time - lastAttackTime > coolTime)
            {
                int damage = character.GetComponent<CharacterStat>().damage;
                characterBehavior.attack(damage);
                lastAttackTime = Time.time;
            }
        }
    }

    void Update () {
		
	}
}
