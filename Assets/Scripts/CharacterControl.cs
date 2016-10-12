using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{
    // Use this for initialization
    public float maximumAttackDistance = 0f;
    public bool selected = false;

    public bool following = false;
    public GameObject FollowObject;

    public GameObject AttackBox;
    public bool attacking = false;
    float attackWindUpTimer = 0.75f;

    private NavMeshAgent agent;
    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (FollowObject == null)
        {
            following = false;
        }
        anim.SetBool("Walking", agent.remainingDistance > .1f);
        if (following)
        {
            agent.SetDestination(FollowObject.transform.position);
            Vector3 distance = this.transform.position - FollowObject.transform.position;
            float theDistance = Mathf.Abs(distance.magnitude);
            //Debug.Log(theDistance);
            if (theDistance <= 1.5f)
            {
                anim.SetBool("Attack", agent.remainingDistance > .1f);
            }
        }
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
            following = false;
            agent.SetDestination(clickHit.point);
        }
        else if(clickHit.collider.gameObject.tag == "OfficeMaterial")
        {
            following = true;
            FollowObject = clickHit.collider.gameObject;
        }
        else
        {
            following = false;
        }
    }
    void AttackEnemy()
    {
        if (FollowObject != null)
        {
            Instantiate(AttackBox, FollowObject.transform.position + new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }
    }

    void AttackSound()
    {
        AkSoundEngine.PostEvent("Play_BananaAttack", gameObject);
    }
}
