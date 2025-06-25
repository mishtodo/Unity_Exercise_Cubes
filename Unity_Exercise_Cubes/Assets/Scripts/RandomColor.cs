using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class RandomColor : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        Color randomColor = new Color(Random.value, Random.value, Random.value);

        _renderer.material.color = randomColor;     
    }
}