using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        //_transform.localScale = (transform.localScale / 2);
    }

    private void OnMouseDown()
    {
        for (int i = 0; i < Random.Range(2,6); i++)
        {
            GameObject NextCube = Instantiate(_cubePrefab);
        }

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        
    }
}
