using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject branchPrefab;
    [SerializeField] private int totalLevels = 4;
    private Queue<GameObject> rootBranchesQueue = new Queue<GameObject>();

    private int currentLevel = 1;

    void Start()
    {
        GameObject rootBranch = Instantiate(branchPrefab, transform);
        rootBranchesQueue.Enqueue(rootBranch);
        GenerateTree(rootBranch);
    }

    void Update()
    {

    }

    private void GenerateTree(GameObject rootBranch)
    {
        if(currentLevel >= totalLevels)
        {
            return;
        }

        ++currentLevel;

        while (rootBranchesQueue.Count >0)
        {
            //var rootBranch = rootBranchesQueue.Dequeue();

            var leftBranch = CreateBranch(rootBranch, 45f);
            var rigthBranch = CreateBranch(rootBranch, -45f);
        }

       // GenerateTree(leftBranch);
        //GenerateTree(rigthBranch);
    }

    private GameObject CreateBranch(GameObject prevBranch, float relativeAngle)
    {
        GameObject newBranch = Instantiate(branchPrefab, transform);
        newBranch.transform.localPosition = prevBranch.transform.localPosition + prevBranch.transform.up;
        newBranch.transform.localRotation = prevBranch.transform.localRotation * Quaternion.Euler(0, 0, relativeAngle);
        return newBranch;
    }

    /*private void PrintNumbers(int number)
    {
        if(number <= 10)
        {
            PrintNumbers(number + 1);
        }
    }*/
}
