using UnityEngine;

public class FactoryCube : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCube;

    public void CreateCubes(int count, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject cube = Instantiate(_prefabCube, position, rotation);
            cube.transform.localScale = scale;

            if (cube.TryGetComponent<Renderer>(out Renderer render))
                render.material.color = new(Random.value, Random.value, Random.value);
        }
    }
}
