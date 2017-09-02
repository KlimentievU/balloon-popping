using System.Collections;
using UnityEngine;

public class ClickOnBalloon : MonoBehaviour {

    public GameControl gameControl;

    void Start()
    {
        gameControl = GameObject.Find("Main Camera").GetComponent<GameControl>();
    }

    public void Click()
    {
        gameControl.score++;
        gameControl.textScore.text = gameControl.score.ToString();
        StartCoroutine(PlayParticles());
    }

    IEnumerator PlayParticles()
    {
        gameObject.GetComponent<ParticleSystem>().Stop();
        gameObject.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
