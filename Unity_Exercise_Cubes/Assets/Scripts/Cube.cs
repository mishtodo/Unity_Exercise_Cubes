using UnityEngine;

public class Cube : MonoBehaviour
{
    public int DestroyCounts { get; private set; }

    public void InitializeDestroyCounts(int destroyCounts) 
    {
        DestroyCounts = destroyCounts;
    }
}