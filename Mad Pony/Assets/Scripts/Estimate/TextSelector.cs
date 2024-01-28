using TMPro;
using UnityEngine;

namespace Estimate
{
    public class TextSelector : MonoBehaviour
    {
        private static readonly string[] _sadTexts =
        {
            "My tentacles feel violated, not rejuvenated, thanks.",
            "Your massage was a black hole of disappointment.",
            "I'd rather navigate asteroid fields than endure that again.",
            "My tentacles are filing a complaint with the cosmic council.",
            "Your touch left my tentacles in cosmic despair.",
            "I've had more relaxation from a malfunctioning warp drive.",
            "Even supernovas have more soothing vibes than your massage.",
            "Your massage skills belong in a black hole, abyssal!",
            "Did you learn your techniques from space debris, fool?",
            "My tentacles are furious at your cosmic incompetence!",
            "You call that a massage? My pet asteroid rubs better!",
            "I'd rather be sucked into a wormhole than endure your touch!",
            "Your hands are like cosmic sandpaper on my delicate tentacles!",
            "You've angered the stars with your pathetic attempt at massage!"
        };

        private static readonly string[] _middleTexts =
        {
            "My tentacles expected more cosmic bliss, honestly.",
            "Your massage was as thrilling as space dust.",
            "I've had better tentacle tickles from asteroids.",
            "My tentacles feel like they missed the cosmic memo.",
            "It was like my tentacles took a vacation... to Mars.",
            "Your massage was about as soothing as a supernova.",
            "My tentacles are still waiting for the real magic."
        };

        private static readonly string[] _goodTexts =
        {
            "Your touch sent cosmic ripples of joy through my tentacles!",
            "My tendrils are tingling with gratitude after that stellar massage!",
            "Thanks for the otherworldly relaxation! My tentacles adore you!",
            "I'm floating on stardust after your amazing massage!",
            "Your massage rocked my tentacled world!",
            "Blissful vibes! My tentacles salute your expertise!",
            "You've mastered the art of tentacular tranquility!",
            "Your touch unleashed cosmic calm upon my tendrils!",
            "Pure cosmic bliss! My tentacles are forever thankful!",
            "I'm in tentacle paradise thanks to your magical hands!",
            "My tentacles are doing the celestial cha-cha thanks to you, you cosmic masseur!",
            "Feels like my tentacles just won the lottery! Thanks for the cosmic rubdown!",
            "You've turned my tentacles into mush, in the best possible way! Bravo!",
            "My tentacles are writing you a thank-you note in tentacle hieroglyphs!",
            "You've got the magic touch! My tentacles are ready for round two!",
            "I'll be dreaming of your fingers on my tentacles tonight, in the most platonic way!",
            "You're a tentacle whisperer! My tendrils are singing your praises!",
            "If tentacles could purr, mine would be rumbling like a cosmic engine!",
            "My tentacles are feeling flirtier than a comet after your massage!",
            "You've tickled my tentacles pink, and I don't even have pink tentacles!"
        };

        private static readonly string[][] _allTexts =
        {
            _sadTexts,
            _middleTexts,
            _goodTexts
        };


        private TMP_Text textMeshPro;
        void Start()
        {
            textMeshPro = GetComponent<TMP_Text>();
        }

        public void SetHappiness(int happiness)
        {
            if (happiness >= 0 && happiness < _allTexts.Length)
            {
                var texts = _allTexts[happiness];
                var text = texts[Random.Range(0, texts.Length)];
                textMeshPro.text = text;
            }
        }
    }
}
