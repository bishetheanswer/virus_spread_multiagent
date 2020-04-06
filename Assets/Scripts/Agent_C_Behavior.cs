using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent_C_Behavior : MonoBehaviour
{
    private float start_time;
    private float elapsed_time;
    public GameObject agentB_original;
    private GameObject agentB_clone;
    public GameObject agentC_original;

    // Start is called before the first frame update
    void Start()
    {
        start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed_time = Time.time - start_time;
        if(elapsed_time > 10.0f)
        {
            agentB_clone = Instantiate(agentB_original, agentC_original.GetComponent<Transform>().position, agentC_original.GetComponent<Transform>().rotation);
            Destroy(agentC_original);
        }
    }
}
