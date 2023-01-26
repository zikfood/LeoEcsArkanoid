using Components.Common;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.Spawners
{
    public class GameOverZoneSpawner : IEcsInitSystem
    {
        private EcsWorld _world = null;
        private StaticData _staticData;
        private SceneData _sceneData;

        public void Init()
        {
            _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab
            {
                Prefab = _staticData.GameOverZonePrefab,
                Position = _sceneData.GameOverZonePosition,
                Rotation = Quaternion.identity,
                Parent = null
            };
        }
    }
}