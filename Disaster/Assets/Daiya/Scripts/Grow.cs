using UnityEngine;

public class Grow: MonoBehaviour {

    public GameObject kenzan;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Instantiate(kenzan, transform.position, Quaternion.identity);
        }
        
    }
}
