using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace docDupDiff
{
    public class docDiff
    {
        public int doc;        // 1 - doc1 and 2 - doc2
        public int idx1;        // index for the different token in doc1
        public int idx2;       // index for the different token in doc2
        public int dType;      // 0 -- substitution and 1 - for deletion
    }

    public class appStrMatch
    {
        private int[][] D;
        public List<docDiff> DF = new List<docDiff>();

        // It computes the edit (Levenshtein) distance with a threshold k. 
        // If the distance is less than and equal to k, it returns the distance. 
        // Otherwise, it returns k+1.
        // A string is represented as an array of integers, each of which correposnds to a token.
        public int kStrDistance(int[] str1, int[] str2, int k)
        {
            int i, j, l1, l2, d, cost, above, left, diag, ylm = 0;
            int tokenIdx;
            bool filled = false;
            int m = str1.Length;
            int n = str2.Length;

            if (n == 0)
                return m;
            if (m == 0)
                return n;
            if (Math.Abs(m - n) > k)
                return k + 1;

            // use only two columns store previous distances
            // To fill a cell D[i, j], only need three other cells D[i-1, j-1], D[i-1, j], and D[i, j-1].
            D = new int[n + 1][];
            for (i = 0; i < D.Length; i++)
            {
                D[i] = new int[m + 1];
            }

            for (i = 0; i <= n; i++)
                for (j = 0; j <= m; j++)
                    D[i][j] = m;

            int x = 0;
            int y = k + 1;
            if (y > m)
                y = m;

            // Initialize the first column.
            for (i = x; i <= y; i++)
                D[0][i] = i;

            // Fill the cells column by column
            j = 1;
            while (x <= y && j <= n)
            {
                l1 = j;			     // l1 is the current column
                l2 = l1 - 1;	 // l2 is the previous column
                tokenIdx = str2[j - 1];

                // the for loop fills the cells for column j.
                for (i = x; i <= y; i++)
                {
                    if (i == 0)
                        // first row
                        D[l1][0] = j;
                    else
                    {	// Cost is 0 if the two characters from two strings are the same. Otherwise, cost is 1.
                        if (tokenIdx == str1[i - 1])
                            cost = 0;
                        else
                            cost = 1;

                        if (x == y && ylm == 0)
                            // one diagnal left
                            D[l1][i] = D[l2][i - 1] + cost;
                        else if (i == x)	// Most upside diagnal and D[i-1, j] can be ignored, because it's larger than k.
                        {	// the upmost row with a distance less than or equal to k
                            left = D[l2][i] + 1;
                            diag = D[l2][i - 1] + cost;
                            D[l1][i] = Math.Min(left, diag);
                        }
                        else if (i == y && ylm == 0) // Most downside diagnal and D[i, j-1] can be ignored, because it's larger than k.
                        {	// the lowest row with distance less than or equal to k
                            above = D[l1][i - 1] + 1;
                            diag = D[l2][i - 1] + cost;
                            D[l1][i] = Math.Min(above, diag);
                        }
                        else
                        {
                            above = D[l1][i - 1] + 1;
                            left = D[l2][i] + 1;
                            diag = D[l2][i - 1] + cost;
                            D[l1][i] = Math.Min(above, Math.Min(left, diag));
                        }
                    }
                    // cout << D[l1][i] << " ";
                    if (i == m - (n - j) && D[l1][i] > k)  // The main diagnal is larger k, return k+1.
                    {
                        return k + 1;
                    }
                }

                if (j == n && y == m)
                    filled = true;

                while (D[l1][x] > k && x <= y)
                    x++;
                if (x > 0)
                    x++;

                y++;
                while (D[l1][y - 1] > k && y > x)
                    y--;
                ylm = 0;
                if (y > m)
                {
                    y = m;
                    ylm = 1;
                }

                j++;
            }

            d = D[n][m];

            if (filled)
                return d;
            else
                return k + 1;
        }

        public void findDif()
        {
            int i, j, m, n;
            docDiff df;

            n = D.Length;
            m = D[0].Length;

            i = n - 1;
            j = m - 1;

            while (i > 0 || j > 0)
            {
                if (i == 0)
                {
                    df = new docDiff();
                    df.doc = 1;     // doc1
                    df.dType = 1;   // deletion
                    df.idx1 = j;
                    df.idx2 = 0;
                    DF.Add(df);
                    j--;
                }
                else if (j == 0)
                {
                    df = new docDiff();
                    df.doc = 2;     // doc1
                    df.dType = 1;   // deletion
                    df.idx1 = 0;
                    df.idx2 = i;
                    DF.Add(df);
                    i--;
                }
                else if (D[i - 1][j - 1] >= D[i][j] && D[i - 1][j] >= D[i][j] && D[i][j - 1] >= D[i][j])
                {
                    i--;
                    j--;
                }
                else if (D[i - 1][j - 1] < D[i][j])
                {
                    df = new docDiff();
                    df.doc = 0;
                    df.dType = 0;   // substitution
                    df.idx1 = j;
                    df.idx2 = i;
                    DF.Add(df);
                    i--;
                    j--;
                }
                else if (D[i - 1][j] < D[i][j])
                {
                    df = new docDiff();
                    df.doc = 2;     // doc2
                    df.dType = 1;   // deletion
                    df.idx1 = 0;
                    df.idx2 = i;
                    DF.Add(df);
                    i--;
                }
                else if (D[i][j - 1] < D[i][j])
                {
                    df = new docDiff();
                    df.doc = 1;     // doc1
                    df.dType = 1;   // deletion
                    df.idx1 = j;
                    df.idx2 = 0;
                    DF.Add(df);
                    j--;
                }
            }
        }
    }

    public class strMatch
    {
        /*
        static void Main(string[] args)
        {
            int i, k;
            appStrMatch s = new appStrMatch();
            int[] d1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 5, 5, 5, 5, 5, 5, 5, 5, 5, 9, 9, 9 };
            int[] d2 = new int[] { 0, 0, 1, 2, 4, 4, 3, 5, 7, 8, 5, 5, 5, 5, 5, 5, 5, 5, 5, 9, 9 };
            int dis;

            k = 10;
            dis = s.kStrDistance(d1, d2, k);
            Console.WriteLine(dis);
            if (dis <= k)
            {
                s.findDif();
                for (i = 0; i < s.DF.Count; i++)
                    Console.WriteLine(s.DF[i].doc + " " + s.DF[i].dType + " " + s.DF[i].idx1 + " " + s.DF[i].idx2);
            }
        }
        */
    }
}