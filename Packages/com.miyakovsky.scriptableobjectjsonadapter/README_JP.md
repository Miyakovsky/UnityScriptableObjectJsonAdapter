# ScriptableObjectJsonAdapter

ScriptableObjectJsonAdapterは、ScriptableObject を JSON で保存／復元するをInspectorで行えうエディタ拡張です。

主な特徴
- ScriptableObject を JSON で保存／復元する
- Inspector に「Save to JSON」「Load from JSON」ボタンを追加して、選択中の ScriptableObject の内容をファイルへ書き出したり、ファイルから上書きできます。


使い方
1. ScriptableObject 用のクラスを作成する
2. 作成したクラスにScriptableObjectJsonAdapter.SOJsonAdapter を継承する

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
注意事項
- このパッケージは Unity 組み込みの `JsonUtility` を使用します。`Dictionary`、インターフェース、ポリモーフィックフィールドなどの複雑な型は正しくシリアル化されない場合があります。そのような場合は、別のシリアライザーの使用を検討してください。
- JSON をロードした後、エディターはアセットをダーティとしてマークし、変更を永続化するために `AssetDatabase.SaveAssets()` を呼び出します。

簡単に確認するには、プロジェクトウィンドウで `ScriptableObject` アセットを選択し、インスペクターの `JSON Utility` 領域を使用して JSON を保存またはロードしてください。
