using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CodeBase.Services.Assets
{
    public class AddressablesPrefabsLoader : IPrefabsLoader
    {
        public async Task<T> InstantiatePrefab<T>(string prefabName, Transform parent = null) where T : Behaviour
        {
            AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.InstantiateAsync(prefabName, parent);

            await asyncOperationHandle.Task;

            T result;

            if(asyncOperationHandle.Result.TryGetComponent(out result) == false)
                throw new NullReferenceException();

            if(result.TryGetComponent(out Destoryable destoryable) == false)
                destoryable = result.gameObject.AddComponent<Destoryable>();

            destoryable.OnDestroy += DestroyInstance;

            return result;
        }

        private void DestroyInstance(GameObject gameObject) 
            => Addressables.ReleaseInstance(gameObject);
    }
}