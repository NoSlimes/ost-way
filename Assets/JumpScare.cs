using MilkShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScare : MonoBehaviour
{
    [SerializeField] private float target = 0f;
    [SerializeField] private float speed = 1.0f;

    private float chance = 0.15f;

    [SerializeField] private Image image;
    [SerializeField] private GameObject JumpScareBG;

    [SerializeField] private ShakePreset shakePreset;
    [SerializeField] private Shaker shaker;

    void Start()
    {
        JumpScareBG.SetActive(false);
    }

    public void StartJumpScare()
    {
        Debug.Log("tjenare");
        if(Random.Range(0f, 1f) <= chance)
        {
            StartCoroutine(JumpScareCoroutine());
        }
    }

    private IEnumerator JumpScareCoroutine()
    {
        image.color = Color.white;
        JumpScareBG.SetActive(true);
        shaker.Shake(shakePreset);

        if(AudioManager.instance)
            AudioManager.instance.Play("jumpScare");

        yield return new WaitForSeconds(speed);
        /*while(image.color.a > 0)
        {
            image.color = new Color(1f, 1f, 1f, Mathf.PingPong(Time.time * speed, target));
        }*/

        JumpScareBG.SetActive(false);
        yield return null;
    }
}
