using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateCharacter : MonoBehaviour {

    public GameObject characterPrefab1;
    public GameObject characterPrefab2;

    private GameObject characterPrefab;
    private GameObject character;
    private AudioSource audioSource;
    private GameManager gameManager;

	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}
	
	void Update () {
		
	}

    private void OnMouseDown()
    {
        // 마우스: -1, 모바일: 0 이상
        if (EventSystem.current.IsPointerOverGameObject(-1) == true) return;
        if (EventSystem.current.IsPointerOverGameObject(0) == true) return;
        if (gameManager.nowSelect == 1)
        {
            characterPrefab = characterPrefab1;
        }
        else if(gameManager.nowSelect == 2)
        {
            characterPrefab = characterPrefab2;
        }
        if(character == null)
        {
            CharacterStat characterStat = characterPrefab.GetComponent<CharacterStat>();
            if(characterStat.canCreate(gameManager.seed))
            {
                character = (GameObject)Instantiate(characterPrefab, transform.position, Quaternion.identity);
                audioSource.PlayOneShot(audioSource.clip);
                gameManager.seed -= character.GetComponent<CharacterStat>().cost;
                gameManager.updateText();
            }
        }
    }
}
