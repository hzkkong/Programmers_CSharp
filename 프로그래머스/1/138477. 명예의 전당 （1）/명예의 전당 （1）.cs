using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Solution {
    public int[] solution(int k, int[] score) {
        int[] answer = new int[score.Length];
        List<int> rank = new List<int>();

        for(int i = 0; i < score.Length; i++)
        {
            if(rank.Count < k)
            {
                rank.Add(score[i]);
            }
            else
            {
                if(rank[0] < score[i])
                {
                    rank[0] = score[i];
                }
            }
            // 변경된 순위 리스트 오름차순!!!!!!
            rank.Sort();
            answer[i] = rank[0];
        }

        return answer;
    }
}