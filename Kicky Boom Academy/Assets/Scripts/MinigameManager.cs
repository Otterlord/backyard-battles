using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour {

    public Text questionObject;
    public GameObject[] answers;

    public static int questions = 5;
    public static int questionsAnswered = 0;

    void Start()
    {
        QuestionManager.AskQuestion(this);
    }

    public static void OnFinish()
    {

    }
}
