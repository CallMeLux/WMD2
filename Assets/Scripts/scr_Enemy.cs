using UnityEngine;
using UnityEngine.AI;

public class scr_Enemy : MonoBehaviour
{
    public Transform [] points;
    public int destPoint = 0;
    public Transform chasePlayer;
    public bool chase;
    public NavMeshAgent agent;
    public Animator e_animator;
    
    void Start()
    {
        chase = false;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
    }
    void GotoNextPoint()
    {
        if (points.Length == 0)
        return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    void Update()
    {
        if (chase)
        {
            agent.destination = chasePlayer.position;
        }
        else
        {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        GotoNextPoint();
        e_animator.SetBool("isRunning", true);
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Chase")
        {
            chase = true;
        }
        if (Input.GetButton("Fire1") && other.tag == "CatchPlane")
        {
            Destroy(gameObject);
            Debug.Log("oh no I die :(");
        }
    }
    public void OntriggerExit(Collider other)
    {
        if (other.tag == "Chase")
        {
        chase = false;
        }
    }

}
