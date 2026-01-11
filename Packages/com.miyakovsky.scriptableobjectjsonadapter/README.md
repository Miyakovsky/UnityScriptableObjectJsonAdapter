# ScriptableObjectJsonAdapter

[日本語 ドキュメント](README_JP.md)

ScriptableObjectJsonAdapter is an Editor extension that lets you save and restore ScriptableObject instances to and from JSON files directly from the Inspector.

Features
- Save and restore `ScriptableObject` data as JSON files.
- Adds `Save to JSON` and `Load from JSON` buttons to the Inspector so the currently selected ScriptableObject can be exported to a file or overwritten from a file.

Usage
1. Create a class for your ScriptableObject.
2. Inherit from `ScriptableObjectJsonAdapter.SOJsonAdapter` (or use the provided `SOJsonAdapter` as a base).

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
- This package uses Unity's built-in `JsonUtility`. Complex types such as `Dictionary`, interfaces, or polymorphic fields may not serialize correctly. For those cases consider using a different serializer.
- After loading JSON, the editor marks the asset dirty and calls `AssetDatabase.SaveAssets()` to persist changes.

For quick verification: select a `ScriptableObject` asset in the Project window, then use the `JSON Utility` area in the Inspector to save or load JSON.

