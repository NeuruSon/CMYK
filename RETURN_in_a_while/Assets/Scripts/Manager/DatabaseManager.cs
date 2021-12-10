using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;

    [SerializeField] string csv_Filename;

    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>(); // int 참조해서 그 줄만큼 꺼내오기 

    public static bool isFinish = false; // 데이터 파싱한걸 저장했느냐 안 했느냐

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DialogueParser theParser = GetComponent<DialogueParser>();
            Dialogue[] dialogues = theParser.Parse(csv_Filename);
            for(int i = 0; i<dialogues.Length; i++)
            {
                dialogueDic.Add(i + 1, dialogues[i]);
            }
            isFinish = true;
        }
    }
    public Dialogue[] GetDialogue(int _StartNum, int _EndNum)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();
        // 길이를 모를땐 리스트를 쓰자
        for(int i = 0; i<= _EndNum - _StartNum;i++) // 어디부터 어디까지 내용 꺼낼건지 
        {
            dialogueList.Add(dialogueDic[_StartNum + i]);
        }

        return dialogueList.ToArray(); 
    }

}
