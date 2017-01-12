using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Threading;
using System.ComponentModel;

using Clustering;

namespace StringMatchPrototype
{

    public class TreeNode
    {
        private int BinColID; // the bin number, starting from 0
        private int BinVal;
        private List<int> docIndexList = null;
        private SortedList<int, TreeNode> children;

        public TreeNode()
        {
            children = null;
            docIndexList = null;
        }
        public int GetBinVal()
        {
            return BinVal;
        }
        public void SetBinVal(int val)
        {
            BinVal = val;
        }
        public int GetBinColID()
        {
            return BinColID;
        }
        public void SetBinColID(int v)
        {
            BinColID = v;
        }
        public void AddDoc(int docIndex)
        {
            if (docIndexList == null)
                docIndexList = new List<int>();
            docIndexList.Add(docIndex);
        }
        public List<int> GetDocIndexList()
        {
            return docIndexList;
        }
        public bool IsChildrenNull()
        {
            if (children == null)
                return true;
            else
                return false;
        }
        public bool ContainsChild(int key)
        {
            if (children != null && children.ContainsKey(key))
                return true;
            else
                return false;
        }
        public void AddChild(int key, TreeNode n)
        {
            if (children == null)
                children = new SortedList<int, TreeNode>();

            children.Add(key, n);
        }
        public TreeNode GetChild(int key)
        {
            //if (children != null && children.ContainsKey(key))
            return children[key];
            //else
            //    return null;
        }
        public TreeNode GetSmallestChild()
        {
            if (children == null)
                return null;
            else
                return children.Values[0];
        }
        public TreeNode GetChildByIndex(int ind)
        {
            return children.Values[ind];
        }
        public int GetNextChildIndex(int indOfCurChild)
        {
            if (children == null || indOfCurChild >= children.Count - 1)
                return -1;
            else
                return indOfCurChild + 1;
        }
        public int GetNumberOfChildren()
        {
            if (children == null)
                return 0;
            else
                return children.Count;
        }
        // return the index of a child whose key is closest to the input
        public int FindClosestKeyIndex(int key)
        {
            return binary_search(children, 0, children.Count - 1, key);
        }
        // return the index of a child whose key value is between key1 and key2 ( key1 < key2)
        public int FindIndexWithinRange(int key1, int key2)
        {
            if (key2 < children.Values[0].BinVal || key1 > children.Values[children.Count - 1].BinVal)
                return -1;
            int begin = 0;
            int end = children.Count - 1;
            int mid = (begin + end) / 2;
            while (mid > begin && mid < end)
            {
                if (children.Values[mid].BinVal > key2)
                {
                    end = mid;
                    mid = (begin + end) / 2;
                }
                else if (children.Values[mid].BinVal < key1)
                {
                    begin = mid;
                    mid = (begin + end) / 2;
                }
                else
                    break;
            }

            return mid;
        }

        private int binary_search(SortedList<int, TreeNode> list, int begin, int end, int key)
        {
            if (key <= list.Values[begin].BinVal)
                return begin;
            else if (key >= list.Values[end].BinVal)
                return end;

            int mid = (begin + end) / 2;
            if (mid == begin)
                return mid;
            if (list.Values[mid].BinVal == key)
                return mid;
            else if (list.Values[mid].BinVal < key)
                return binary_search(list, mid, end, key);
            else
                return binary_search(list, begin, mid, key);
        }
    }

    public enum SearchDirection
    {
        ToSmallerValue = 0,
        ToLargerValue
    }

    public class StackElmt
    {
        public TreeNode Node { get; set; }
        public int PDist { get; set; }
        public int NDist { get; set; }
    }


    public class Doc
    {
        public string name { get; set; }
        public List<int> docTokens { get; set; }
        public int docIndex { get; set; }   // the index of the document in list strList
        public List<Doc> sameDocList { get; set; }

        public Doc(string fName)
        {
            name = fName;
            docTokens = new List<int>();
            sameDocList = null;
        }
    }

