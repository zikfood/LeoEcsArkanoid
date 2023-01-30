using Components.Common;
using Components.Common.Input;
using Components.Objects;
using Components.Objects.Tags;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.Spawners
{
    public class BulletSpawner : IEcsInitSystem
    {
        private StaticData _staticData;
        private SceneData _sceneData;
        private EcsWorld _world = null;
        private Position _spawnPosition;

        public void Init()
        {
            _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab
            {
                Prefab = _staticData.BulletPrefab,
                Position = Vector3.zero,
                Rotation = Quaternion.identity,
                Parent = null
            };
        }
    }
}