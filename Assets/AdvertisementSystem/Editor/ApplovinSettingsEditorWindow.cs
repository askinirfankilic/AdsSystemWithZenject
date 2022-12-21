using AdvertisementSystem.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace AdvertisementSystem.Editor
{
    public class ApplovinSettingsEditorWindow : UnityEditor.EditorWindow
    {
        private UnityEditor.Editor _applovinSettingsEditor;
        private ApplovinSettingsData _applovinSettingsData;

        [UnityEditor.MenuItem("Meditation Settings/Applovin Settings")]
        private static void ShowWindow()
        {
            var window = GetWindow<ApplovinSettingsEditorWindow>();
            window.titleContent = new GUIContent("Applovin Settings");
            window.Show();
        }

        private void OnEnable()
        {
            ScriptableObject obj =
                AssetDatabase.LoadAssetAtPath<ScriptableObject>("Assets/Resources/Meditation/ApplovinSDKData.asset");
            _applovinSettingsData = obj as ApplovinSettingsData;

            Assert.IsNotNull(_applovinSettingsData);

            _applovinSettingsEditor = UnityEditor.Editor.CreateEditor(_applovinSettingsData);
        }

        private void OnGUI()
        {
            _applovinSettingsEditor.OnInspectorGUI();
        }
    }
}