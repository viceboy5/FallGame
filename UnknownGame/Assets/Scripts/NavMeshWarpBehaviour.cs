using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshWarpBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3Data newLoc;
    
    public void Warp()
    {
        agent.Warp(newLoc.value);
    }
}

