using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CubesSpawner), typeof(CubeExploder))]
public class CubesBehaviour : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private CubesSpawner _cubesSpawner;
    [SerializeField] private CubeExploder _cubeExploder;

    private void OnEnable()
    {
        _raycaster.CubeHitted += SpawnNextCubes;
    }

    private void OnDisable()
    {
        _raycaster.CubeHitted -= SpawnNextCubes;
    }

    private void SpawnNextCubes(Cube cube)
    {
        _cubesSpawner.DestroyCube(cube);

        int minSpawnChanse = 0;
        int maxSpawnChanse = 100;

        if (CalculateSpanwChanse(cube.DestroyCounts) >= Random.Range(minSpawnChanse, maxSpawnChanse))
        {
            List<Cube> newCubes = _cubesSpawner.SpawnCubes(cube);
            ExplodeCubes(newCubes.ToList());
        }
    }

    private void ExplodeCubes(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            _cubeExploder.ExplodeCube(cube);
        }
    }

    private int CalculateSpanwChanse(int destroyIteration)
    {
        int spanwChanse = 100;
        int spawnDeacreseMultyplier = 2;

        for (int i = 0; i < destroyIteration; i++)
        {
            spanwChanse /= spawnDeacreseMultyplier;
        }

        return spanwChanse;
    }
}