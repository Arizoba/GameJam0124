using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Memories : MonoBehaviour
{
    [SerializeField]
    private List<Image> memory1;
    [SerializeField]
    private List<Image> memory2;
    [SerializeField]
    private List<Image> memory3;

    private Canvas canvas;

    private List<Image> memory = null;
    private int index = 0;

    void Start() {
        canvas = GetComponent<Canvas>();
        foreach (Image memory in memory1) {
            memory.enabled = false;
        }
        foreach (Image memory in memory2) {
            memory.enabled = false;
        }
        foreach (Image memory in memory3) {
            memory.enabled = false;
        }
        canvas.enabled = false;
    }

    void PlayMemory() {
        if (memory != null && index < memory.Count) {
            if (Input.anyKeyDown){
                memory[index].enabled = false;
                index++;
                if (index == memory.Count) {
                    memory = null;
                    canvas.enabled = false;
                }
                else {
                    memory[index].enabled = true;
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
        memory[index].enabled = true;
    }

    void Update() {
        PlayMemory();
    }

}
