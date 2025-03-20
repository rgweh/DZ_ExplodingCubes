using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explodeRadius;
    [SerializeField] private float _explodeForse;

    public void Explode(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            if(cube.TryGetComponent<Rigidbody>(out Rigidbody cubeRigidBody))
            {
                cubeRigidBody.AddExplosionForce(_explodeForse, cube.transform.position, _explodeRadius);
            }
        }
    }
}
