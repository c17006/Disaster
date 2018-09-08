using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

    private GameObject player;
    private bool  isOnceSpot= false;
    private float displaceNumber = 40.0f;
    private float movingDistance = -15.0f;


    void Start() {
        player = GameObject.FindWithTag("Player");
    }

    void Update() {
        if (player != null) {
            if (player.transform.position.x >= gameObject.transform.position.x - displaceNumber) {
                transform.Translate(0, movingDistance, 0);
                isOnceSpot = true;
            } else if (player.transform.position.x < gameObject.transform.position.x - displaceNumber && isOnceSpot) {
                transform.Translate(0, movingDistance, 0);
            }
        }
    }
}

