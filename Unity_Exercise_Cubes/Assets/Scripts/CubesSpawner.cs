using System;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;

    public event Action<Cube> CubeSpawned;

    private void OnEnable()
    {
        _raycaster.CubeHitted += SpawnCube;
    }

    private void OnDisable()
    {
        _raycaster.CubeHitted -= SpawnCube;
    }

    private void SpawnCube(Cube cube)
    {
        int minSpawnChanse = 0;
        int maxSpawnChanse = 100;

        int destroyCounts = cube.DestroyCounts;

        if (CalculateSpanwChanse(destroyCounts) >= UnityEngine.Random.Range(minSpawnChanse, maxSpawnChanse))
        {
            int minCubesAmount = 2;
            int maxCubesAmount = 6;
            int localScaleMultyplier = 2;

            destroyCounts++;

            for (int i = 0; i < UnityEngine.Random.Range(minCubesAmount, maxCubesAmount); i++)
            {
                Cube NextCube = Instantiate<Cube>(cube, cube.transform.localPosition, Quaternion.identity);

                NextCube.enabled = true;

                NextCube.transform.localScale = NextCube.transform.localScale / localScaleMultyplier;

                NextCube.InitializeDestroyCounts(destroyCounts);

                CubeSpawned?.Invoke(NextCube); 
            }
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