    public class StrCompStatistics
    {
        public int NumOfBuckets { get; set; }
        public int NumOfNonEmptyBuckets { get; set; }
        public int NumOfStrings { get; set; }
        public int AvgStrLen { get; set; } 
        public int MaxBucketSize { get; set; }
        public int AvgBucketSize { get; set; }
        public long NumOfStrComp { get; set; }
        public int NumOfBinComp { get; set; }
        public long NumOfMatched { get; set; } 
        public int BucketSearchTime { get; set; }
        public int StrCompTime { get; set; }
        public int TotalRunTime { get; set; }
        public int PreprocessTime { get; set; }
        public int DataImportTime { get; set; }
        public int MaxStrLen { get; set; }  
        public int MinStrLen { get; set; }
        public int NumOfTokens { get; set; }

        public DateTime ProgramBeginTime { get; set; }
        public DateTime ProgramEndTime { get; set; }
        public string OutputFile { get; set; }

        //cluster information
        public int NumOfClusters { get; set; }
        public string ClusterFile { get; set; }
        public string ClusterType { get; set; }
        public int MaxClusterSize { get; set; }
        public int MinClusterSize { get; set; }
        public double AvgClusterSize { get; set; }

        public void init()
        {
            NumOfBinComp = 0;
            NumOfBuckets = 0;
            NumOfNonEmptyBuckets = 0;
            MaxBucketSize = 0;
            AvgBucketSize = 0;
            NumOfStrComp = 0;
            NumOfBinComp = 0;
            BucketSearchTime = 0;
            StrCompTime = 0;
            TotalRunTime = 0;
            NumOfStrings = 0;
            AvgStrLen = 0;

            //cluster
            NumOfClusters = 0;
            ClusterFile = "";
            ClusterType = "";
            MaxClusterSize = 0;
            MinClusterSize = 0;
            AvgClusterSize = 0; 
        }
    }


    public class appStrMatch
    {
        const double ep = 0.00000001;  // for float number precisions
        private int maxVal;		// max number of values for each bin of characters
        private int nBins;		// number of bins for characters
        private int maxDist = 1000;    // maximum distance allowed for comparison. By default, it is 1000. 
        private double th;		// between 0 and 1, minimum percentage of match between two strings
        static long nMatches = 0;
        static long nMatched = 0;

        private StrCompStatistics statistics = new StrCompStatistics();
        public string InputFileDir { get; set; }
        public string OutputFileDir { get; set; }
        public string OutputFileName { get; set; }

        private TreeNode BinTree = new TreeNode();
        private int nLeafNodes = 0;

        private static Dictionary<int, string> IdTokenHash = null;
        private static Dictionary<string, int> tokenDict = null; //new Dictionary<string, int>();
        private static List<Doc> strList = new List<Doc>();	// the list of all strings to be matched.

        private List<relation> simRelations = new List<relation>(); // for clustering

        public static List<int> GetDocTokenIdList(int index)
        {
            return strList[index].docTokens;
        }

        public static List<string> GetDocTokenStringList(int index)
        {
            List<string> tList = new List<string>();
            foreach (var tId in strList[index].docTokens)
            {
                tList.Add(IdTokenHash[tId]);
            }

            return tList;
        }

        public appStrMatch(string inPath, string outPath)
        {
            nMatches = 0;
            nMatched = 0;
            statistics.init();
            InputFileDir = inPath;
            OutputFileDir = outPath;
            OutputFileName = OutputFileDir + "\\SimilarDoc"; 
            tokenDict = new Dictionary<string, int>();
            strList = new List<Doc>();
            //strsDict = new Dictionary<long, List<int>>();
            IdTokenHash = new Dictionary<int, string>();
        }

        public StrCompStatistics GetStrMatchStatistics()
        {
            return statistics;
        }

