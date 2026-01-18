using System.Collections.Generic;
using UnityEngine;

public class FactoryCube : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCube;

    public List<Rigidbody> CreateCubes(int count, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        List<Rigidbody> cubes = new();

        for (int i = 0; i < count; i++)
        {
            GameObject cube = Instantiate(_prefabCube, position, rotation);
            cube.transform.localScale = scale;

            if (cube.TryGetComponent<Renderer>(out Renderer render))
                render.material.color = new(Random.value, Random.value, Random.value);

            if (cube.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                cubes.Add(rigidbody);
        }

        return cubes;
    }
}
