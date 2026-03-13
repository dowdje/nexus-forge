using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using NexusForge.Core;
using NexusForge.Character;
using NexusForge.Environment;

namespace NexusForge.Editor
{
    /// <summary>
    /// One-click scene and project setup accessible from the Unity menu bar.
    /// Creates Boot and Sandbox scenes with all required GameObjects so you can
    /// hit Play immediately after running the setup.
    /// </summary>
    public static class QuickStartSetup
    {
        private const string ScenesPath = "Assets/_Project/Scenes";
        private const string BootScenePath = ScenesPath + "/Boot.unity";
        private const string SandboxScenePath = ScenesPath + "/Sandbox.unity";

        [MenuItem("NexusForge/Quick Start Setup", priority = 0)]
        public static void RunFullSetup()
        {
            if (!EditorUtility.DisplayDialog(
                "Nexus Forge — Quick Start Setup",
                "This will create Boot and Sandbox scenes with starter GameObjects.\n\n" +
                "Existing scenes at those paths will be overwritten.\n\nContinue?",
                "Create Scenes", "Cancel"))
            {
                return;
            }

            EnsureDirectoryExists(ScenesPath);
            CreateSandboxScene();
            CreateBootScene();
            SetBuildSettings();

            // Open Boot scene so the user can press Play
            EditorSceneManager.OpenScene(BootScenePath, OpenSceneMode.Single);

            Debug.Log("[NexusForge] Quick Start Setup complete! Press Play to run.");
            EditorUtility.DisplayDialog(
                "Setup Complete",
                "Boot and Sandbox scenes created.\n\n" +
                "Press Play to start the game from Boot scene.\n\n" +
                "The Sandbox loads automatically with a ground plane, player capsule, " +
                "directional light, and day/night cycle.",
                "Got it");
        }

        [MenuItem("NexusForge/Create Boot Scene Only", priority = 10)]
        public static void CreateBootScene()
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            // ── Main Camera (Boot needs one for the loading screen) ──
            var camGo = new GameObject("Main Camera");
            camGo.tag = "MainCamera";
            var cam = camGo.AddComponent<Camera>();
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.backgroundColor = new Color(0.05f, 0.05f, 0.08f);
            camGo.transform.position = new Vector3(0, 1, -5);

            // ── Scene Bootstrapper ──
            var bootstrapper = new GameObject("SceneBootstrapper");
            bootstrapper.AddComponent<SceneBootstrapper>();

            EnsureDirectoryExists(ScenesPath);
            EditorSceneManager.SaveScene(scene, BootScenePath);
            Debug.Log($"[NexusForge] Created {BootScenePath}");
        }

        [MenuItem("NexusForge/Create Sandbox Scene Only", priority = 11)]
        public static void CreateSandboxScene()
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            // ── Directional Light (Sun) ──
            var sunGo = new GameObject("Sun");
            var sun = sunGo.AddComponent<Light>();
            sun.type = LightType.Directional;
            sun.color = new Color(1f, 0.96f, 0.84f);
            sun.intensity = 1.5f;
            sun.shadows = LightShadows.Soft;
            sunGo.transform.rotation = Quaternion.Euler(50f, -30f, 0f);

            // ── Day/Night Cycle ──
            var dayNightGo = new GameObject("DayNightCycle");
            var dayNight = dayNightGo.AddComponent<DayNightCycle>();
            // Assign the sun via serialized field
            var so = new SerializedObject(dayNight);
            so.FindProperty("_sunLight").objectReferenceValue = sun;
            so.FindProperty("_pauseCycle").boolValue = true; // Start paused so lighting is stable
            so.ApplyModifiedPropertiesWithoutUndo();

            // ── Ground Plane ──
            var ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ground.name = "Ground";
            ground.transform.position = Vector3.zero;
            ground.transform.localScale = new Vector3(100f, 0.5f, 100f);
            ground.isStatic = true;
            ground.layer = LayerMask.NameToLayer("Terrain");
            var groundRenderer = ground.GetComponent<Renderer>();
            if (groundRenderer != null)
                groundRenderer.sharedMaterial = CreateOrGetDefaultMaterial("Ground_Mat", new Color(0.45f, 0.55f, 0.35f));

            // ── Platforms for testing traversal ──
            CreatePlatform("Platform_1", new Vector3(5f, 1.5f, 5f), new Vector3(4f, 0.5f, 4f));
            CreatePlatform("Platform_2", new Vector3(10f, 3f, 5f), new Vector3(3f, 0.5f, 3f));
            CreatePlatform("Platform_3", new Vector3(15f, 5f, 5f), new Vector3(3f, 0.5f, 3f));
            CreateRamp("Ramp_1", new Vector3(0f, 0.75f, 8f), 25f);

