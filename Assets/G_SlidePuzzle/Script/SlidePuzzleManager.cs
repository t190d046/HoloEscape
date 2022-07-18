using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlideDirection
{
    NotSlide,
    top,
    left,
    right,
    bottom
}
public class SlidePuzzleManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    AudioSource audioSource;
    [SerializeField] AudioClip sound;
    [SerializeField] SlidePuzzlePanel[] slidePuzzlePanels;
    //panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9;
    [SerializeField] GameObject inItem;
    public bool canSlide = true;
    public int[,] panelArray = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

    bool complete = false;
    private void OnEnable()
    {
        init();
        audioSource = GetComponent<AudioSource>();
    }
    public void init()
    {
        complete = false;
        canSlide = true;
        panelArray = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        shufflePanel();
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                slidePuzzlePanels[panelArray[r, c] - 1].SetPosition(r, c);
                slidePuzzlePanels[panelArray[r, c] - 1].SetRowColumn(r, c);
            }
        }
    }

    void shufflePanel()
    {
        int row = 2, col = 2;
        SlideDirection[] canSlideDirections = new SlideDirection[4];
        for (int i = 0; i < 100; i++)
        {
            int len = 0;
            if (row - 1 >= 0)
            {
                canSlideDirections[len] = SlideDirection.top;
                len++;
            }
            if (row + 1 <= 2)
            {
                canSlideDirections[len] = SlideDirection.bottom;
                len++;
            }
            if (col - 1 >= 0)
            {
                canSlideDirections[len] = SlideDirection.left;
                len++;
            }
            if (col + 1 <= 2)
            {
                canSlideDirections[len] = SlideDirection.right;
                len++;
            }

            int rnd = Random.Range(0, len);
            //Debug.Log("len" + len + "rnd" + rnd);

            switch (canSlideDirections[rnd])
            {
                case SlideDirection.top:
                    SwapPanel(row - 1, col, row, col);
                    row = row - 1;
                    break;
                case SlideDirection.bottom:
                    SwapPanel(row + 1, col, row, col);
                    row = row + 1;
                    break;
                case SlideDirection.left:
                    SwapPanel(row, col - 1, row, col);
                    col = col - 1;
                    break;
                case SlideDirection.right:
                    SwapPanel(row, col + 1, row, col);
                    col = col + 1;
                    break;
            }

        }
    }
    
    public void PuzzleCompleteCheck()
    {
        int num = 1;
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                Debug.Log("Check" + panelArray[r, c] + num);
                if (panelArray[r, c] != num)
                {
                    canSlide = true;
                    return;
                }
                num++;
            }
        }
        inItem.SetActive(true);
        StartCoroutine(OpenCoroutine());
        complete = true;
        canSlide = false;
        gameManager.isClearSlidePuzzle = true;
    }

    public void SwapPanel(int r, int c, int nr, int nc)
    {
        int temp = panelArray[r, c];
        panelArray[r, c] = 9;
        slidePuzzlePanels[8].SetRowColumn(r, c);
        panelArray[nr, nc] = temp;
    }

    public SlideDirection CheckAdjacent(int r, int c)
    {
        int temp;
        if (r - 1 >= 0)
        {
            temp = panelArray[r - 1, c];
            if (temp == 9)
            {
                canSlide = false;
                SwapPanel(r, c, r - 1, c);
                return SlideDirection.top;
            }
        }
        if (r + 1 <= 2)
        {
            temp = panelArray[r + 1, c];
            if (temp == 9)
            {
                canSlide = false;
                SwapPanel(r, c, r + 1, c);
                return SlideDirection.bottom;
            }
        }
        if (c - 1 >= 0)
        {
            temp = panelArray[r, c - 1];
            if (temp == 9)
            {
                canSlide = false;
                SwapPanel(r, c, r, c - 1);
                return SlideDirection.left;
            }
        }
        if (c + 1 <= 2)
        {
            temp = panelArray[r, c + 1];
            if (temp == 9)
            {
                canSlide = false;
                SwapPanel(r, c, r, c + 1);
                return SlideDirection.right;
            }
        }
        return SlideDirection.NotSlide;
    }


    IEnumerator OpenCoroutine()
    {
        audioSource.PlayOneShot(sound);
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            transform.Translate(0, 0.04f, 0);
        }
        Debug.Log(transform.localPosition);
    }
}
