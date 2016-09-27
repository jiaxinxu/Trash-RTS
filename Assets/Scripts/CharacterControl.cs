using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

	// Use this for initialization
	public bool selected = false;
	private NavMeshAgent agent;
	//private Animator anim;
	private Vector3 MoveTo;
	private bool Move = false;

	void  Start (){
		//anim = gameObject.transform.FindChild("Constructor").GetComponent<Animator>();
		agent = gameObject.GetComponent<NavMeshAgent>();
	}

	void  Update (){
		if (selected && Move)
		{
			agent.SetDestination(MoveTo);
		}
		if (agent.pathStatus == NavMeshPathStatus.PathComplete)
		{
			Move = false;
		}
	}

	void  Select (int x){
		selected = true;
	}

	void  Deselect (int x){
		selected = false;
	}

	void  Destination (Vector3 d){
		MoveTo = d;
		Move = true;
	}

		


		
	}
	


