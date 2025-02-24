using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CodeBase.Services.Assets
{
    public class AssetsLoader : IAssetsLoader
    {
        private readonly List<AsyncOperationHandle> _cachedAssets;

        public AssetsLoader() 
            => _cachedAssets = new List<AsyncOperationHandle>();

        public async Task<T> LoadAsset<T>(string assetName) where T : Object
        {
            AsyncOperationHandle<T> asyncOperationHandle = Addressables.LoadAssetAsync<T>(assetName);

            await asyncOperationHandle.Task;

            _cachedAssets.Add(asyncOperationHandle);

            return asyncOperationHandle.Result;
        }

        public void ReleaseAllCachedAssets()
        {
            foreach (AsyncOperationHandle asset in _cachedAssets)
            {
                Addressables.Release(asset);
            }
        }
    }
}