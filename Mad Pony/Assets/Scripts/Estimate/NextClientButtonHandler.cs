using UnityEngine;
using UnityEngine.SceneManagement;

namespace Estimate
{
    public class NextClientButtonHandler : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Debug.Log("kek");
            SceneManager.UnloadScene(SceneManager.GetActiveScene());
        }
    }
}
