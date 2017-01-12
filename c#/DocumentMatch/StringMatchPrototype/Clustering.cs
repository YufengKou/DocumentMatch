using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using StringMatchPrototype;

namespace Clustering
{
    public enum ClusteringType
    {
        COMPLETE_LINK = 0,
        SINGLE_LINK,
        NO_CLUSTERING
    }

    // data structure for an address
    public class relation
    {
        public int sID1;
        public int sID2;
        public double sim;
    }

    public class cluster
    {
        public List<int> elements;      // strings in the cluster
        public List<int> simElements;   // strings the cluster is similar to

        public cluster()
        {
            elements = null;
            simElements = null;
        }
    }

    public class clustering
    {
        public int[] strToCluster;
        public cluster[] clusters;
        public List<relation> simRelations;

        public void writeClusters(string fName, List<Doc> strList)
        {
            StreamWriter sw = new StreamWriter(fName);

            Dictionary<int, bool> Dict_ClusterIndices = new Dictionary<int, bool>();
            int k = 0;
            for (int i = 0; i < clusters.Length; i++)
            {
                if (clusters[i] != null && clusters[i].elements.Count > 1)
                {
                    sw.WriteLine("Cluster " + k);
                    for (int j = 0; j < clusters[i].elements.Count; j++)
                    {
                        sw.WriteLine(strList[clusters[i].elements[j]].name);
                        Dict_ClusterIndices[clusters[i].elements[j]] = true;
                    }
   
                    sw.WriteLine("");
                    k++;
                }
            }
           
            sw.Close();


            // write single point file. Single points are those elements that do not belong to any clusters
            StreamWriter swSP = new StreamWriter("SinglePoints.txt");
            for (int i = 0; i < strList.Count; i++)
            {
                if (!Dict_ClusterIndices.ContainsKey(i))
                {
                    swSP.WriteLine(strList[i].name);
                }
            }
            swSP.Close();
        }

        // two clusters can be merged if all elements of both clusters are the subset of the similar elements of the other cluster.
        public void mergerClusters(int cls1, int cls2)
        {
            int i, j;
            List<int> newEles;
            List<int> newSimEles;

            j = 0;
            for (i = 0; i < clusters[cls1].elements.Count; i++)
            {
                while (j < clusters[cls2].simElements.Count && clusters[cls1].elements[i] > clusters[cls2].simElements[j])
                    j++;
                if (j >= clusters[cls2].simElements.Count || clusters[cls1].elements[i] < clusters[cls2].simElements[j]) // not found
                    return;
                j++;
            }

            j = 0;
            for (i = 0; i < clusters[cls2].elements.Count; i++)
            {
                while (j < clusters[cls1].simElements.Count && clusters[cls2].elements[i] > clusters[cls1].simElements[j])
                    j++;
                if (j >= clusters[cls1].simElements.Count || clusters[cls2].elements[i] < clusters[cls1].simElements[j]) // not found
                    return;
                j++;
            }

            // The two clusters can merge.
            // Merge elements
            newEles = new List<int>();
            i = 0;
            j = 0;
            while (i < clusters[cls1].elements.Count && j < clusters[cls2].elements.Count)
            {
                if (clusters[cls1].elements[i] < clusters[cls2].elements[j])
                {
                    newEles.Add(clusters[cls1].elements[i]);
                    i++;
                } else if (clusters[cls1].elements[i] == clusters[cls2].elements[j])
                {
                    newEles.Add(clusters[cls1].elements[i]);
                    i++;
                    j++;
                } else
                {
                    newEles.Add(clusters[cls2].elements[j]);
                    j++;
                }
            }

            while (i < clusters[cls1].elements.Count)
            {
                newEles.Add(clusters[cls1].elements[i]);
                i++;
            }

            while (j < clusters[cls2].elements.Count)
            {
                newEles.Add(clusters[cls2].elements[j]);
                j++;
            }

            clusters[cls1].elements = newEles;
            for (i = 0; i < clusters[cls2].elements.Count; i++)
                strToCluster[clusters[cls2].elements[i]] = cls1;
            clusters[cls2].elements = null;

            // merge similar elements
            // An element that is similar to both clusters is added to the new cluster
            // Similar elements need to be sorted so that it doesn't have to check for all elements
            newSimEles = new List<int>();
            j = 0;
            for (i = 0; i < clusters[cls1].simElements.Count; i++)
            {
                while (j < clusters[cls2].simElements.Count && clusters[cls1].simElements[i] != clusters[cls2].simElements[j])
                    j++;
                if (j < clusters[cls2].simElements.Count && clusters[cls1].simElements[i] == clusters[cls2].simElements[j]) // found
                {
                    newSimEles.Add(clusters[cls1].simElements[i]);
                    // j++;
                }
                 j = 0;
            }
            clusters[cls1].simElements = newSimEles;
            clusters[cls2].simElements = null;
            clusters[cls2] = null;
        }

