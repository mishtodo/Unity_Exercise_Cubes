using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private CubeDestroyer _cubeDestroyer;
    [SerializeField] private int _destroyIteration;

    private void Awake()
    {
        _cubeDestroyer = GetComponent<CubeDestroyer>();
    }

    private void OnEnable()
    {
        _cubeDestroyer.Destroying += SpawnCube;
    }

    private void OnDisable()
    {
        _cubeDestroyer.Destroying -= SpawnCube;
    }

    private void SpawnCube()
    {
        int minSpawnChanse = 0;
        int maxSpawnChanse = 100;

        if (CalculateSpanwChanse(_destroyIteration) >= Random.Range(minSpawnChanse, maxSpawnChanse))
        {
            _destroyIteration++;

            for (int i = 0; i < Random.Range(2, 6); i++)
            {
                GameObject NextCube = Instantiate(gameObject);
                NextCube.transform.localScale = NextCube.transform.localScale / 2;
            }
        }
    }

    private int CalculateSpanwChanse(int destroyIteration)
    {
        int spanwChanse = 100;

        for (int i = 0; i < destroyIteration; i++)
        {
            spanwChanse /= 2;
        }

        return spanwChanse;
    }
}
