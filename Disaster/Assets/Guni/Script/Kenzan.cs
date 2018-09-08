using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kenzan : MonoBehaviour {
    GameObject Player;
    public GameObject PlayerPrefab;
    public GameObject BloodEffect;
    GameObject MainCamera;
    string sceneName;

    private void Awake() {
        Player = GameObject.FindWithTag("Player");
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Start () {
        MainCamera = GameObject.FindWithTag("MainCamera");
	}
	
	void Update () {
        Player = GameObject.FindWithTag("Player");          
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Destroy(Player);
            Instantiate(BloodEffect, Player.transform.position,Player.transform.rotation);
            MainCamera.GetComponent<AudioSource>().volume = 0;
            Invoke("Reload", 2);
        }
    }

    void Reload() {
        if (SceneManager.GetActiveScene().name==sceneName) {
            SceneManager.LoadScene(sceneName);                       
        } else {
            SceneManager.LoadScene(0);
        }
        }
    }
