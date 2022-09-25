namespace algorithms.dp;

class LongestSubsequence
{
    // __ _ _         ___ _
    // ABCEXFA  and  XABEYFB  has longest subsequence ABEF

    //
    //     A  B  C  E  X  F  A
    //  X  0  0  0  0 ↖1 ⇠1 ⇠1         ↖  => on char match add 1 to max subsequence from substrings till match
    //  A ↖1 ⇠1 ⇠1 ⇠1 ⇠1 ⇠1 ↖2               eg - 'ABCE' and 'XABE'
    //  B ⇡1 ↖2 ⇠2 ⇠2 ⇠2 ⇠2 ⇠2                    on 'E' match +1 to max subseq. length of 'ABC' and 'XAB'
    //  E ⇡1 ⇡2 ⇠2 ↖3 ⇠3 ⇠3 ⇠3
    //  Y ⇡1 ⇡2 ⇠2 ⇡3 ⇠3 ⇠3 ⇠3       ⇠  ⇡ => carry the max subsequence length (when there's no char match)
    //  F ⇡1 ⇡2 ⇠2 ⇡3 ⇠3 ↖4 ⇠4
    //  B ⇡1 ↖2 ⇠2 ⇡3 ⇠3 ⇡4 ⇠4
    //
    // (at any position in the table will have max subsequnce length and a map to the subsequence)

    public string longestsubsequence(string str1, string str2)
    {
        char[,] mapArr = new char[str1.Length + 1, str2.Length + 1];
        int[,] lengthArr = new int[str1.Length + 1, str2.Length + 1];

        for(int i = 0; i < str2.Length; i++)
        {
            for(int j = 0; j < str1.Length; j++)
            {
                if(str1[j] == str2[i])
                {
                    lengthArr[j+1, i+1] = lengthArr[j, i] + 1;
                    mapArr[j+1, i+1] = '↖';
                }
                else
                {
                    if(lengthArr[j, i+1] > lengthArr[j+1, i])
                    {
                        lengthArr[j+1, i+1] = lengthArr[j, i+1];
                        mapArr[j+1, i+1] = '⇡';
                    }
                    else
                    {
                        lengthArr[j+1, i+1] = lengthArr[j+1, i];
                        mapArr[j+1, i+1] = '⇠';
                    }
                }
            }
        }

        int m, n;
        m = str1.Length;
        n = str2.Length;
        string s = string.Empty;
        while(lengthArr[m, n] != 0)
        {
            switch(mapArr[m,n])
            {
                case '↖':
                    s += str1[m-1];
                    m--; n--;
                    break;
                case '⇠':
                    n--;
                    break;
                case '⇡':
                    m--;
                    break;
            }
        }

        return new String(s.Reverse().ToArray());
    }
}