        // It computes the edit (Levenshtein) distance with a threshold k. 
        // If the distance is less than and equal to k, it returns the distance. 
        // Otherwise, it returns k+1.
        // A string is represented as an array of integers, each of which correposnds to a token.
        public static int kStrDistance(int[] str1, int[] str2, int k)
        {
            int i, j, l1, l2, d, cost, above, left, diag, ylm = 0;
            int tokenIdx;
            bool filled = false;
            int m = str1.Length;
            int n = str2.Length;

            nMatches++;
            if (n == 0)
                return m;
            if (m == 0)
                return n;
            if (Math.Abs(m - n) > k)
                return k + 1;

            // use only two columns store previous distances
            // To fill a cell D[i, j], only need three other cells D[i-1, j-1], D[i-1, j], and D[i, j-1].
            int[][] D = new int[2][];
            for (i = 0; i < D.Length; i++)
            {
                D[i] = new int[m + 1];
            }

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
                l1 = j % 2;			     // l1 is the current column
                l2 = Math.Abs(l1 - 1);	 // l2 is the previous column
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

            d = D[n % 2][m];

            if (filled)
                return d;
            else
                return k + 1;
        }

        // Given a vector, return a hash value
        private int getHashVal(int[] bins)
        {
            int i, j, n;

            j = 0;
            n = 1;
            for (i = 0; i < nBins; i++)
            {
                j = j + bins[i] * n;
                n = n * maxVal;
            }

            return j;
        }

        // Returns a hash value and also values in bins are returned through the parameter
        private void strHash(Doc doc, int[] bins)
        {
            List<int> docTokens = doc.docTokens;
            int i, c;
            long j;

            for (i = 0; i < nBins; i++)
                bins[i] = 0;

            i = 0;
            for (i = 0; i < docTokens.Count; i++)
            {
                c = docTokens[i];
                j = c % nBins;
                if (bins[j] < maxVal - 1)
                    bins[j]++;
            }
        }

        // Print the file names, instead of strings.
        private void printMatch(Doc d1, Doc d2, int strDis, StreamWriter oFile)
        {
            string str;
            nMatched++;
            double similarity = Math.Round(1 - (strDis * 1.0 / Math.Min(d1.docTokens.Count, d2.docTokens.Count)), 5);
            str = d1.name + "\t" + d2.name + "\t" + similarity + "\t" + strDis + "\t" + d1.docIndex + "\t" + d2.docIndex;
            oFile.WriteLine(str);

            // for clustering
            relation aRelation = new relation();
            aRelation.sID1 = d1.docIndex;
            aRelation.sID2 = d2.docIndex;
            aRelation.sim = similarity;
            simRelations.Add(aRelation);
        }


        private void compare_buckets(TreeNode leafNode, TreeNode curNode, double th, int k, StreamWriter oFile, int pDist, int nDist)
        {
            foreach (var idx1 in leafNode.GetDocIndexList())
            {
                int m = strList[idx1].docTokens.Count;
                int k1 = (int)(m * (1 - th) + ep);
                if (k1 > maxDist)
                    k1 = maxDist;
                if (k1 >= pDist && k1 >= nDist)
                {
                    foreach (var idx2 in curNode.GetDocIndexList())
                    {
                        int k2;
                        if (th >= 0)	// use threshold
                        {
                            int n = strList[idx2].docTokens.Count;
                            if (m > n)
                                k2 = (int)(n * (1 - th) + ep);
                            else
                                k2 = k1;
                        }
                        else
                            k2 = k;
                        if (k2 > maxDist)
                            k2 = maxDist;
                        int strDis = kStrDistance(strList[idx1].docTokens.ToArray(), strList[idx2].docTokens.ToArray(), k2);
                        if (strDis <= k2)
                        {
                            printMatch(strList[idx1], strList[idx2], strDis, oFile);
                            if (strList[idx1].sameDocList != null)
                            {
                                foreach (var dupDoc in strList[idx1].sameDocList)
                                {
                                    printMatch(strList[dupDoc.docIndex], strList[idx2], strDis, oFile);
                                }
                            }
                        }
                    } // end foreach
                } // end if
            } // end foreach
        }

