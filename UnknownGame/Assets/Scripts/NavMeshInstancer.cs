using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu]
public class NavMeshInstancer : ScriptableObject
{
    public GameObject agentPrefab;


    public void InstantiateNavMeshAgent()
    {
        NavMeshTriangulation Triangulation = NavMesh.CalculateTriangulation();

        int VertexIndex = Random.Range(0, Triangulation.vertices.Length);

        NavMeshHit Hit;
        if (NavMesh.SamplePosition(Triangulation.vertices[VertexIndex], out Hit, 2f, -1))
        {
            Instantiate(agentPrefab, Hit.position, Quaternion.identity);
        }

    }



}
