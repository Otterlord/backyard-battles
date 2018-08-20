using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour {
    public static int answer;
    public static void AskQuestion(MinigameManager m)
    {
        print(m.answers);
        int number1 = Random.Range(3, 13);
        int number2 = Random.Range(3, 13);
        int[] answersChoices = {answer + 1, (number1 - 1) * number2, answer, number1 + number2};
        answer = number1 * number2;

        m.questionObject.text = number1 + " x " + number2;

        foreach (GameObject a in m.answers) {
            a.GetComponent<Text>().text = answersChoices[Random.Range(0, 3)].ToString();
        }
    }
}