        private void GetBinValues(int[] leafIndex, int[] bins)
        {
            TreeNode t = BinTree;
            int i = 0;
            while (!t.IsChildrenNull())
            {
                t = t.GetChildByIndex(leafIndex[i]);
                bins[i] = t.GetBinVal();
                i++;
            }
        }

        private void matchALLStrings_New(BackgroundWorker bgWorker, string outFileName)
        {
            statistics.NumOfNonEmptyBuckets = 0;
            statistics.MaxBucketSize = 0;
            statistics.AvgBucketSize = 0;

            StreamWriter sw = new StreamWriter(outFileName);

            int [] bins = new int[nBins];

            Stack<StackElmt> leafStack = new Stack<StackElmt>();
            TreeNode t = BinTree;
            int[] curLeafIndex = new int[bins.Length];
            for (int i = 0; i < curLeafIndex.Length; i++)
                curLeafIndex[i] = 0;

            TreeNode parentNode = null;
            while (t != null)
            {
                StackElmt e = new StackElmt();
                e.Node = t;
                leafStack.Push(e);
                parentNode = t;
                t = t.GetSmallestChild();
            }

            int count = 0;
            while (leafStack.Count > 0)
            {
                StackElmt e = leafStack.Peek();
                if (e.Node.IsChildrenNull()) // leaf 
                {
                    bgWorker.ReportProgress(count * 100 / nLeafNodes);
                    count++;
                    if (count % 1000 == 0)
                        Logger.writeLog("leaf " + count + " is being processed. ", LogType.LOG_INFO);

                    GetBinValues(curLeafIndex, bins);
                    matchHashStrings_New(e.Node, curLeafIndex, bins, sw);
                    leafStack.Pop();
                    int numOfStrInBucket = e.Node.GetDocIndexList().Count;
                    statistics.AvgBucketSize += numOfStrInBucket;
                    if (numOfStrInBucket > statistics.MaxBucketSize)
                        statistics.MaxBucketSize = numOfStrInBucket;
                }
                else // internal node
                {
                    int nextChildIndex = e.Node.GetNextChildIndex(curLeafIndex[e.Node.GetBinColID() + 1]);
                    if (nextChildIndex < 0)  // do not have next child (have reached the largest child)
                    {
                        leafStack.Pop();
                    }
                    else
                    {
                        curLeafIndex[e.Node.GetBinColID() + 1] = nextChildIndex;
                        TreeNode node = e.Node.GetChildByIndex(nextChildIndex);
                        while (node != null)
                        {
                            StackElmt elmt = new StackElmt();
                            elmt.Node = node;
                            leafStack.Push(elmt);
                            node = node.GetSmallestChild();
                            if (node != null)
                                curLeafIndex[node.GetBinColID()] = 0;
                        } // end of "while (node != null)"
                    }
                }

            }  // end of while loop
            sw.Close();

            statistics.NumOfNonEmptyBuckets = nLeafNodes;
            statistics.AvgBucketSize = statistics.AvgBucketSize / nLeafNodes;
            statistics.OutputFile = outFileName;
        }

        private int CreateBinTree()
        {
            // create root of the bin tree
            BinTree.SetBinColID(-1);
            BinTree.SetBinVal(-1);

            int countLeaf = 0;
            int[] bins = new int[nBins];
            for (int i = 0; i < strList.Count; i++)
            {
                strHash(strList[i], bins);
                TreeNode p = BinTree; // parent
                for (int j = 0; j < bins.Length; j++)
                {
                    if (!p.ContainsChild(bins[j]))
                    {
                        TreeNode t = new TreeNode();
                        t.SetBinColID(j);
                        t.SetBinVal(bins[j]);
                        p.AddChild(bins[j], t);
                        if (j == bins.Length - 1)
                            countLeaf++;
                        p = t;
                    }
                    else
                        p = p.GetChild(bins[j]);
                }
                p.AddDoc(i);
            }

            return countLeaf++;
        }


