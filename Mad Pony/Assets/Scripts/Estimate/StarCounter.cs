using TMPro;
using UnityEngine;

namespace Estimate
{
    public class StarCounter : MonoBehaviour
    {
        private TMP_Text textMeshPro;
        void Start()
        {
            textMeshPro = GetComponent<TMP_Text>();
        }

        public void SetHappiness(int happiness)
        {
            textMeshPro.text = $"{happiness}";
        }
    }
}
