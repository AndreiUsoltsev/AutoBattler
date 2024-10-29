using UnityEngine;

public struct LocateResult
{
    public int Count;
    public Collider[] Colliders;

    public LocateResult(int count, Collider[] colliders)
    {
        Count = count;
        Colliders = colliders;
    }
}
