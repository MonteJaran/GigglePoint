using UnityEngine;
using UnityEngine.UI;

namespace Estimate
{
    public class EmotionImageSelector : MonoBehaviour
    {
        public Sprite[] badSprites;
        public Sprite[] middleSprites;
        public Sprite[] goodSprites;

        private Image image;
        private Sprite[][] allSprites;

        void Start()
        {
            image = GetComponent<Image>();
            allSprites = new[]
            {
                badSprites,
                middleSprites,
                goodSprites
            };
        }

        public void SetHappiness(int happiness)
        {
            if (happiness >= 0 && happiness < allSprites.Length)
            {
                var sprites = allSprites[happiness];
                var sprite = sprites[Random.Range(0, sprites.Length)];
                image.sprite = sprite;
            }
        }
    }
}
