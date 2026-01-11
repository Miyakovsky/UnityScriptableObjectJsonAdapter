using UnityEngine;

namespace ScriptableObjectJsonAdapter.Sample
{
    [CreateAssetMenu(fileName = "SampleSO", menuName = "Scriptable Objects/SampleSO")]
    public class SampleSO : SOJsonAdapter
    {
        public string objectName;
        public int value;
        public Vector3 position;
    }
}
