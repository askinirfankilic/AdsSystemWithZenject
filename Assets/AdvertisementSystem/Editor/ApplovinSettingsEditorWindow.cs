using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace AdvertisementSystem.Editor
{
    public class ApplovinSettingsEditorWindow : EditorWindow
    {
        private UnityEditor.Editor _applovinSettingsEditor;
        private ApplovinSettingsData _applovinSettingsData;

        [MenuItem("Meditation Settings/Applovin Settings")]
        private static void ShowWindow()
        {
            var window = GetWindow<ApplovinSettingsEditorWindow>();
            window.titleContent = new GUIContent("Applovin Settings");
            window.Show();
        }

        private void OnEnable()
        {
            _applovinSettingsData =
                AssetDatabase.LoadAssetAtPath<ScriptableObject>("Assets/Resources/Meditation/ApplovinSDKData.asset") as
                    ApplovinSettingsData;

            Assert.IsNotNull(_applovinSettingsData);

            _applovinSettingsEditor = UnityEditor.Editor.CreateEditor(_applovinSettingsData);
        }

        private void OnGUI()
        {
            _applovinSettingsEditor.OnInspectorGUI();
        }
    }
}