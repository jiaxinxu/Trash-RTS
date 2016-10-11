using UnityEngine;
using System.Collections;

public class EnemyCharacterMovement : MonoBehaviour {

	public float minTarX;
	public float maxTarX;
	public float minTarZ;
	public float maxTarZ;
	float tarX;
	float tarZ;
	float timeSwitch = 3; 
	float dampX;
	float dampZ;
	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
	    CreateTarPoint ();
		agent = gameObject.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timeSwitch <= 0) {
			timeSwitch = 3;
			CreateTarPoint (); 
		}else {
			timeSwitch -= 1 * Time.deltaTime;
            agent.destination = new Vector3(tarX, 0, tarZ);
        }
        //Debug.Log(timeSwitch);
    }
	void CreateTarPoint() {
		dampX = Random.Range (1.0f, 3.0f);
		dampZ = Random.Range (1.0f, 3.0f);

		tarX = Random.Range (minTarX, maxTarX) - dampX;
		tarZ = Random.Range (minTarZ, maxTarZ) - dampZ;
    }
}
