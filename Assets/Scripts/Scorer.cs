﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(test());
        //Debug.Log("printed Start()");
    }
    IEnumerator test()
    {
        //Debug.Log("printed test()");
        yield return new WaitForSeconds(1);
        if (this.gameObject != null)
        {
            Score._instance.missed += 1;
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mosPos2D = new Vector2(mosPos.x, mosPos.y);

            RaycastHit2D hit = Physics2D.Raycast(mosPos2D, Vector2.zero);
            try
            {
                if (hit.collider.CompareTag("Player"))
                {
                    //Debug.Log(" not misses");
                    //clicked = true;
                    Score._instance.score += 10;
                    ParticleManager._instance.PlayBurst(mosPos2D);
                    Destroy(this.gameObject);
                }
                else
                {
                    //Debug.Log("misses");
                    Score._instance.missed += 1;
                }
            }
            catch
            {

            }
        }
       
    }
}
