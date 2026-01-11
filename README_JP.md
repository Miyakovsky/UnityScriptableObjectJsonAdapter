# UnityScriptableObjectJsonAdapter

ScriptableObjectJsonAdapter は、Unity Editor 上で ScriptableObject の内容を JSON ファイルとして保存・復元できる軽量なエディタ拡張パッケージです。

**特徴**
- Inspector に `Save to JSON` / `Load from JSON` ボタンを追加し、選択中の `ScriptableObject` をファイルへエクスポートしたり、ファイルから上書きできます。
- Unity 標準の `JsonUtility` を使用（追加依存なし）。

**インストール**

Git URL から UPM パッケージを追加する手順:

1. Unity の Package Manager を開き、ツールバーの `+` ボタンをクリックします。
2. 表示されるメニューから `Add package from git URL...` を選択します。
3. 入力欄に以下の Git URL を貼り付けて `Add` を押します。
	```text
	https://github.com/Miyakovsky/UnityScriptableObjectJsonAdapter.git?path=/Packages/com.miyakovsky.scriptableobjectjsonadapter
	```




**使い方（導入後）**
1. `SOJsonAdapter` を継承した `ScriptableObject` クラスを作成します（例は下記）。
2. Unity Editor で作成した ScriptableObject アセットを選択します。
3. Inspector の `JSON Utility` セクションで `Save to JSON` を押して保存、`Load from JSON` を押して読み込みます。

```csharp
using UnityEngine;

[CreateAssetMenu(menuName = "Example/SampleSO")]
public class SampleSO : ScriptableObjectJsonAdapter.SOJsonAdapter
{
	public string message;
	public int value;
}
```

**注意事項**
- `JsonUtility` は `Dictionary`、インターフェイス、ポリモーフィックなフィールドなど一部の型を正しくシリアライズできません。その場合は別のシリアライザの導入を検討してください。
- JSON 読み込み後は `EditorUtility.SetDirty` と `AssetDatabase.SaveAssets()` が呼ばれますが、動作確認は必ず Unity Editor 上で行ってください。


