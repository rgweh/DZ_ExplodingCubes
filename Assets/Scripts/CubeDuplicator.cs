using System.Collections.Generic;
using UnityEngine;

public class CubeDuplicator : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private int _minAmount = 2;
    [SerializeField] private int _maxAmount = 6;

    private void OnEnable()
    {
        _cube.TryDuplicateCube += OnTryDuplicateCube;
    }

    private void OnTryDuplicateCube(GameObject cubeObject)
    {
        Cube parentCube = cubeObject.GetComponent<Cube>();

        if (Random.Range(0, 100) <= parentCube.ActionChance)
        {
            int amount = Random.Range(_minAmount, _maxAmount);

            for (int i = 0; i < amount; i++)
            {
                Vector3 position = cubeObject.transform.position;
                GameObject newborn = Instantiate(cubeObject, position, Quaternion.identity);
                Cube newbornCube = newborn.GetComponent<Cube>();
                newbornCube.TryDuplicateCube += OnTryDuplicateCube;
            }
        }

        parentCube.TryDuplicateCube -= OnTryDuplicateCube;
    }
}
