using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubesSpawner))]
public class CubeExploder: MonoBehaviour
{
    [SerializeField] private float _explodionPower = 7.5f;
    [SerializeField] private CubesSpawner _cubesSpawner;

    private List<Cube> _cubes = new List<Cube>();

    private void OnEnable()
    { 
        _cubesSpawner.CubeSpawned += AddCubeToList;
    }

    private void OnDisable()
    {
        _cubesSpawner.CubeSpawned -= AddCubeToList;
    }

    private void FixedUpdate()
    {
        if (_cubes.Count > 0)
        {
            foreach (Cube cube in _cubes)
            {
                ExplodeCube(cube);
            }

            _cubes.Clear();
        }
    }

    private void AddCubeToList(Cube cube)
    {
        _cubes.Add(cube);
    }

    private void ExplodeCube(Cube cube)
    {
        cube.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Random.onUnitSphere * _explodionPower, ForceMode.Impulse);
    }
}