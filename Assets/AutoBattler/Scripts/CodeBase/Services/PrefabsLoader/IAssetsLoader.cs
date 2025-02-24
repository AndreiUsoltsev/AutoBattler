using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Services.Assets
{
    public interface IAssetsLoader
    {
        Task<T> LoadAsset<T>(string assetName) where T : Object;
        void ReleaseAllCachedAssets();
    }
}