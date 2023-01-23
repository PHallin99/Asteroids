using GlobalConstants;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor
{
    public class GameConfigEditorWindow : EditorWindow
    {
        [SerializeField] private VisualTreeAsset m_VisualTreeAsset;

        public void CreateGUI()
        {
            // Each editor window contains a root VisualElement object
            var root = rootVisualElement;

            // VisualElements objects can contain other VisualElement following a tree hierarchy.
            VisualElement label = new Label("Asteroids Game Config Tool");
            root.Add(label);

            // Create a new field, disable it, and give it a style class.
            var majorAsteroidMovementSpeed = new Slider("Major Asteroid Movement Speed")
            {
                name = ConstantsHandler.UIMajorAsteroidMovementSpeedString,
                value = ConstantsHandler.MajorAsteroidMovementSpeed,
                showInputField = true
            };
            root.Add(majorAsteroidMovementSpeed);

            var mediumAsteroidMovementSpeed = new Slider("Medium Asteroid Movement Speed")
            {
                name = ConstantsHandler.UIMediumAsteroidMovementSpeedString,
                value = ConstantsHandler.MediumAsteroidMovementSpeed,
                showInputField = true
            };
            root.Add(mediumAsteroidMovementSpeed);

            var minorAsteroidMovementSpeed = new Slider("Minor Asteroid Movement Speed")
            {
                name = ConstantsHandler.UIMinorAsteroidMovementSpeedString,
                value = ConstantsHandler.MinorAsteroidMovementSpeed,
                showInputField = true
            };
            root.Add(minorAsteroidMovementSpeed);

            var protectionDuration = new Slider("Major Asteroid Movement Speed")
            {
                name = ConstantsHandler.UIProtectionDurationString,
                value = ConstantsHandler.ProtectedDuration,
                showInputField = true
            };
            root.Add(protectionDuration);

            var timeToSpawn = new Slider("Asteroid Spawn Interval")
            {
                name = ConstantsHandler.UITimeToSpawnString,
                showInputField = true,
                value = ConstantsHandler.TimeToSpawn,
                lowValue = 1
            };
            root.Add(timeToSpawn);

            var rotationSpeed = new Slider("Rotation Speed")
            {
                name = ConstantsHandler.UIRotationSpeedString,
                lowValue = 1,
                highValue = 300,
                value = ConstantsHandler.RotationSpeed,
                showInputField = true
            };
            root.Add(rotationSpeed);

            var thrustAmount = new Slider("Thrust Amount")
            {
                name = ConstantsHandler.UIThrustAmountString,
                value = ConstantsHandler.ThrustAmount,
                showInputField = true
            };
            root.Add(thrustAmount);

            var laserMovementSpeed = new Slider("Laser Movement Speed")
            {
                name = ConstantsHandler.UILaserMovementSpeedString,
                value = ConstantsHandler.LaserMovementSpeed,
                showInputField = true
            };
            root.Add(laserMovementSpeed);

            var shootCooldown = new Slider("Shooting Cooldown")
            {
                name = ConstantsHandler.UIShootCooldownString,
                value = ConstantsHandler.ShootCooldown,
                showInputField = true
            };
            root.Add(shootCooldown);

            var button = new Button
            {
                name = "ApplyButton",
                text = "Apply in Play Mode"
            };

            root.Add(button);
            SetupButtonHandler();
        }

        [MenuItem("Window/UI Toolkit/GameConfig")]
        public static void ShowExample()
        {
            var wnd = GetWindow<GameConfigEditorWindow>();
            wnd.titleContent = new GUIContent("GameConfig");
        }

        // Functions as event handlers for your button click
        private void SetupButtonHandler()
        {
            var root = rootVisualElement;

            var buttons = root.Query<Button>();
            buttons.ForEach(RegisterHandler);
        }

        private void RegisterHandler(Button button)
        {
            button.RegisterCallback<ClickEvent>(ApplyValues);
        }

        private void ApplyValues(ClickEvent evt)
        {
            var root = rootVisualElement;

            ConstantsHandler.MajorAsteroidMovementSpeed =
                root.Query<Slider>(ConstantsHandler.UIMajorAsteroidMovementSpeedString).First().value;
            ConstantsHandler.MediumAsteroidMovementSpeed =
                root.Query<Slider>(ConstantsHandler.UIMediumAsteroidMovementSpeedString).First().value;
            ConstantsHandler.MinorAsteroidMovementSpeed =
                root.Query<Slider>(ConstantsHandler.UIMinorAsteroidMovementSpeedString).First().value;
            ConstantsHandler.ProtectedDuration =
                root.Query<Slider>(ConstantsHandler.UIProtectionDurationString).First().value;
            ConstantsHandler.TimeToSpawn = root.Query<Slider>(ConstantsHandler.UITimeToSpawnString).First().value;
            ConstantsHandler.RotationSpeed = root.Query<Slider>(ConstantsHandler.UIRotationSpeedString).First().value;
            ConstantsHandler.ThrustAmount = root.Query<Slider>(ConstantsHandler.UIThrustAmountString).First().value;
            ConstantsHandler.LaserMovementSpeed =
                root.Query<Slider>(ConstantsHandler.UILaserMovementSpeedString).First().value;
            ConstantsHandler.ShootCooldown = root.Query<Slider>(ConstantsHandler.UIShootCooldownString).First().value;
        }
    }
}