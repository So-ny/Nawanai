using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform {
    public int width;
    public int height;
    public int xPos;
    public int yPos;
    public GameObject g;

    public Platform(int x, int y, int w, int h) {
        width = w;
        height = h;
        xPos = x;
        yPos = y;
    }



}