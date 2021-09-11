using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager _instance;
    public ParticleSystem burstParticle;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlayBurst(Vector2 mosPos)
    {
        ParticleSystem bust = Instantiate(burstParticle, new Vector3(mosPos.x, mosPos.y, 0), Quaternion.identity);
        Destroy(bust.gameObject, 0.5f);
    }

}
