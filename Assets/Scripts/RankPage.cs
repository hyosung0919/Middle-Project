using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;

public class RankPage : MonoBehaviour
{
    [SerializeField] Transform contentRoot;         // Content 오브젝트
    [SerializeField] GameObject rowPrefab;          // RankRow 프리팹

    StageResultList allData;

    void Awake()
    {
        allData = StageResultSaver.LoadRank();
        RefreshRankList(1);
    }
    public void RefreshRankList(int index)
    {
        //기존의 모든 자식 오브젝트 삭제
        foreach (Transform child in contentRoot)
        {
            Destroy(child.gameObject);
        }

        //랭크 데이터 정렬
        var sortedData = allData.results.Where(r=>r.stage == index ).OrderByDescending(x=>x.score).ToList();

        for (int i = 0; i < sortedData.Count; i++)
        {
            GameObject row = Instantiate(rowPrefab, contentRoot);
            TMP_Text rankText = row.GetComponentInChildren<TMP_Text>();
            rankText.text = $"{index}. {sortedData[i].playername} - {sortedData[i].score}";
        }
    }
}