        // merge for single link
        public void simpleMergerClusters(int cls1, int cls2)
        {
            int i;

            for (i = 0; i < clusters[cls2].elements.Count; i++)
            {
                clusters[cls1].elements.Add(clusters[cls2].elements[i]);
                strToCluster[clusters[cls2].elements[i]] = cls1;
            }

            clusters[cls2].elements = null;
            clusters[cls2] = null;
        }

        // cType = 0, complete link and cType = 1, single link
        public void strClustering(int nStrs, ClusteringType cType)
        {
            int i, n, m;
            
            // each string form a cluster by itself
            strToCluster = new int[nStrs];
            for (i = 0; i < nStrs; i++)
                strToCluster[i] = i;
            
            // initialize all single element clusters
            clusters = new cluster[nStrs];
            for (i = 0; i < nStrs; i++)
            {   clusters[i] = new cluster();
            if (cType == ClusteringType.COMPLETE_LINK)
                    clusters[i].simElements = null;
                clusters[i].elements = new List<int>();
                clusters[i].elements.Add(i);
            }

            if (cType == ClusteringType.COMPLETE_LINK) // complete link
            {
                // Add all similar elements to all clusters
                IEnumerable<relation> sortedRelations1 =
                    from aRel in simRelations
                    orderby aRel.sID1, aRel.sID2
                    select aRel;

                foreach (relation aRel in sortedRelations1)
                {
                    n = aRel.sID1;
                    m = aRel.sID2;
                    if (clusters[n].simElements == null)
                        clusters[n].simElements = new List<int>();
                    clusters[n].simElements.Add(m);
                    if (clusters[m].simElements == null)
                        clusters[m].simElements = new List<int>();
                    clusters[m].simElements.Add(n);
                }

                IEnumerable<relation> sortedRelations =
                    from aRel in simRelations
                    orderby aRel.sim descending
                    select aRel;

                foreach (relation aRel in sortedRelations)
                {
                    if (strToCluster[aRel.sID1] != strToCluster[aRel.sID2])     // two strings of a relation don't belong to the same cluster.
                        mergerClusters(strToCluster[aRel.sID1], strToCluster[aRel.sID2]);
                }
             } else // single link
            {
                for (i = 0; i < simRelations.Count; i++)
                    if (strToCluster[simRelations[i].sID1] != strToCluster[simRelations[i].sID2])
                        simpleMergerClusters(strToCluster[simRelations[i].sID1], strToCluster[simRelations[i].sID2]);
            }
        }

    }

    public class sClustering 
    {
        public static clustering c = new clustering();

        /*
        static void Main(string[] args)
        {
            appStrMatch s = new appStrMatch(args[0]);
            s.strMatch(Convert.ToInt32(args[1]), 1000, Convert.ToDouble(args[2]), args[0], null);
            StrCompStatistics statistics = s.GetStrMatchStatistics();
            c.simRelations = s.simRelations;
            // Console.WriteLine(c.simRelations.Count);
            c.strClustering(s.strObjList.Count, Convert.ToInt32(args[3]));
            c.writeClusters(args[0] + ".clusters", s.strObjList);
        }
         */
    }
}
