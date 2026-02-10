using UnityEngine;
using System.Collections;

public class PlayerControllerTest : MonoBehaviour {
    public Transform target;
    UnityEngine.AI.NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        if (target) {
            agent.destination = target.transform.position;
        }

    }
}
