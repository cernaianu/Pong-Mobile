using UnityEngine;
using UnityEngine.EventSystems;

public class ScoreTrigger : MonoBehaviour
{
    public EventTrigger.TriggerEvent scoreTrigger;
    [SerializeField] private AudioSource scoreSfx;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallScript ball = collision.gameObject.GetComponent<BallScript>();

        if (ball != null)
        {
            scoreSfx.Play();
            this.scoreTrigger.Invoke(new BaseEventData(EventSystem.current));
        }
    }
}
