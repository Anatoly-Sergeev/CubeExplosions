using System.Collections.Generic;
using UnityEngine;

public class DividerCube
    : MonoBehaviour
{
    private const int MinCubesCount = 2;
    private const int MaxCubesCount = 6;
    private const int ScaleReductionFactor = 2;

    [SerializeField] private FactoryCube _factory;
    [SerializeField] private InputReader _input;
    [SerializeField] float _explosionForce;
    [SerializeField] float _explosionRadius;

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
        if (CanDividing(cube.transform.localScale.x))
            ExplosionCubes(cube.transform.position, _factory.CreateCubes(GetRandomCubesCount(), cube.transform.position, cube.transform.rotation, DecreaseCubeScale(cube.transform.localScale)));

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

    private void ExplosionCubes(Vector3 explosionPosition, List<Rigidbody> cubes)
    {
        foreach (Rigidbody cube in cubes)
            cube.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
    }

    private bool CanDividing(float chance)
    {
        return Random.value <= chance;
    }
}
