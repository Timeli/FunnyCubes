using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public class ObjectPoolService : IObjectPool
    {
        private readonly Queue<GameObject> _queue;

        public ObjectPoolService()
        {
            _queue = new();
        }

        public void Init(IGameFactory factory, int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                GameObject spawned = factory.CreateCube();
                spawned.SetActive(false);
                _queue.Enqueue(spawned);
            }
        }

        public GameObject GetNextItem()
        {
            GameObject item = _queue.Dequeue();
            _queue.Enqueue(item);
            item.SetActive(true);
            return item;
        }
    }
}
