using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent_B_Behavior : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    public float timeForNewPath;
    bool inCoRoutine;
    Vector3 target;

    

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();    
    }

    void Update ()
    {
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
        navMeshAgent.SetDestination(getNewRandomPosition());
    }
}
