using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent_A_Behavior : MonoBehaviour
{
    public GameObject agentA_original;
    private GameObject agentA_clone;
    public GameObject agentC_original;
    private GameObject agentC_clone;
    private float start_time;
    private float elapsed_time;
    public GameObject skull_original;
    private GameObject skull_clone;

    // Start is called before the first frame update
    void Start()
    {
        start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed_time = Time.time - start_time;
        if(elapsed_time > 20.0f)
        {
            if( (Random.Range(0.0f, 1.0f)) < 0.7f)
            {
                agentC_clone = Instantiate(agentC_original, agentA_original.GetComponent<Transform>().position, agentA_original.GetComponent<Transform>().rotation);
            }
            else
            {
                skull_clone = Instantiate(skull_original, agentA_original.GetComponent<Transform>().position, agentA_original.GetComponent<Transform>().rotation);
            }
            
            Destroy(agentA_original);
        }
    }

    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "Agent-B")
        {
            GameObject agentB = col.gameObject;
            Transform agentB_T = agentB.GetComponent<Transform>();
            Destroy(agentB);
            agentA_clone = Instantiate(agentA_original, agentB_T.position, agentB_T.rotation);
        }
    }
}
