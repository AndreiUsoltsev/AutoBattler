using System;
using UnityEngine;

namespace CodeBase.Services.Assets
{
    public class Destoryable : MonoBehaviour
    {
        public event Action<GameObject> OnDestroy;

        public void Destroy()
            => OnDestroy?.Invoke(this.gameObject);
    }
}