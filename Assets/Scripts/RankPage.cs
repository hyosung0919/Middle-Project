using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;

public class RankPage : MonoBehaviour
{
    [SerializeField] Transform contentRoot;         // Content ������Ʈ
    [SerializeField] GameObject rowPrefab;          // RankRow ������

    StageResultList allData;

    void Awake()
    {
        allData = StageResultSaver.LoadRank();
        RefreshRankList(1);
    }
    public void RefreshRankList(int index)
    {
        //������ ��� �ڽ� ������Ʈ ����
        foreach (Transform child in contentRoot)
        {
            Destroy(child.gameObject);
        }

        //��ũ ������ ����
        var sortedData = allData.results.Where(r=>r.stage == index ).OrderByDescending(x=>x.score).ToList();

        for (int i = 0; i < sortedData.Count; i++)
        {
            GameObject row = Instantiate(rowPrefab, contentRoot);
            TMP_Text rankText = row.GetComponentInChildren<TMP_Text>();
            rankText.text = $"{index}. {sortedData[i].playername} - {sortedData[i].score}";
        }
    }
}
