using UnityEngine;

public class CubeExploder: MonoBehaviour
{
    [SerializeField] private float _explodionPower = 7.5f;

    public void ExplodeCube(Rigidbody cubeRigedbody)
    {
        cubeRigedbody.AddRelativeForce(Random.onUnitSphere * _explodionPower, ForceMode.Impulse);
    }
}