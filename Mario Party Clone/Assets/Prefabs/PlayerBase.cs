using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerBase : MonoBehaviour {
    private NavMeshAgent agent;
    [SerializeField]
    private GameObject[] board;
    private int currentSpace = -1;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //board = GameObject.FindGameObjectsWithTag("Space");
        IEnumerator e = Move(10);
        StartCoroutine(e);
    }

    public void Update()
    {
        IEnumerator e = Move(1);
        StartCoroutine(e);
    }

	public void TakeTurn()
    {
        // CheckItems();
        //int spaces = Die.RollDie();
    }

    public IEnumerator Move(int spaces)
    {
        for (int i = 0; i < spaces; i++)
        {
            print("hi");
            int index = currentSpace + 1;
            try
            {
                GameObject thing = board[index];
            }
            catch (IndexOutOfRangeException e)
            {
                index = 0;
            }
            print("hoi");
            yield return new WaitUntil(() => agent.remainingDistance <= agent.stoppingDistance && agent.pathStatus == NavMeshPathStatus.PathComplete);
            agent.SetDestination(board[index].transform.position);
            currentSpace = index;
            print("on space" + currentSpace);
            print("hoi did it work?");
            print("index is " + index);
        }
    }

    public IEnumerator MoveToSpace(GameObject space, int index)
    {
        print("hoi im temmie???");
        agent.SetDestination(space.transform.position);
        print("hoi im temmie");
        yield return new WaitUntil(() => agent.remainingDistance == 0 && agent.pathStatus == NavMeshPathStatus.PathComplete);
        currentSpace = index;
        print("on space" + currentSpace);
        // then interact with space

    }
}
