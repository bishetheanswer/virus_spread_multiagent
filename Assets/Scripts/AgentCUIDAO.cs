using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCUIDAO : MonoBehaviour
{
    private enum State {
        Roam,
        Chase
    }

    UnityEngine.AI.NavMeshAgent navMeshAgent;
    public float timeForNewPath;
    public float visionRadius;
    public float speed;
    bool inCoRoutine;
    Vector3 target;
    private State state;
    GameObject agentB;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();   
        state = State.Roam; 
        agentB = GameObject.FindGameObjectWithTag("Agent-B");
    }

    void Update ()
    {
        float dist = Vector3.Distance(agentB.transform.position, transform.position);

        if(dist < visionRadius)
        {
            target = agentB.transform.position;
            state = State.Chase;
        } else {
            state = State.Roam;
        }

        if(!inCoRoutine)
        {
            StartCoroutine(DoSomething());
        }      
    }   

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-20,20);
        float z = Random.Range(-20,20);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }

    IEnumerator DoSomething ()
    {
        inCoRoutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        GetNewPath();
        inCoRoutine = false;
    }

    void GetNewPath ()
    {
        switch (state)
        {
            default:

            case State.Roam:
                navMeshAgent.SetDestination(getNewRandomPosition());
                break;
            
            case State.Chase:
                navMeshAgent.SetDestination(target);
                break;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);    
    }
}
