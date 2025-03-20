using NUnit.Framework;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private CubeDuplicator _cubeDuplicator;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Cube _cube;
    [SerializeField] private Vector3 _spawnpoint;

    public void Start()
    {
        Cube firstCube = Instantiate(_cube, _spawnpoint, Quaternion.identity);
        firstCube.Init();
        SubscribeTo(firstCube);
    }

    private void Duplicate(Cube cube)
    {
        _cubeDuplicator.Duplicate(cube);
        
        SubscribeToNewCubes();
    }

    private void Explode(Cube cube)
    {
        _exploder.Explode(_cubeDuplicator.GetLastDuplicated());

        UnsubscribeFrom(cube);
    }

    public void SubscribeTo(Cube cube)
    {
        cube.Duplicating += Duplicate;
        cube.Exploding += Explode;
    }
    
    public void UnsubscribeFrom(Cube cube)
    {
        cube.Duplicating -= Duplicate;
        cube.Exploding -= Explode;
    }

    private void SubscribeToNewCubes()
    {
        foreach (Cube duplicatedCube in _cubeDuplicator.GetLastDuplicated())
        {
            SubscribeTo(duplicatedCube);
        }
    }

}
