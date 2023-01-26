using UnityComponents.Factories;
using UnityEngine;
using Components.UnityComponents.UI;

namespace UnityComponents.Common
{
    public class SceneData : MonoBehaviour
    {
        public PrefabFactory Factory;

        public Vector3 GameOverZonePosition;
        public Vector3 BulletDetroyerPosition;
        
        public Transform SpawnEnemyPosition;
        public int EnemyAmountInLine;
        public int EnemyLinesAmount;
        public int DistanceBetweenEnemies;
        public int DistanceBetweenLines;
        
        public GameHud Hud;
    }
}