using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private CubeDestroyer _cubeDestroyer;

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
        for (int i = 0; i < Random.Range(2, 6); i++)
        {
            GameObject NextCube = Instantiate(gameObject);
            NextCube.transform.localScale = NextCube.transform.localScale / 2;
        }
    }

    private void CheckSpanwChanse()
    {

    }
}
