using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour {
    int sceneNum;

    private void Awake() {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            if (SceneManager.GetActiveScene().buildIndex == sceneNum) {
                sceneNum++;
                SceneManager.LoadScene(sceneNum);
                } else {
                SceneManager.LoadScene(0);
            }
        }
    }
}
