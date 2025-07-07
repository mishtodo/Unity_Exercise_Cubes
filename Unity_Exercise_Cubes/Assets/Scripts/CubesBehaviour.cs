using System.Collections.Generic;
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

        if (CalculateSpanwChanse(cube.DivisionChance) >= Random.Range(minSpawnChanse, maxSpawnChanse))
        {
            _cubesSpawner.SpawnCubes(cube);
        }
        else
        {
            ExplodeCube(cube);
        }
    }

    private void ExplodeCube(Cube cube)
    {
        _cubeExploder.Explode(cube);
    }

    private int CalculateSpanwChanse(int divisionChance)
    {
        int spanwChanse = 100;
        int spawnDeacreseMultyplier = 2;

        for (int i = 0; i < divisionChance; i++)
        {
            spanwChanse /= spawnDeacreseMultyplier;
        }

        return spanwChanse;
    }
}