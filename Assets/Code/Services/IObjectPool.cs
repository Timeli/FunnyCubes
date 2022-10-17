using UnityEngine;

namespace Services
{
    public interface IObjectPool
    {
        GameObject GetNextItem();
        void Init(IGameFactory factory, int capacity);
    }
}
