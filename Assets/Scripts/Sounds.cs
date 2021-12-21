using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource goButton;
    public AudioSource backButton;
    public AudioSource grass;
    public AudioSource water1;
    public AudioSource water2;
    public AudioSource brick1;
    public AudioSource brick2;
    public AudioSource tile2;
    public AudioSource wood;
    public AudioSource tile;

    public void PlayGoButton(){
        goButton.Play();
    }

    public void PlayBackButton(){
        backButton.Play();
    }

    public void PlayGrass(){
        grass.Play();
    }

    public void PlayWater1(){
        water1.Play();
    }

    public void PlayWater2(){
        water2.Play();
    }

    public void PlayBrick1(){
        brick1.Play();
    }

    public void PlayBrick2(){
        brick2.Play();
    }

    public void PlayTile2(){
        tile2.Play();
    }

    public void PlayWood2(){
        wood.Play();
    }

    public void PlayTile(){
        tile.Play();
    }
}
