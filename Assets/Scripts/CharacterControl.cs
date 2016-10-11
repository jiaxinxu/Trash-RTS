using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{
    // Use this for initialization
    public float maximumAttackDistance = 0f;
    public bool selected = false;

    private NavMeshAgent agent;
    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        anim.SetBool("Walking", agent.remainingDistance > .1f);
    }

    void Select(int x)
    {
        selected = true;
    }

    void Deselect(int x)
    {
        selected = false;
    }

    void RightClick(RaycastHit clickHit)
    {
        Debug.Log("test");
        if(clickHit.collider.gameObject.tag == "Table")
        {
            agent.SetDestination(clickHit.point);
        }
        else if(clickHit.collider.gameObject.tag == "OfficeMaterial")
        {

        }
    }
}



