using UnityEngine;
using UnityEngine.AI;

public class scr_Bunny : MonoBehaviour
{
[SerializeField]
    private NavMeshAgent agent;
    public float EnemyDistanceRun = 4.0f;
    [SerializeField]
    GameObject player;
    float x;
    float y;
    float z;
    [SerializeField]
    Vector3 randomPos;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        x = Random.Range(this.transform.position.x -30, this.transform.position.x +30);
        y = this.transform.position.y;
        z = Random.Range(this.transform.position.z - 30, this.transform.position.z + 30);
        randomPos = new Vector3 (x,y,z); 

    }
        private void Update()
    {
        RunAwayFromPlayer();
        Debug.Log(randomPos);
    }
        void RunAwayFromPlayer ()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log ("Distance: " + distance);

        if (distance < EnemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;
            agent.SetDestination(newPos);
        }
        else
        {
        if (this.transform.position.x == randomPos.x && this.transform.position.z == randomPos.z)
        {
        x = Random.Range(this.transform.position.x -30, this.transform.position.x +30);
        y = this.transform.position.y;
        z = Random.Range(this.transform.position.z - 30, this.transform.position.z + 30);
        randomPos = new Vector3 (x,y,z); 
        agent.SetDestination(randomPos);
        }
        else
        {
            agent.SetDestination(randomPos);
        }
        }
    }
}
