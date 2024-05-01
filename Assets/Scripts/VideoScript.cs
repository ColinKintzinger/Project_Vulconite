using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    private VideoPlayer video;

    //public IEnumerator WaitForMovieEnd()
    //{
    //    while (video.isPlaying)
    //    {
    //        yield return new WaitForEndOfFrame();

    //    }
    //    OnMovieEnded();
    //}

    //void OnMovieEnded()
    //{
    //    SceneManager.LoadScene("PreFirst");
    //}

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;


    }
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("PreFirst");//the scene that you want to load after the video has ended.
    }

}
