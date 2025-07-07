using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeExploder: MonoBehaviour
{
    [SerializeField] private float _startExplodPower = 700.0f;
    [SerializeField] private float _startExplodRadius = 10.0f;
    [SerializeField] private float _forceSpawnedCubes = 7.5f;

    public void Explode(Cube cube)
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects(cube))
        {
            explodableObject.AddExplosionForce(_startExplodPower * cube.DivisionChance, cube.Transform.position, _startExplodRadius * cube.DivisionChance);
        }
    }

    public void ExplodeSpawnedCube(Rigidbody cubeRigedbody)
    {
        cubeRigedbody.AddRelativeForce(Random.onUnitSphere * _forceSpawnedCubes, ForceMode.Impulse);
    }

    private List<Rigidbody> GetExplodableObjects(Cube cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.Transform.position, _startExplodRadius * cube.DivisionChance);

        List<Rigidbody> Cubes = new();

        foreach (Collider hit in hits)
            if(hit.attachedRigidbody != null)
                Cubes.Add(hit.attachedRigidbody);

        return Cubes.ToList();
    }
}