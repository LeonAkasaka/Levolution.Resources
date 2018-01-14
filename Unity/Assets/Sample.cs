using Levolution.Resources;
using Levolution.Resources.Unity;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Sample : MonoBehaviour {

    private IResourceProvider<string> _resourceProvider;

    private void Start()
    {
        _resourceProvider = new AssetsResourceProvider();
        CreateCube();
    }

    async Task CreateCube()
    {
        var prefab = await _resourceProvider.LoadOrDefault<string, GameObject>("Cube");
        var cube = Instantiate(prefab);
        cube.transform.parent = transform;
    }
}
