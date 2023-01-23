namespace GlobalConstants
{
    public static class ConstantsHandler
    {
        public static void InitializeValues(float majorAsteroidMovementSpeed, float mediumAsteroidMovementSpeed,
            float minorAsteroidMovementSpeed, float protectedDuration, float timeToSpawn, float laserMovementSpeed,
            float shootCooldown)
        {
            MajorAsteroidMovementSpeed = majorAsteroidMovementSpeed;
            MediumAsteroidMovementSpeed = mediumAsteroidMovementSpeed;
            MinorAsteroidMovementSpeed = minorAsteroidMovementSpeed;
            ProtectedDuration = protectedDuration;
            TimeToSpawn = timeToSpawn;
            LaserMovementSpeed = laserMovementSpeed;
            ShootCooldown = shootCooldown;
        }

        // PlayerPrefs
        public const string HighScoreKey = "HighScore";
        public const string LastGameKey = "LastGameScore";

        //SpaceShip
        public static float RotationSpeed = 150;
        public static float ThrustAmount = 5;
        
        // Tags
        public const string AsteroidTag = "Asteroid";
        public const string LaserTag = "Laser";

        // Asteroids
        public static float MajorAsteroidMovementSpeed = 1.5f;
        public static float MediumAsteroidMovementSpeed = 2f;
        public static float MinorAsteroidMovementSpeed = 2.5f;
        public static float ProtectedDuration = 0.75f;
        public static float TimeToSpawn = 5f;

        // Laser
        public static float LaserMovementSpeed = 6f;
        public static float ShootCooldown = 0.15f;
        
        // UI
        public const string UIMajorAsteroidMovementSpeedString = "MajorAsteroidMovementSpeed";
        public const string UIMediumAsteroidMovementSpeedString = "MediumAsteroidMovementSpeed";
        public const string UIMinorAsteroidMovementSpeedString = "MinorAsteroidMovementSpeed";
        public const string UIProtectionDurationString = "ProtectionDuration";
        public const string UITimeToSpawnString = "TimeToSpawn";
        public const string UILaserMovementSpeedString = "LaserMovementSpeed";
        public const string UIShootCooldownString = "ShootCooldown";
        public const string UIThrustAmountString = "ThrustAmount";
        public const string UIRotationSpeedString = "RotationSpeed";
    }
}