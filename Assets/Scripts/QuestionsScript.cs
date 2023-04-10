using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class QuestionsScript : MonoBehaviour
{
    public int currentAnswerIndex = 0;
    private bool _isTrueAnswer;
    public DoorLockSystem dls = new DoorLockSystem();
    public bool isTrueAnswer
    {
        get { return _isTrueAnswer; }
        set { _isTrueAnswer = value; }
    }
    //Text
    [SerializeField] TMP_Text QuestionText;
    [SerializeField] TMP_Text AnswerAText;
    [SerializeField] TMP_Text AnswerBText;
    [SerializeField] TMP_Text AnswerCText;
    [SerializeField] TMP_Text AnswerDText;

    //Button
    [SerializeField] GameObject ButtonA;
    [SerializeField] GameObject ButtonB;
    [SerializeField] GameObject ButtonC;
    [SerializeField] GameObject ButtonD;

    //sorular
    [SerializeField] List<GameObject> buttons;

    //panel
    [SerializeField] GameObject questionsPanel;

    string Question0 = "Hýz deðiþkenimize dýþarýdan da eriþebilmek istiyorsak hýz deðiþkenimizin eriþim belirteci ne olmalýdýr?";
    string[] Answers0 = { "Public", "Private", "Protected", "Float"};

    string Question1 = "Execute Order'a göre doðru fonskiyon sýralamasý hangisi gibi olmalýdýr?";
    string[] Answers1 = { "FixedUpdate-Update-LateUpdate-Start", "Start-Update-FixedUpdate-LateUpdate", "Update-Start-FixedUpdate-LateUpdate", "Start-FixedUpdate-Update-LateUpdate" };

    string Question2 = "Çözdüðün problemi, nasýl çözdüðünü, kimin problemi olduðu, onlara nasýl ulaþtýðýný, maaliyetlerini anlatan tek sayfalýk iþ planýna ...... denir.";
    string[] Answers2 = { " Ýterasyon", "Landing Page", " Kanvas", "Pivot" };

    string Question3 = "Which of the word meanings in the reading text is incorrect?";
    string[] Answers3 = { "consumer : tüketici", "glimpse : gözatmak/görmek", "approach : uzak", "savvy : bilgili/bir alanda bilgili" };

    string Question4 = "Aþaðýdakilerden hangisi ‘’Kullanýcý Arayüzü’’ ikonlarý içinde yer almaz?";
    string[] Answers4 = { "Oyuncu envanter çantasý ikonu", "Oyun içi satýn alma ikonu", "Oyun içinde özel kullanýlan elmas ikonu", "Oyuncunun silahlarý" };

    string Question5 = "2D bir oyunda herhangi bir objenin hangi component'ine ulaþarak o objenin fiziksel hareketi saðlanabilir?";
    string[] Answers5 = { "Collider", "Rigidbody 2D", "Mesh Renderer", "AudioListener" };

    string Question6 = "Rigidbody kullanýlarak haraket ettirilmek istenen bir nesne için seçenekteki metodlardasn hangisini kullanmasý gereklidir ?";
    string[] Answers6 = { "Debug.Log()", "if()", "AddForce()", "Awake()" };

    string Question7 = "Aþaðýdakilerden hangisi GDPR’da yer alan kiþisel veri iþlemeye iliþkin ilkelerden biri deðildir?";
    string[] Answers7 = { "Data minimisation", "Purpose limitation", "Accountability", "Independency" };

    int[] correctAnswer = { 0, 3, 2, 2, 3, 1, 2, 3};

    

    public List<Questions> questionList;
    private void Awake()
    {
        isTrueAnswer = false;

        questionList = new List<Questions>();
        Questions ques0 = new Questions(Question0, Answers0);
        Questions ques1 = new Questions(Question1, Answers1);
        Questions ques2 = new Questions(Question2, Answers2);
        Questions ques3 = new Questions(Question3, Answers3);
        Questions ques4 = new Questions(Question4, Answers4);
        Questions ques5 = new Questions(Question5, Answers5);
        Questions ques6 = new Questions(Question6, Answers6);
        Questions ques7 = new Questions(Question7, Answers7);

        questionList.Add(ques0);
        questionList.Add(ques1);
        questionList.Add(ques2);
        questionList.Add(ques3);
        questionList.Add(ques4);
        questionList.Add(ques5);
        questionList.Add(ques6);
        questionList.Add(ques7);

        //GetQuestion();
    }
    public void GetQuestion()
    {
        QuestionText.SetText(questionList[currentAnswerIndex].Soru);
        AnswerAText.SetText(questionList[currentAnswerIndex].Cevaplar[0]);
        AnswerBText.SetText(questionList[currentAnswerIndex].Cevaplar[1]);
        AnswerCText.SetText(questionList[currentAnswerIndex].Cevaplar[2]);
        AnswerDText.SetText(questionList[currentAnswerIndex].Cevaplar[3]);
    }

    private void Update()
    {
        GetQuestion();

        if(currentAnswerIndex >= 7)
        {
            Debug.Log("Bütün Sorular Çzöüldü");
        }
    }
    public void TrueAnswer()
    {
        currentAnswerIndex++;
    }

    public void Button_A()
    {
        if (correctAnswer[currentAnswerIndex] == 0)
        {
            isTrueAnswer = true;
            dls.lockScore++;
            questionsPanel.SetActive(false);
            
            TrueAnswer();
        }
        else
        {
        }
    }
    public void Button_B()
    {
        if (correctAnswer[currentAnswerIndex] == 1)
        {
            isTrueAnswer = true;
            dls.lockScore++;
            questionsPanel.SetActive(false);
           
            TrueAnswer();
        }
        else
        {
            Debug.Log("Yanlýþ cevap");
        }
    }
    public void Button_C()
    {
        if (correctAnswer[currentAnswerIndex] == 2)
        {
            isTrueAnswer = true;
            dls.lockScore++;
            Debug.Log("Doðru cevap");
            questionsPanel.SetActive(false);
            
            TrueAnswer();
        }
        else
        {
            Debug.Log("Yanlýþ cevap");
        }
    }
    public void Button_D()
    {
        if (correctAnswer[currentAnswerIndex] == 3)
        {
            Debug.Log("Doðru cevap");
            dls.lockScore++;
            questionsPanel.SetActive(false);
            isTrueAnswer = true;
            TrueAnswer();
        }
        else
        {
            Debug.Log("Yanlýþ cevap");
        }
    }
    public void FalseAnswer()
    {

    }
}

public class Questions
{
    string soru;
    string[] cevaplar;

    public Questions(string soru, string[] cevaplar)
    {
        this.soru = soru;
        this.cevaplar = cevaplar;
    }

    public string Soru
    {
        get { return soru; }
        set { soru = value; }
    }

    public string[] Cevaplar
    {
        get { return cevaplar; }
        set { cevaplar = value; }
    }
}
