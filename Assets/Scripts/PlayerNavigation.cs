using UnityEngine;
using System.Collections;

public class PlayerNavigation : MonoBehaviour {

    Animator theAnimator;
    NavMeshAgent navigationAgent;
    public AudioMaster SoundMaster;

	// Use this for initialization
	void Start () {
        navigationAgent = GetComponent<NavMeshAgent>();
        theAnimator = GetComponentInChildren<Animator>();
        theAnimator.SetBool("Idle", navigationAgent.remainingDistance < .3f);
    }

    // Update is called once per frame
    void Update () {
        ClickToMove();
        if (navigationAgent.remainingDistance > .1f)
        {
            theAnimator.SetBool("Walking", navigationAgent.remainingDistance > .3f);
        }
    }

    //Pretty self explanatory 
    void ClickToMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit mouseClick;

            if (Physics.Raycast(mouseRay, out mouseClick, 100))
            {
                navigationAgent.SetDestination(mouseClick.point);

            }
        }
    }
}  
