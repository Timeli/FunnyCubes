using UnityEngine;

namespace Services
{
    public interface IObjectPool
    {
        GameObject GetNextItem();
        void Init(ObjectForCreate type, int capacity);
    }
}
