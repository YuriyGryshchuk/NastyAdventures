using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStateMashine))]
public abstract class State : MonoBehaviour
{
    protected Player Target;
    protected EnemyStateMashine StateMashine;

    public void Enter(Player target, EnemyStateMashine stateMashine)
    {
        Target = target;
        StateMashine = stateMashine;
    }

    public virtual void Exit()
    {

    }
}
