using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // The player score.
    // Can be read by other classes, but only set
    // using this one.
    public int score { get; private set; }

    // An array for the number sprites.
    public Sprite[] numSprites;

    // An array for the number images.
    public Image[] numImages;

    public void AddScore()
    {
        if (++score > 999)
        {
            score = 999;
        }
        DrawScore();
    }

    public void DrawScore()
    {
        // Separate the numbers into characters.
        // Reverse() will reverse the characters.
        // ToArray() will give back the characters as an array.
        char[] nums = score.ToString().ToCharArray().Reverse().ToArray();

        // Loop through the numbers and draw the sprite.
        for (int i = 0; i < numImages.Length; i++)
        {
            if (nums.Length > i)
            {
                // convert that character into an integer.
                int num = int.Parse(nums[i].ToString());

                // i - matches the image index for the score.
                // num - matches the sprite we should display.
                numImages[i].sprite = numSprites[num];
            }
        }
    }
}
