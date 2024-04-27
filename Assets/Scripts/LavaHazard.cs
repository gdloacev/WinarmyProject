using UnityEngine;

public class LavaHazard : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    
    void Update()
    {
        if (GameSceneManager.Instance.GameState == GameState.Playing)
        {
            this.transform.Translate(direction * (speed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ded");
    }
}
