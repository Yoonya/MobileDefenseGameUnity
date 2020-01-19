using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterBehavior : MonoBehaviour {

    private CharacterStat characterStat;

    public GameObject bullet;
    private Animator animator;
    private AudioSource audioSource;

    private GameObject bulletObjectPool;
    private ObjectPooler bulletObjectPooler;
    
	void Start () {
        characterStat = gameObject.GetComponent<CharacterStat>();
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        if (gameObject.name.Contains("Character 1"))
        {
            bulletObjectPool = GameObject.Find("Bullet1 Object Pool");
        }
        else if (gameObject.name.Contains("Character 2"))
        {
            bulletObjectPool = GameObject.Find("Bullet2 Object Pool");
        }
        bulletObjectPooler = bulletObjectPool.GetComponent<ObjectPooler>();
    }

    public void attack(int damage)
    {

        GameObject bullet = bulletObjectPooler.getObject();
        if (bullet == null) return;
        bullet.transform.position = gameObject.transform.position;

        bullet.GetComponent<BulletBehavior>().bulletStat = new BulletStat(10 + characterStat.level * 3, characterStat.damage);

        animator.SetTrigger("Attack");
        audioSource.PlayOneShot(audioSource.clip);
        bullet.GetComponent<BulletBehavior>().Spawn();
    }
	
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject(-1) == true) return;
        if (EventSystem.current.IsPointerOverGameObject(0) == true) return;
        if (characterStat.canLevelUp(GameManager.instance.seed))
        {
            characterStat.increaseLevel();
            GameManager.instance.seed -= characterStat.upgradeCost;
            GameManager.instance.updateText();
        }
    }
}
