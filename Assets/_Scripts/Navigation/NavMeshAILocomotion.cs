using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAILocomotion : MonoBehaviour, IAILocomotion
{
    private NavMeshAgent _agent;
    private Coroutine _moveCoroutine;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updatePosition = false;
        _agent.updateRotation = false;
    }
    
    public void Move(Vector3 point)
    {
        _agent.SetDestination(point);
        
        if (_moveCoroutine != null)
            StopCoroutine(_moveCoroutine);
        
        _moveCoroutine = StartCoroutine(MoveRoutine());
    }

    private IEnumerator MoveRoutine()
    {
        yield return new WaitUntil(() => _agent.hasPath);
        
        var path = _agent.path.corners.Skip(1).ToArray();
        
        foreach (var corner in path)
        {
            while (Vector3.Distance(transform.position, corner) > _agent.stoppingDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, corner, 0.5f);
                yield return null;
            }
        }
    }
    
    public void Stop()
    {
        
    }
}