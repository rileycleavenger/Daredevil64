using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlatformReactor : MonoBehaviour
{
    [SerializeField] SpriteRenderer platformRim;    // The rim of the platform, showing its outlines
    [SerializeField] ParticleSystem particles;
    [SerializeField] ParticleSystem particles2;
    bool activeCoroutine = false;

    private void Start()
    {
        platformRim.color = Color.clear;
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("UWU");
        if (collision.gameObject.CompareTag("Player")) // !activeCoroutine && 
        {
            //StartCoroutine(DoParticleEffect());
            platformRim.color = Color.white;
            platformRim.color = new Color(platformRim.color.r, platformRim.color.g, platformRim.color.b, .5f);
            if (!activeCoroutine)
            {
                StartCoroutine(DoFadeEffect());
            }


        }
    }

    private void OnParticleCollision(GameObject other)
    {

        if (other.CompareTag("External Particles")) // !activeCoroutine && 
        {
            //StartCoroutine(DoParticleEffect());
            platformRim.color = Color.white;
            platformRim.color = new Color(platformRim.color.r, platformRim.color.g, platformRim.color.b, .5f);
            if (!activeCoroutine)
            {
                StartCoroutine(DoFadeEffect());
            }
            
        }
    }

    

    IEnumerator DoParticleEffect()
    {
        activeCoroutine = true;
        particles.Play();
        particles2.Play();
        yield return new WaitForSeconds(.2f);
        particles.Play();
        particles2.Play();
        yield return new WaitForSeconds(.2f);
        particles.Play();
        particles2.Play();
        yield return new WaitForSeconds(1f);
        activeCoroutine = false;
    }

    IEnumerator DoFadeEffect()
    {
        activeCoroutine = true;
        platformRim.color = Color.white;
        platformRim.color = new Color(platformRim.color.r, platformRim.color.g, platformRim.color.b, .5f);
        while (platformRim.color.a > 0)
        {
            float alpha = platformRim.color.a - .1f*Time.deltaTime;
            platformRim.color = new Color(platformRim.color.r, platformRim.color.g, platformRim.color.b, alpha);
            yield return null;
        }
        activeCoroutine = false;
    }
}