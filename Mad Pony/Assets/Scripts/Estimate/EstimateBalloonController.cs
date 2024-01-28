using UnityEngine;

namespace Estimate
{
    public class EstimateBalloonController : MonoBehaviour
    {
        private EmotionImageSelector emotionSelector;
        private StarCounter starCounter;
        private TextSelector textSelector;

        private void Start()
        {
            emotionSelector = GetComponentInChildren<EmotionImageSelector>();
            starCounter = GetComponentInChildren<StarCounter>();
            textSelector = GetComponentInChildren<TextSelector>();
        }

        // TODO: call when scene is created. Happiness must be 0...9
        public void SetHappiness(int happiness)
        {
            int happinessLevel = happiness switch
            {
                > 6 => 2,
                > 3 => 1,
                _ => 0
            };

            emotionSelector.SetHappiness(happinessLevel);
            textSelector.SetHappiness(happinessLevel);
            starCounter.SetHappiness(happiness);
        }
    }
}
