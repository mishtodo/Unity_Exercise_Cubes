using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _destroyCounts;

    public void SetDestroyCounts(int destroyCounts) 
    {
        _destroyCounts = destroyCounts;
    }

    public int GetDestroyCounts()
    {
        return _destroyCounts;
    }
}