        // th is the percentage of minimum similarity
        private void matchHashStrings_New(TreeNode leafNode, int[] leafNodeIndex, int[] bins, StreamWriter oFile)
        {
            int strDis, m, n, k1, l;
            // compare the strings in current bucket
            l = 0;
            k1 = 0;
            List<int> docIdxList = leafNode.GetDocIndexList();
            
            /*  ===  DO NOT DELETE == THIS IS THE CODE BEFORE DUPLICATE STRING GROUP IS IMPLEMENTED 
            for (int i = 0; i < docIdxList.Count; i++)
            {
                m = strList[docIdxList[i]].docTokens.Count;
                if (m > l)
                    l = m;	// l is the length of the longest string
                for (int j = i + 1; j < docIdxList.Count; j++)
                {
                    n = strList[docIdxList[j]].docTokens.Count;
                    if (m > n)
                        k1 = (int)(n * (1 - th) + ep);
                    else
                        k1 = (int)(m * (1 - th) + ep);

                    if (k1 > maxDist)
                        k1 = maxDist;
                    strDis = kStrDistance(strList[docIdxList[i]].docTokens.ToArray(), strList[docIdxList[j]].docTokens.ToArray(), k1);
                    if (strDis <= k1)
                        printMatch(strList[docIdxList[i]], strList[docIdxList[j]], strDis, oFile);
                }
            }
           */
            
            for (int i = 0; i < docIdxList.Count; i++)
            {
                m = strList[docIdxList[i]].docTokens.Count;
                if (m > l)
                    l = m;	// l is the length of the longest string

                List<Doc> aprMatchList = new List<Doc>();
                List<int> aprDistList = new List<int>();
                int j = i + 1;
                while ( j < docIdxList.Count)
                {
                    n = strList[docIdxList[j]].docTokens.Count;
                    if (m > n)
                        k1 = (int)(n * (1 - th) + ep);
                    else
                        k1 = (int)(m * (1 - th) + ep);

                    if (k1 > maxDist)
                        k1 = maxDist;
                    strDis = kStrDistance(strList[docIdxList[i]].docTokens.ToArray(), strList[docIdxList[j]].docTokens.ToArray(), k1);

                    if (strDis <= k1)
                    {
                        printMatch(strList[docIdxList[i]], strList[docIdxList[j]], strDis, oFile);

                        if (strDis == 0) // exact match
                        {
                            if (strList[docIdxList[i]].sameDocList == null)
                                strList[docIdxList[i]].sameDocList = new List<Doc>();
                            strList[docIdxList[i]].sameDocList.Add(strList[docIdxList[j]]);
                            docIdxList.RemoveAt(j);   // note, j should not increment. 
                        }
                        else if (strDis > 0)
                        {
                            aprMatchList.Add(strList[docIdxList[j]]);
                            aprDistList.Add(strDis);
                            j++;
                        }
                        else
                        {
                            j++;
                            Logger.writeLog("*** Error in matchHashStrings_New(): edit distance can not be negative. ", LogType.LOG_INFO);
                        }
                    }
                    else   // distance > k1
                        j++; 
                }  // end of while

                if (strList[docIdxList[i]].sameDocList != null)
                {
                    foreach (var dupDoc in strList[docIdxList[i]].sameDocList)
                    {
                        for (int ii = 0; ii < aprMatchList.Count; ii++ )
                        {
                            printMatch(dupDoc, aprMatchList[ii], aprDistList[ii], oFile);
                        }
                    }

                    for (int jj = 0; jj < strList[docIdxList[i]].sameDocList.Count; jj++)
                    {
                        for (int kk = jj + 1; kk < strList[docIdxList[i]].sameDocList.Count; kk++)
                        {
                            printMatch(strList[docIdxList[i]].sameDocList[jj], strList[docIdxList[i]].sameDocList[kk], 0, oFile);
                        }
                    }
                } // end of if
            }  // end of for
           

            int k = (int)(l * (1 - th) + ep);
            if (k > maxDist)
                k = maxDist;

            // push the path from root to current benchmark leaf node 
            Stack<StackElmt> BinStack = new Stack<StackElmt>();
            StackElmt e = new StackElmt();
            e.Node = BinTree;
            BinStack.Push(e);
            TreeNode node = e.Node;
            for (int i = 0; i < leafNodeIndex.Length; i++)
            {
                e = new StackElmt();
                e.Node = node.GetChildByIndex(leafNodeIndex[i]);
                BinStack.Push(e);
                node = e.Node;
            }

            int[] curBinIndex = new int[bins.Length];
            for (int i = 0; i < curBinIndex.Length; i++)
                curBinIndex[i] = leafNodeIndex[i];
            while (BinStack.Count > 0)
            {
                BinStack.Pop();
                if (BinStack.Count > 0)
                {
                    StackElmt elmt = BinStack.Peek();
                    int indOfNextChild = elmt.Node.GetNextChildIndex(curBinIndex[elmt.Node.GetBinColID() + 1]);
                    while (indOfNextChild > 0)
                    {
                        TreeNode nextChild = elmt.Node.GetChildByIndex(indOfNextChild);
                        TopDownBucketFilter(nextChild, leafNode, bins, k, oFile);
                        indOfNextChild = elmt.Node.GetNextChildIndex(indOfNextChild);
                    }
                }
            }
        }


