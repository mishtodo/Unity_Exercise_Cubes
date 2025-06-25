using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private int _destroyCounts;

    private void OnEnable()
    {
        _raycaster.RaycastHited += SpawnCube;
    }

    private void OnDisable()
    {
        _raycaster.RaycastHited -= SpawnCube;
    }

    private void SpawnCube(RaycastHit hit)
    {
        int minSpawnChanse = 0;
        int maxSpawnChanse = 100;

        Cube cube = hit.collider.gameObject.GetComponent<Cube>();

        _destroyCounts = cube.GetDestroyCounts();

        if (CalculateSpanwChanse(_destroyCounts) >= Random.Range(minSpawnChanse, maxSpawnChanse))
        {
            int minCubesAmount = 2;
            int maxCubesAmount = 6;
            int localScaleMultyplier = 2;

            _destroyCounts++;

            for (int i = 0; i < Random.Range(minCubesAmount, maxCubesAmount); i++)
            {
                GameObject NextCube = Instantiate(_cubePrefab, hit.collider.transform.localPosition, Quaternion.identity);

                for (int j = 0; j < _destroyCounts; j++)
                {
                    NextCube.transform.localScale = NextCube.transform.localScale / localScaleMultyplier;
                }  

                NextCube.GetComponent<Cube>().SetDestroyCounts(_destroyCounts);
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