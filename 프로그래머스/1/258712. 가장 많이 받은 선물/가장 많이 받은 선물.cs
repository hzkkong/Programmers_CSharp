using System;
using System.Collections.Generic;


public class Solution
{
    public int solution(string[] friends, string[] gifts)
    {
        int answer = 0;
        
        List<List<int>> listGiveAndTake = new List<List<int>>();
        List<List<int>> listGift = new List<List<int>>();
        Dictionary<string, int> dicFriends = new Dictionary<string, int>();
        for (int i = 0; i < friends.Length; i++)
        {
            dicFriends.Add(friends[i], i);
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            for (int j = 0; j < 3; j++)
            {
                list2.Add(0);
            }
            listGift.Add(list2);
            for (int j = 0; j < friends.Length; j++)
            {
                list1.Add(0);
            }
            listGiveAndTake.Add(list1);
        }

        for (int i = 0; i < gifts.Length; i++)
        {
            string[] s = gifts[i].Split(' ');
            int idx1 = dicFriends[s[0]];
            int idx2 = dicFriends[s[1]];
            listGiveAndTake[idx1][idx2]++;
            listGift[idx1][0]++;
            listGift[idx2][1]++;
        }

        for (int i = 0; i < listGift.Count; i++)
        {
            listGift[i][2] = listGift[i][0] - listGift[i][1];
        }

        for (int i = 0; i < listGiveAndTake.Count; i++)
        {
            int temp = 0;
            for (int j = 0; j < listGiveAndTake[i].Count; j++)
            {
                if (i == j) continue;
                int f1 = listGiveAndTake[i][j];
                int f2 = listGiveAndTake[j][i];
                if (f1 > f2)
                {
                    temp++;
                }
                else if (f1 == f2)
                {
                    if (listGift[i][2] > listGift[j][2])
                    {
                        temp++;
                    }
                }
            }
            if (temp > answer) answer = temp;
        }

        return answer;

    }
}