            // ── Climbable Wall ──
            var wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall.name = "ClimbableWall";
            wall.transform.position = new Vector3(-8f, 4f, 0f);
            wall.transform.localScale = new Vector3(0.5f, 8f, 6f);
            wall.isStatic = true;
            wall.layer = LayerMask.NameToLayer("Climbable");
            var wallRenderer = wall.GetComponent<Renderer>();
            if (wallRenderer != null)
                wallRenderer.sharedMaterial = CreateOrGetDefaultMaterial("Wall_Mat", new Color(0.6f, 0.5f, 0.4f));

            // ── Player ──
            var player = CreatePlayerCapsule();
            player.transform.position = new Vector3(0f, 1.5f, 0f);

            // ── Main Camera ──
            var camGo = new GameObject("Main Camera");
            camGo.tag = "MainCamera";
            var cam = camGo.AddComponent<Camera>();
            cam.clearFlags = CameraClearFlags.Skybox;
            camGo.transform.position = new Vector3(0f, 3f, -6f);
            camGo.transform.LookAt(player.transform);

            EnsureDirectoryExists(ScenesPath);
            EditorSceneManager.SaveScene(scene, SandboxScenePath);
            Debug.Log($"[NexusForge] Created {SandboxScenePath}");
        }

        private static GameObject CreatePlayerCapsule()
        {
            var player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            player.name = "Player";
            player.tag = "Player";
            player.layer = LayerMask.NameToLayer("Player");

            // Remove the default collider — PlayerController RequireComponent will add CapsuleCollider
            Object.DestroyImmediate(player.GetComponent<CapsuleCollider>());

            // Add the player components (RequireComponent handles Rigidbody + CapsuleCollider)
            var controller = player.AddComponent<PlayerController>();

            // Configure the Rigidbody
            var rb = player.GetComponent<Rigidbody>();
            rb.mass = 70f;
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rb.constraints = RigidbodyConstraints.FreezeRotation;

            // Configure ground check layer mask to include Terrain (layer 11)
            var so = new SerializedObject(controller);
            var groundLayers = so.FindProperty("_groundLayers");
            groundLayers.intValue = 1 << LayerMask.NameToLayer("Terrain");
            so.ApplyModifiedPropertiesWithoutUndo();

            // Color the player
            var renderer = player.GetComponent<Renderer>();
            if (renderer != null)
                renderer.sharedMaterial = CreateOrGetDefaultMaterial("Player_Mat", new Color(0.2f, 0.6f, 0.9f));

            return player;
        }

        private static void CreatePlatform(string name, Vector3 position, Vector3 scale)
        {
            var platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
            platform.name = name;
            platform.transform.position = position;
            platform.transform.localScale = scale;
            platform.isStatic = true;
            platform.layer = LayerMask.NameToLayer("Terrain");
            var renderer = platform.GetComponent<Renderer>();
            if (renderer != null)
                renderer.sharedMaterial = CreateOrGetDefaultMaterial("Platform_Mat", new Color(0.65f, 0.65f, 0.7f));
        }

        private static void CreateRamp(string name, Vector3 position, float angle)
        {
            var ramp = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ramp.name = name;
            ramp.transform.position = position;
            ramp.transform.localScale = new Vector3(4f, 0.3f, 6f);
            ramp.transform.rotation = Quaternion.Euler(angle, 0f, 0f);
            ramp.isStatic = true;
            ramp.layer = LayerMask.NameToLayer("Terrain");
            var renderer = ramp.GetComponent<Renderer>();
            if (renderer != null)
                renderer.sharedMaterial = CreateOrGetDefaultMaterial("Platform_Mat", new Color(0.65f, 0.65f, 0.7f));
        }

        private static Material CreateOrGetDefaultMaterial(string name, Color color)
        {
            // Use the built-in Standard shader as a safe fallback
            // (HDRP Lit shader may not exist yet if HDRP hasn't finished importing)
            string matPath = $"Assets/_Project/Art/Materials/{name}.mat";
            var mat = AssetDatabase.LoadAssetAtPath<Material>(matPath);
            if (mat != null) return mat;

            // Try HDRP Lit first, fall back to Standard
            var shader = Shader.Find("HDRP/Lit") ?? Shader.Find("Standard");
            mat = new Material(shader) { color = color };

            EnsureDirectoryExists("Assets/_Project/Art/Materials");
            AssetDatabase.CreateAsset(mat, matPath);
            return mat;
        }

        private static void SetBuildSettings()
        {
            var scenes = new[]
            {
                new EditorBuildSettingsScene(BootScenePath, true),
                new EditorBuildSettingsScene(SandboxScenePath, true),
            };
            EditorBuildSettings.scenes = scenes;
            Debug.Log("[NexusForge] Build settings updated with Boot and Sandbox scenes.");
        }

        private static void EnsureDirectoryExists(string path)
        {
            if (!AssetDatabase.IsValidFolder(path))
            {
                var parts = path.Split('/');
                var current = parts[0];
                for (int i = 1; i < parts.Length; i++)
                {
                    var next = current + "/" + parts[i];
                    if (!AssetDatabase.IsValidFolder(next))
                        AssetDatabase.CreateFolder(current, parts[i]);
                    current = next;
                }
            }
        }
    }
}
