using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Transform directionPoint;
    public float speed;
    public float destroyThreshold;

    
    private Vector3 _direction;
    
    private void Start()
    {
        var dir = directionPoint.position - this.transform.position;
        _direction = dir.normalized;
    }

    private void Update()
    {
        if (GameSceneManager.Instance.gameState == GameState.Intro)
        {
            return;
        }
        transform.Translate(_direction * (speed * Time.deltaTime));

        if (Vector3.Distance(transform.position, directionPoint.position) < destroyThreshold)
        {
            Destroy(gameObject);
        }
    }
}