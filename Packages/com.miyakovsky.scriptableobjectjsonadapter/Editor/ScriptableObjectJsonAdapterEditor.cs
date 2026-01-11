

namespace ScriptableObjectJsonAdapter.Editor
{

    using UnityEngine;
    using UnityEditor;
    using System.IO;
    using System;

    [CustomEditor(typeof(SOJsonAdapter), true)]
    public class ScriptableObjectJsonAdapterEditor : Editor
    {
        
        private Action _buttonAction = null;

        public override void OnInspectorGUI()
        {
            // デフォルトのInspectorを表示
            base.OnInspectorGUI();

            GUILayout.Space(10);
            GUILayout.Label("JSON Utility", EditorStyles.boldLabel);

            _buttonAction = null;

            using (new GUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();

                if (GUILayout.Button("Save to JSON"))
                {
                    _buttonAction = SaveJson;
                }

                if (GUILayout.Button("Load from JSON"))
                {
                    _buttonAction = LoadJson;
                }
            }
           
            _buttonAction?.Invoke();
        }

        /// <summary>
        /// Json形式に保存
        /// </summary>
        private void SaveJson()
        {
            var so = target as ScriptableObject;
            string json = JsonUtility.ToJson(so, true);

            string path = EditorUtility.SaveFilePanel(
                "Save JSON",
                Application.dataPath,
                so.name + ".json",
                "json"
            );

            if (!string.IsNullOrEmpty(path))
            {
                File.WriteAllText(path, json);
                DebugLog($"Saved JSON: {path}");
            }
        }

        /// <summary>
        /// Jsonを読み込む
        /// </summary>
        private void LoadJson()
        {
            var so = target as ScriptableObject;

            string path = EditorUtility.OpenFilePanel(
                "Load JSON",
                Application.dataPath,
                "json"
            );

            if (!string.IsNullOrEmpty(path))
            {
                string json = File.ReadAllText(path);
                JsonUtility.FromJsonOverwrite(json, so);

                EditorUtility.SetDirty(so);
                AssetDatabase.SaveAssets();

                DebugLog($"Loaded JSON: {path}");
            }
        }

        private void DebugLog(string log)
        {
            Debug.Log("[ScriptableObjectJsonAdapter] "+log);
        }
    }
}
