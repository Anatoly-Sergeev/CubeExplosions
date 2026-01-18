using UnityEngine;

public class DividerCube
    : MonoBehaviour
{
    private const int MinCubesCount = 2;
    private const int MaxCubesCount = 6;

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

    private void DividingCubes(Collider selectedCube)
    {
        for (int i = GetRandomCubesCount(); i > 0; i--)
        {
            GameObject cube = _factory.CreateCube(selectedCube.transform);

            if (cube.TryGetComponent<Renderer>(out Renderer render))
                render.material.color = new(Random.value, Random.value, Random.value);

            cube.transform.localScale = selectedCube.transform.localScale / 2;
        }

        Destroy(selectedCube.gameObject);
    }

    private void ExplosionCube()
    {

    }

    private int GetRandomCubesCount()
    {
        return Random.Range(MinCubesCount, MaxCubesCount + 1);
    }
}