        // curNode: the current node performing bucket comparison
        // bins: the bin values of the benchmark leaf node 
        private void TopDownBucketFilter(TreeNode curNode, TreeNode leafNode, int[] bins, int k, StreamWriter oFile)
        {
            // push the root node into stack
            Stack<StackElmt> BinStack = new Stack<StackElmt>();
            StackElmt e = new StackElmt();
            e.Node = curNode;
            int dist = curNode.GetBinVal() - bins[curNode.GetBinColID()];
            if (dist > 0)
            {
                e.PDist = dist;
                e.NDist = 0;
            }
            else if (dist == 0)
            {
                e.PDist = 0;
                e.NDist = 0;
            }
            else
            {
                e.PDist = 0;
                e.NDist = -dist;
            }
            if (e.PDist <= k && e.NDist <= k)
                BinStack.Push(e);

            while (BinStack.Count > 0)
            {
                StackElmt elmt = BinStack.Pop();
                if (elmt.Node.IsChildrenNull())  // leaf node. 
                {
                    compare_buckets(leafNode, elmt.Node, th, k, oFile, elmt.PDist, elmt.NDist);
                }
                else  // internal node
                {
                    int numOfChildren = elmt.Node.GetNumberOfChildren();
                    if (numOfChildren <= 4)  // sequential scan if number of children is small
                    {
                        for (int i = 0; i < numOfChildren; i++)
                        {
                            TreeNode tNode = elmt.Node.GetChildByIndex(i);
                            int newDist = tNode.GetBinVal() - bins[tNode.GetBinColID()];
                            int pDist = elmt.PDist, nDist = elmt.NDist;
                            if (newDist > 0)
                                pDist += newDist;
                            else
                                nDist -= newDist;

                            if (pDist <= k && nDist <= k)
                            {
                                StackElmt newElmt = new StackElmt();
                                newElmt.Node = tNode;
                                newElmt.PDist = pDist;
                                newElmt.NDist = nDist;
                                BinStack.Push(newElmt);
                            }
                        }
                    }
                    else  // use binary search if number of children is large
                    {
                        int rngBegin = bins[elmt.Node.GetBinColID() + 1] - (k - elmt.NDist);
                        if (rngBegin < 0)
                            rngBegin = 0;
                        int rngEnd = bins[elmt.Node.GetBinColID() + 1] + (k - elmt.PDist);
                        if (rngEnd > maxVal)
                            rngEnd = maxVal;
                        int anchorIndex = elmt.Node.FindIndexWithinRange(rngBegin, rngEnd);
                        if (anchorIndex < 0)
                            continue;
                        SearchDirection direct = SearchDirection.ToSmallerValue;
                        int i = anchorIndex;
                        while (i >= 0 && i < numOfChildren)
                        {
                            TreeNode cNode = elmt.Node.GetChildByIndex(i);
                            int pDist = elmt.PDist, nDist = elmt.NDist;
                            int newDist = cNode.GetBinVal() - bins[cNode.GetBinColID()];
                            if (newDist > 0)
                                pDist += newDist;
                            else if (newDist < 0)
                                nDist -= newDist;

                            if (direct == SearchDirection.ToSmallerValue)
                            {
                                if (nDist > k)
                                {
                                    direct = SearchDirection.ToLargerValue;
                                    i = anchorIndex + 1;
                                }
                                else
                                {
                                    StackElmt newElmt = new StackElmt();
                                    newElmt.Node = cNode;
                                    newElmt.PDist = pDist;
                                    newElmt.NDist = nDist;
                                    BinStack.Push(newElmt);
                                    i--;
                                    if (i < 0 && direct == SearchDirection.ToSmallerValue)
                                    {
                                        direct = SearchDirection.ToLargerValue;
                                        i = anchorIndex + 1;
                                    }
                                }
                            }
                            else  // move toward larger value
                            {
                                if (pDist > k)
                                    break;
                                else
                                {
                                    StackElmt newElmt = new StackElmt();
                                    newElmt.Node = cNode;
                                    newElmt.PDist = pDist;
                                    newElmt.NDist = nDist;
                                    BinStack.Push(newElmt);
                                    i++;
                                }
                            }
                        } // end of "while (i >=0 && i<numOfChildren)"
                    }

                }
            }
        }

