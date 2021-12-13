using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); // 대사 리스트 생성
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);  // csv파일 가져옴
        
        string[] data = csvData.text.Split(new char[]{'\n'}); // 엔터 기준으로 값 한줄씩 읽어옴 data[0]은 인덱스 이름

        for(int i=1; i<data.Length;) // 1부터 시작
        {
            //Debug.Log(data[i]);

            string[] row = data[i].Split(new char[] { ',' }); // id 이름 대사가 배열에 들어감
            Dialogue dialogue = new Dialogue(); // 대사 리스트 생성

            dialogue.name = row[1];
            List<string> contextList = new List<string>(); // 대사 리스트
            List<string> eventList = new List<string>(); // 이벤트 번호 리스트 
            // 대사 개수만큼 반복문

            do
            {
                
                contextList.Add(row[2]);
                eventList.Add(row[3]);
                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                }
                else
                {
                    break;
                }
            } while (row[0].ToString() == "");

            dialogue.contexts = contextList.ToArray();
            dialogue.number = eventList.ToArray();
            dialogueList.Add(dialogue); // id별로 묶여서 세트로 대사가 저장됨
            

            
        }
        return dialogueList.ToArray(); // 다시 배열 형태로 변환 
    }

   
}
