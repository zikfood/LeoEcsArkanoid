using UnityEngine;

namespace UnityComponents.Common
{
    [CreateAssetMenu(menuName = "Config/StaticData", fileName = "StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        public GameObject PlayerPrefab;
        public GameObject ObstaclePrefab;
        public GameObject BulletPrefab;
        public GameObject GameOverZonePrefab;
        public GameObject BulletDestroyerPrefab;
        public Vector3 GlobalGravitation;
        public float SpawnTimer;
        public Vector3 PlayerAddForce;
        public Vector3[] EnemyMovements = { new Vector3(1,0,0), new Vector3(0,-1,0), new Vector3(-1,0,0)};
    }
}