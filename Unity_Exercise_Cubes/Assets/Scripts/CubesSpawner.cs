using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    private Cube SpawnSingleCube(Cube cube)
    {
        Cube nextCube;
        int localScaleMultyplier = 2;
        int nextDestroyCount = cube.DestroyCounts + 1;

        nextCube = Instantiate<Cube>(cube, cube.transform.localPosition, Quaternion.identity);
        nextCube.enabled = true;
        nextCube.transform.localScale = nextCube.transform.localScale / localScaleMultyplier;
        nextCube.InitializeDestroyCounts(nextDestroyCount);

        return nextCube;
    }

    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }

    public List<Cube> SpawnCubes(Cube cube)
    {
        List<Cube> newCubes = new List<Cube>();
        int minCubesAmount = 2;
        int maxCubesAmount = 6;

        for (int i = 0; i < Random.Range(minCubesAmount, maxCubesAmount + 1); i++)
        {
            newCubes.Add(SpawnSingleCube(cube));
        }

        return newCubes.ToList();
    }
}