        public int strMatch_New(int numOfBins, int maxBinVal, double matchThreshold, int maxDistance, ClusteringType clusterType, BackgroundWorker bgWorker)
        {
            Logger.writeLog("The matching algorithm started.", LogType.LOG_INFO);
            tokenDict = new Dictionary<string, int>();
            //strsDict = new Dictionary<long, List<int>>();
            IdTokenHash = new Dictionary<int, string>();

            bgWorker.ReportProgress(2);
            statistics.ProgramBeginTime = DateTime.Now;
            statistics.MaxStrLen = 0;
            statistics.MinStrLen = Int32.MaxValue;

            maxVal = maxBinVal;
            nBins = numOfBins;
            th = matchThreshold;
            maxDist = maxDistance;

            DateTime t1 = DateTime.Now;

            int seqNo = 0;
            tokenDict.Clear();
            string[] files = Directory.GetFiles(InputFileDir, "*", SearchOption.AllDirectories);
            long totalLen = 0;
            int fileCount = 0;
            foreach (var f in files)
            {
                StreamReader sr = new StreamReader(f);
                string str;
                Doc doc = new Doc(f);
                int docLen = 0;
                while ((str = sr.ReadLine()) != null)
                {
                    str = str.ToLower();
                    //string[] tokens = str.Split(new char[] { ' ', '\t', ',', '.', ':', '\"', '?', '!' });  // do NOT delete:  Benchmark 
                    string[] tokens = str.Split(new char[] { ' ', '\t', ',', '.', ':', '\"', '?', '!', '@', '\n', '\''});  
                    foreach (var t in tokens)
                    {
                        if (t.Length == 0)
                            continue;
                        if (!tokenDict.ContainsKey(t))
                            tokenDict[t] = seqNo++;
                        doc.docTokens.Add(tokenDict[t]);
                        IdTokenHash[tokenDict[t]] = t;
                        docLen++;
                    }
                }
                sr.Close();
                if (docLen == 0)
                    continue;
                totalLen += docLen;
                doc.docIndex = strList.Count;
                strList.Add(doc);
                if (docLen > statistics.MaxStrLen)
                    statistics.MaxStrLen = docLen;
                if (docLen < statistics.MinStrLen)
                    statistics.MinStrLen = docLen;

                fileCount++;
                if (fileCount % 1000 == 0)
                    Logger.writeLog("" + fileCount + " files have been read and tokenized. ", LogType.LOG_INFO);
            }

            statistics.DataImportTime = (int)(DateTime.Now - t1).TotalSeconds;
            Logger.writeLog("Finish reading the documents and making dictionary. The data import takes " + statistics.DataImportTime + "seconds. ", LogType.LOG_INFO);

            nLeafNodes = CreateBinTree();

            Logger.writeLog("Bin Tree has been constructed. The num of leaf nodes is " + nLeafNodes, LogType.LOG_INFO);
            matchALLStrings_New(bgWorker, OutputFileName);
            Console.WriteLine(nMatched);
            Console.WriteLine(nMatches);

            System.TimeSpan tDiff = DateTime.Now - statistics.ProgramBeginTime;
            statistics.PreprocessTime = tDiff.Seconds;
            statistics.ProgramEndTime = DateTime.Now;
            statistics.TotalRunTime = (int)(statistics.ProgramEndTime - statistics.ProgramBeginTime).TotalSeconds;
            statistics.NumOfStrings = strList.Count;
            statistics.AvgStrLen = (int)(totalLen / strList.Count);
            statistics.NumOfStrComp = nMatches;
            statistics.NumOfTokens = tokenDict.Count;
            statistics.NumOfMatched = nMatched;

            // print out clusters
            if (clusterType != ClusteringType.NO_CLUSTERING)
            {
                clustering c = new clustering();
                c.simRelations = simRelations;
                // Console.WriteLine(c.simRelations.Count);

                c.strClustering(strList.Count, clusterType);
                statistics.ClusterFile = OutputFileDir + "\\DocumentMatch.clusters";
                if (clusterType == ClusteringType.COMPLETE_LINK)
                    statistics.ClusterType = "COMPLETE_LINK";
                else if (clusterType == ClusteringType.SINGLE_LINK)
                    statistics.ClusterType = "SINGLE_LINK";
                c.writeClusters(statistics.ClusterFile, strList);
                compute_cluster_statistics(statistics, c);
            }
            else
                statistics.ClusterType = "";


            return 0;
        }


