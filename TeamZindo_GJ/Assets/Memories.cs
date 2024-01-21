using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Memories : MonoBehaviour
{
    [SerializeField]
    private List<RectTransform> memory1;
    [SerializeField]
    private List<RectTransform> memory2;
    [SerializeField]
    private List<RectTransform> memory3;

    [SerializeField]
    private AudioSource memoryMusic;

    [SerializeField]
    private AudioSource mainMusic;

    private Canvas canvas;

    private List<RectTransform> memory = null;
    private int index = 0;

    void Start() {
        canvas = GetComponent<Canvas>();
        foreach (RectTransform memory in memory1) {
            memory.gameObject.SetActive(false);
        }
        foreach (RectTransform memory in memory2) {
            memory.gameObject.SetActive(false);
        }
        foreach (RectTransform memory in memory3) {
            memory.gameObject.SetActive(false);
        }
        canvas.enabled = false;
    }

    void PlayMemory() {
        if (memory != null && index < memory.Count) {
            if (Input.anyKeyDown){
                memory[index].gameObject.SetActive(false);
                index++;
                if (index == memory.Count) {
                    memory = null;
                    canvas.enabled = false;
                    memoryMusic.Stop();
                    mainMusic.Play();
                }
                else {
                    memory[index].gameObject.SetActive(true);
                }
            }
        }
    }

    public void StartMemory(int i) {
        if (i == 1) {
            memory = memory1;
        }
        if (i == 2) {
            memory = memory2;
        }
        if (i == 3) {
            memory = memory3;
        }
        canvas.enabled = true;
        index = 0;
        memory[index].gameObject.SetActive(true);
        mainMusic.Pause();
        memoryMusic.Play();
    }

    void Update() {
        PlayMemory();
    }

}
