# UnityScriptableObjectJsonAdapter

[日本語 ドキュメント](README_JP.md)

ScriptableObjectJsonAdapter is a lightweight Editor extension package that lets you save and restore the contents of ScriptableObject instances to and from JSON files in the Unity Editor.

Features
- Adds `Save to JSON` / `Load from JSON` buttons to the Inspector so the selected `ScriptableObject` can be exported to a file or overwritten from a file.
- Uses Unity's built-in `JsonUtility` (no extra dependencies).

Installation

To load a UPM package from a Git URL:

1. Open the add "+" menu in the Package Manager’s toolbar.
2. Select "Add package from git URL" from the add menu. A text box and an Add button appear.
3. Enter a valid Git URL in the text box.
    ```text
    https://github.com/Miyakovsky/UnityScriptableObjectJsonAdapter.git?path=/Packages/com.miyakovsky.scriptableobjectjsonadapter
    ```

Usage (post-install)
1. Create a `ScriptableObject` class that inherits from `SOJsonAdapter` (example below).
2. Select the created ScriptableObject asset in the Unity Editor.
3. Use the `JSON Utility` section in the Inspector: press `Save to JSON` to export, `Load from JSON` to import. The editor will mark the asset dirty and call `AssetDatabase.SaveAssets()` after loading.

Example
```csharp
using UnityEngine;

[CreateAssetMenu(menuName = "Example/SampleSO")]
public class SampleSO : ScriptableObjectJsonAdapter.SOJsonAdapter
{
	public string message;
	public int value;
}
```

Notes
- `JsonUtility` has limitations: it does not serialize `Dictionary`, interfaces, or polymorphic fields correctly. For complex types consider using another serializer (e.g. Newtonsoft.Json).
- Always verify save/load behavior inside the Unity Editor.


