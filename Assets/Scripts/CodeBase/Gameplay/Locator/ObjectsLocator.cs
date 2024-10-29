using System;
using UnityEngine;

public class ObjectsLocator : MonoBehaviour
{
    public event Action<LocateResult> OnLocated;

    [SerializeField] private float _radius = 10f;
    [SerializeField] private bool _isLocateEveryFrame = true;
    [SerializeField] private int _locateBufferSize = 10;

    private Collider[] _hittedColliders;

    private void Awake()
    {
        _hittedColliders = new Collider[_locateBufferSize];
    }

    private void Update()
    {
        if (_isLocateEveryFrame)
            Locate();
    }

    public LocateResult? Locate()
    {
        int hitsCount = Physics.OverlapSphereNonAlloc(this.transform.position, _radius, _hittedColliders);

        if (hitsCount == 0)
            return null;

        LocateResult locateResult = new LocateResult(hitsCount, _hittedColliders);

        OnLocated?.Invoke(locateResult);

        return locateResult;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, .5f, .5f, .25f);
        Gizmos.DrawSphere(transform.position, _radius);
        Gizmos.color = Color.white;
    }
}
