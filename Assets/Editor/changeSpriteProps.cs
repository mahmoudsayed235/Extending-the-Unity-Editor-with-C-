using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class changeSpriteProps : EditorWindow
{
    private GameObject[] sprites;
    private bool changeColors = true;
    private float spriteScale = 1f;
    private string buttonString = "Get New Colors!";

    [MenuItem("Window/change Sprite Properties")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(changeSpriteProps));
    }
    private void OnGUI()
    {
        //Window Title 
        GUILayout.Label("Sprite Settings", EditorStyles.boldLabel);
        //get all gameobject with Sprite TAG
        sprites = GameObject.FindGameObjectsWithTag("Sprite");
        //change button title according to changeColors boolean
        if (changeColors)
            buttonString = "Get New Colors!";
        else
            buttonString = "Change Sprites to White!";
        //create Toggle to access changeColors boolean
        changeColors = EditorGUILayout.Toggle("Randomly Change Sprite Colors?", changeColors);
        //create Slider to access sprite's scale 

        spriteScale = EditorGUILayout.Slider("Sprite Scale", spriteScale, 1, 10);
        //change scale accroding to spriteScale
        foreach (GameObject sprite in sprites)
            sprite.transform.localScale = new Vector3(spriteScale, spriteScale, 0);

        //create button to change/reset color
        if (GUI.Button(new Rect(position.width / 2, position.height / 2, 180, 100), buttonString))
        {
            foreach (GameObject sprite in sprites)
            {
                if (changeColors)
                {
                    //change sprite's color to random color
                    float red, green, blue;
                    red = Random.Range(0.0f, 1.0f);
                    green = Random.Range(0.0f, 1.0f);
                    blue = Random.Range(0.0f, 1.0f);
                    sprite.GetComponent<SpriteRenderer>().color = new Color(red, green, blue, 1);
                }
                else
                {
                    //change sprite's color to white
                    sprite.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                }
            }
        }
    }
}
