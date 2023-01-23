using UnityEngine;

namespace EditorTools
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game Config", order = 0)]
    public class GameConfigScriptableObject : ScriptableObject
    {
        public float majorAsteroidMovementSpeed = 1.5f;
        public float mediumAsteroidMovementSpeed = 2f;
        public float minorAsteroidMovementSpeed = 2.5f;
        public float protectionDuration = 0.75f;
        public float timeToSpawn = 5f;
        public float laserMovementSpeed = 6f;
        public float shootCooldown = 0.15f;

        
        public void SetConstants(float majAstMoveSpeed, float medAstMoveSpeed, float minAstMoveSpeed,
            float protectDuration, float spawnInterval, float laserMoveSpeed, float shootCd)
        {
            majorAsteroidMovementSpeed = majAstMoveSpeed;
            mediumAsteroidMovementSpeed = medAstMoveSpeed;
            minorAsteroidMovementSpeed = minAstMoveSpeed;
            protectionDuration = protectDuration;
            timeToSpawn = spawnInterval;
            laserMovementSpeed = laserMoveSpeed;
            shootCooldown = shootCd;
        }
    }
}