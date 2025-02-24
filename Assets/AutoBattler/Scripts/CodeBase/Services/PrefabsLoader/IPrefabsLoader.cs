using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Services.Assets
{
    public interface IPrefabsLoader 
    {
        Task<T> InstantiatePrefab<T>(string prefabName, Transform parent = null) where T : Behaviour;
    }
}