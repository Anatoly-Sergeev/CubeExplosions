using UnityEngine;

public class DividerCube
    : MonoBehaviour
{
    private const int MinCubesCount = 2;
    private const int MaxCubesCount = 6;
    private const int ScaleReductionFactor = 2;

    [SerializeField] private FactoryCube _factory;
    [SerializeField] private InputReader _input;

    private void OnEnable()
    {
        _input.ObjectSelected += DividingCubes;
    }

    private void OnDisable()
    {
        _input.ObjectSelected -= DividingCubes;
    }

    private void DividingCubes(Collider cube)
    {
        _factory.CreateCubes(GetRandomCubesCount(), cube.transform.position, cube.transform.rotation, DecreaseCubeScale(cube.transform.localScale));
        Destroy(cube.gameObject);
    }

    private int GetRandomCubesCount()
    {
        return Random.Range(MinCubesCount, MaxCubesCount + 1);
    }

    private Vector3 DecreaseCubeScale(Vector3 scale)
    {
        return scale / ScaleReductionFactor;
    }

    private void ExplosionCube()
    {

    }
}
