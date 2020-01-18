using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour {

    public List<GameObject> respawnSpotList;

    public GameObject monster1Prefab;
    public GameObject monster2Prefab;

    private GameObject monsterPrefab;

    private float lastSpawnTime;
    private int spawnCount = 0;

    void Start () {     
        monsterPrefab = monster1Prefab;
        lastSpawnTime = Time.time;
	}
	
	void Update () {
		if(GameManager.instance.round <= GameManager.instance.totalRound)
        {
            float timeGap = Time.time - lastSpawnTime;
            if(((spawnCount == 0 && timeGap > GameManager.instance.roundReadyTime) // 새 라운드가 시작
                || timeGap > GameManager.instance.spawnTime)
                && spawnCount < GameManager.instance.spawnNumber)
            {
                lastSpawnTime = Time.time;
                int index = Random.Range(0, 4);
                GameObject respawnSpot = respawnSpotList[index];
                
                Instantiate(monsterPrefab, respawnSpot.transform.position, Quaternion.identity);
                spawnCount += 1;
            }
            if(spawnCount == GameManager.instance.spawnNumber &&
               GameObject.FindGameObjectWithTag("Monster") == null)
            {
                if(GameManager.instance.totalRound == GameManager.instance.round)
                {
                    GameManager.instance.gameClear();
                    GameManager.instance.round += 1;
                    return;
                }
                GameManager.instance.clearRound();
                spawnCount = 0;
                lastSpawnTime = Time.time;

                if(GameManager.instance.round == 4)
                {
                    monsterPrefab = monster2Prefab;
                    GameManager.instance.spawnTime = 2.0f;
                    GameManager.instance.spawnNumber = 10;
                }
            }
        }
	}
}
