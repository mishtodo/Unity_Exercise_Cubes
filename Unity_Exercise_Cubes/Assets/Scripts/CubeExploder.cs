using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeExploder: MonoBehaviour
{
    [SerializeField] private float _startExplodionPower = 700;
    [SerializeField] private float _startExplodionRadius = 20;

    public void Explode(Cube cube)
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects(cube))
        {
            explodableObject.AddExplosionForce(_startExplodionPower * cube.DivisionChance, cube.Transform.position, _startExplodionRadius * cube.DivisionChance);
        }
    }

    private List<Rigidbody> GetExplodableObjects(Cube cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.Transform.position, _startExplodionRadius * cube.DivisionChance);

        List<Rigidbody> Cubes = new();

        foreach (Collider hit in hits)
            if(hit.attachedRigidbody != null)
                Cubes.Add(hit.attachedRigidbody);

        return Cubes.ToList();
    }
}