using System.Collections;
using UnityEngine;
using UnityEngine.AI;

//Created with Anthony Romrell in class. Script causes AI to follow SO position of player using vector3Data scriptableOBJ
[RequireComponent(typeof(NavMeshAgent))]
public class NavAgentBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public Vector3Data destination;
    public Vector3Data newDestination;
    private WaitForFixedUpdate wffu;
    public BoolData canRun;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    public void StartRepeatUntilFalse()
    {
        canRun.value = true;
        StartCoroutine(Follow());
    }

    public void newLocation()
    {
        canRun.value = false;
        StartCoroutine(Wait());
    }
    
    public IEnumerator Follow()
    {
        yield return wffu;
        
        while (canRun.value)
        {
            agent.destination = destination.value;
            yield return wffu;
        }
    }
    
    public IEnumerator Wait()
    {
        yield return wffu;
        
        while (canRun.value == false)
        {
            agent.destination = newDestination.value;
            yield return wffu;
        }
    }
    
}


