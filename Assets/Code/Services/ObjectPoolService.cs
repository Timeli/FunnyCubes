using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public class ObjectPoolService : IObjectPool
    {
        private readonly Queue<GameObject> _queue;
        private IGameFactory _gameFactory;

        public ObjectPoolService(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _queue = new();
        }

        public void Init(ObjectForCreate type, int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                GameObject spawned = _gameFactory.Create(type);
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
