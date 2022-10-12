using UnityEngine;
using UnityEngine.AI;

//Created with Anthony Romrell in class. Script causes AI to follow SO position of player using vector3Data scriptableOBJ
[RequireComponent(typeof(NavMeshAgent))]
public class NavAgentBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public Vector3Data playerLoc;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        agent.destination = playerLoc.value;
    }
}