        private void compute_cluster_statistics(StrCompStatistics statistics, clustering c)
        {
            statistics.MaxClusterSize = 0;
            statistics.MinClusterSize = Int32.MaxValue;
            statistics.NumOfClusters = 0;
            for (int i = 0; i < c.clusters.Length; i++)
            {
                if (c.clusters[i] != null && c.clusters[i].elements.Count > 1)
                {
                    if (c.clusters[i].elements.Count > statistics.MaxClusterSize)
                        statistics.MaxClusterSize = c.clusters[i].elements.Count;
                    if (c.clusters[i].elements.Count < statistics.MinClusterSize)
                        statistics.MinClusterSize = c.clusters[i].elements.Count;
                    statistics.AvgClusterSize += c.clusters[i].elements.Count;
                    statistics.NumOfClusters++;
                }
            }
            statistics.AvgClusterSize = statistics.AvgClusterSize * 1.0 / statistics.NumOfClusters;
        }

    }


    public class TestStrMatch
    {
        public double Threshold { get; set; }
        public int NumOfBins { get; set; }
        public int MaxVal { get; set; }
        public int Runtime { get; set; }
        public long NumOfMatchedPairs { get; set; }
        public int NumOfBuckets { get; set; }
        public string TestFileName { get; set; }
        public double AvgBucketSize { get; set; }
        public long NumOfMatches { get; set; }
        public int MaxDistance { get; set; }

        public TestStrMatch(double th, int num, int max)
        {
            Threshold = th;
            NumOfBins = num;
            MaxVal = max;
        }

    }
}
