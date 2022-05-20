using UnityEngine;
using System.Collections;
public class MoveBetweenGoals : MonoBehaviour
{

    [SerializeField] private Transform[] goals;
    [SerializeField] private float distanceToChangeGoal;
    private UnityEngine.AI.NavMeshAgent agent;
    private int currentGoal = 0;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goals[0].position;
    }
    void Update()
    {
        if (agent.remainingDistance < distanceToChangeGoal)
        {
            currentGoal++;
            if (currentGoal == goals.Length) currentGoal = 0;
            agent.destination = goals[currentGoal].position;
        }
    }
}