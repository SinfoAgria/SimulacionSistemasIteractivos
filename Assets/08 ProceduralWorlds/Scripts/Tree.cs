using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private const int INDEX_OF_SQUARE_CHILD = 0;
    private const int INDEX_OF_CIRCLE_CHILD = 1;

    [SerializeField] private GameObject branchPrefab;
    [SerializeField] private int totalLevels = 4;
    [SerializeField] private float initialSize = 5f;
    [SerializeField, Range(0f, 1f)] private float reductionPerLevel = 0.1f;

    private Queue<GameObject> rootBranchesQueue = new Queue<GameObject>();

    private int currentLevel = 1;

    void Start()
    {
        GameObject rootBranch = Instantiate(branchPrefab, transform);
        ChangeBranchSize(rootBranch, initialSize);
        rootBranchesQueue.Enqueue(rootBranch);
        GenerateTree();
    }

    void Update()
    {

    }

    private void GenerateTree()
    {
        if(currentLevel >= totalLevels)
        {
            return;
        }

        ++currentLevel;

        float newSize = Mathf.Max(initialSize - initialSize * reductionPerLevel * (currentLevel - 1), 0.1f);
        var branchesCreatedThisCycle = new List<GameObject>();

        while (rootBranchesQueue.Count >0)
        {
            var rootBranch = rootBranchesQueue.Dequeue();

            var leftBranch = CreateBranch(rootBranch, Random.Range(5f, 20f));
            var rigthBranch = CreateBranch(rootBranch, -Random.Range(5f, 20f));

            ChangeBranchSize(leftBranch, newSize);
            ChangeBranchSize(rigthBranch, newSize);

            branchesCreatedThisCycle.Add(leftBranch);
            branchesCreatedThisCycle.Add(rigthBranch);
        }

        foreach (var newBranches in branchesCreatedThisCycle)
        {
            rootBranchesQueue.Enqueue(newBranches);
        }

        GenerateTree();
    }

    private GameObject CreateBranch(GameObject prevBranch, float relativeAngle)
    {
        GameObject newBranch = Instantiate(branchPrefab, transform);
        newBranch.transform.localPosition = prevBranch.transform.localPosition + prevBranch.transform.up * GetBranchLength(prevBranch);
        newBranch.transform.localRotation = prevBranch.transform.localRotation * Quaternion.Euler(0, 0, relativeAngle);
        return newBranch;
    }

    private void ChangeBranchSize(GameObject branchInstance, float newSize)
    {
        var square = branchInstance.transform.GetChild(INDEX_OF_SQUARE_CHILD);
        var circle = branchInstance.transform.GetChild(INDEX_OF_CIRCLE_CHILD);

        var newScale = square.transform.localScale; newScale.y = newSize;
        square.transform.localScale = newScale;

        var newPosition = square.transform.localPosition; newPosition.y = newSize / 2f;
        square.transform.localPosition = newPosition;

        var newCiclePosition = circle.transform.localPosition; newCiclePosition.y = newSize;
        circle.transform.localPosition = newCiclePosition;
    }

    private float GetBranchLength(GameObject branchInstance)
    {
        return branchInstance.transform.GetChild(INDEX_OF_SQUARE_CHILD).localScale.y;
    }
}
