using UnityEngine;

[RequireComponent(typeof(Transform),typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    public Transform Transform { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public int DivisionChance { get; private set; }

    private void Awake()
    {
        Transform = GetComponent<Transform>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void InitializeDestroyCounts(int divisionChance) 
    {
        DivisionChance = divisionChance;
    }

    public void InitializeTransformScale(Vector3 localScale)
    {
        Transform.localScale = localScale;
    }
}