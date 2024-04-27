using UnityEngine;

public class DestroyOnPlaying : MonoBehaviour
{
    private bool _isDestroying;
    public float delay;
    private void Update()
    {
        if (_isDestroying) return;

        if (GameSceneManager.Instance.GameState == GameState.Playing)
        {
            _isDestroying = true;
            Destroy(this.gameObject, delay);
        }
    }
}