using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FellOff : MonoBehaviour
{
    public TotalCollectables howManyCollectables;
    public Text cubeCount;
    public AudioSource sourceOfAudio;
    public AudioClip collectableGet;
    public AudioClip goalGet;


    public void Start()
    {
        sourceOfAudio = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        howManyCollectables = FindObjectOfType<TotalCollectables>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -15)
        {
            transform.position = new Vector3(0, 5, 0);
        }  
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Collectable")
        {
            howManyCollectables.AddCollectables();
            cubeCount.text = howManyCollectables.collectables.ToString(); 
            Destroy(other.gameObject);
            if(howManyCollectables.collectables > 2)
            {
                sourceOfAudio.PlayOneShot(goalGet, 1f);
                GameObject goal = FindInActiveObjectByName("Goal");
                goal.SetActive(true);
            }
            else
            {
                sourceOfAudio.PlayOneShot(collectableGet, 1f);
            }
        }
    }
    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
