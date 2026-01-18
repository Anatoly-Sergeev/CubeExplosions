using UnityEngine;

public class FactoryCube : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCube;

    public GameObject CreateCube(Transform transform)
    {
        return Instantiate(_prefabCube, transform.position, transform.rotation);
    }
}
