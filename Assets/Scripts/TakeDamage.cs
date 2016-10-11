using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

    public GameObject thePlayer;
    public int health = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Die();
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "TrashAttack")
        {
            health--;
            Debug.Log("I'm hit!");
        }
    }

    void Die()
    {
        thePlayer.GetComponent<CharacterControl>().following = false;
        Destroy(this.gameObject);
    }
}
