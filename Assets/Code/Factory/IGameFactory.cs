using UnityEngine;

namespace Services
{
    public interface IGameFactory
    {
        GameObject Create(ObjectForCreate obj);
    }
}