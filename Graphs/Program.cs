using System;
using System.Collections.Generic;

namespace Graphs
{
    class Graph
    {
        int NodeCount;
        Dictionary<int, List<int>> adjacencyList = new();

        private void AddNode(int node)
        {
            if (!adjacencyList.ContainsKey(node))
            {
                adjacencyList.Add(node, new());
                NodeCount++;
            }
        }

        private void AddDirectedEdge(int node1, int node2)
        {
            AddNode(node1);
            AddNode(node2);
            adjacencyList[node1].Add(node2);
        }

        private void AddUndirectedEdge(int node1, int node2)
        {
            AddNode(node1);
            AddNode(node2);
            adjacencyList[node1].Add(node2);
            adjacencyList[node2].Add(node1);
        }

        public void ShowAdjacencyList()
        {
            foreach (var node in adjacencyList)
            {
                Console.Write($"{node.Key} --> ");
                foreach (var value in node.Value)
                {
                    Console.Write($"{value} ");
                }

                Console.WriteLine();
            }
        }

        public void CreateDirectedGraph(int[][] edgeList)
        {
            foreach (var edge in edgeList)
            {
                AddDirectedEdge(edge[0], edge[1]);
            }
        }

        public void CreateUndirectedGraph(int[][] edgeList)
        {
            foreach (var edge in edgeList)
            {
                AddUndirectedEdge(edge[0], edge[1]);
            }
        }

        #region Traversals

        public void DFSIterative(int source)
        {
            Stack<int> stack = new();
            HashSet<int> visited = new();

            stack.Push(source);
            visited.Add(source);

            Console.Write($"DFSIterative for source = {source}: ");

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                Console.Write($"{current} ");

                var neighbours = adjacencyList[current];

                foreach (var neighbour in neighbours)
                {
                    if (!visited.Contains(neighbour))
                    {
                        visited.Add(neighbour);
                        stack.Push(neighbour);
                    }
                }
            }
        }

        public void DFSRecursive(int source, HashSet<int> visited)
        {
            if (visited.Contains(source))
                return;

            visited.Add(source);
            Console.Write($"{source} ");

            var neighbours = adjacencyList[source];

            foreach (var neighbour in neighbours)
            {
                DFSRecursive(neighbour, visited);
            }
        }

        public void BFSIterative(int source)
        {
            Queue<int> queue = new();
            HashSet<int> visited = new();

            queue.Enqueue(source);
            visited.Add(source);

            Console.Write($"BFS : ");

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                Console.Write($"{current} ");
                var neighbours = adjacencyList[current];

                foreach (var neighbour in neighbours)
                {
                    if (!visited.Contains(neighbour))
                    {
                        visited.Add(neighbour);
                        queue.Enqueue(neighbour);
                    }
                }
            }
        }

        public void BFSRecursive(HashSet<int> visited, Queue<int> queue)
        {
            if (queue.Count == 0)
            {
                return;
            }

            var current = queue.Dequeue();
            Console.Write($"{current} ");

            if (!visited.Contains(current))
            {
                visited.Add(current);
            }

            var neighbours = adjacencyList[current];

            foreach (var neighbour in neighbours)
            {
                if (!visited.Contains(neighbour))
                {
                    visited.Add(neighbour);
                    queue.Enqueue(neighbour);
                }
            }

            BFSRecursive(visited, queue);
        }

        #endregion

        #region TopologicalSort
        public void TopologicalSortDFS()
        {
            Stack<int> topologicalOrder = new();
            HashSet<int> visited = new();

            foreach (var node in adjacencyList.Keys)
            {
                DFS(node, visited, topologicalOrder);
            }

            Console.Write($"Topological Order DFS: ");

            while (topologicalOrder.Count > 0)
            {
                Console.Write($"{topologicalOrder.Pop()} ");
            }
        }

        private void DFS(int source, HashSet<int> visited, Stack<int> stack)
        {
            if (visited.Contains(source))
                return;

            visited.Add(source);

            var neighbours = adjacencyList[source];

            foreach (var neighbour in neighbours)
            {
                DFS(neighbour, visited, stack);
            }

            stack.Push(source);
        }

        // Kahn's Algorithm
        public void TopologicalSortBFS()
        {
            Queue<int> queue = new();
            int[] indegrees = CalculateIndegreeOfNodes();
            List<int> topologicalOrder = new();

            for (int i = 0; i < indegrees.Length; i++)
            {
                int degree = indegrees[i];

                if (degree == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var neighbours = adjacencyList[current];

                foreach (var neighbour in neighbours)
                {
                    indegrees[neighbour]--;

                    if (indegrees[neighbour] == 0)
                        queue.Enqueue(neighbour);
                }

                indegrees[current]--;
                topologicalOrder.Add(current);
            }

            Console.Write($"Topological Order BFS: ");
            foreach (var node in topologicalOrder)
            {
                Console.Write($"{node} ");
            }
        }

        private int[] CalculateIndegreeOfNodes()
        {
            int[] indegrees = new int[NodeCount];

            foreach (var node in adjacencyList.Keys)
            {
                var neighbours = adjacencyList[node];
                foreach (var neighbour in neighbours)
                {
                    indegrees[neighbour]++;
                }
            }

            return indegrees;
        }

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph dag = new();
            int[][] directedEdgeList = new int[][]
            {
                new int[]{0, 1},
                new int[]{1, 4},
                new int[]{1, 3},
                new int[]{2, 1},
                new int[]{2, 3},
            };

            dag.CreateDirectedGraph(directedEdgeList);
            dag.ShowAdjacencyList();

            dag.DFSIterative(3);

            Console.WriteLine();
            Console.Write("DFSRecursive: ");
            dag.DFSRecursive(3, new());



            Console.WriteLine();
            dag.TopologicalSortDFS();

            Console.WriteLine();
            dag.TopologicalSortBFS();

            Graph ug = new();
            int[][] undirectedEdgeList = new int[][]
            {
                new int[]{0, 1},
                new int[]{1, 4},
                new int[]{1, 2},
                new int[]{2, 3},
            };

            ug.CreateUndirectedGraph(undirectedEdgeList);
            ug.ShowAdjacencyList();

            Console.WriteLine();
            ug.BFSIterative(3);

            Console.WriteLine();
            Console.Write("BFSRecursive: ");
            Queue<int> queue = new();
            queue.Enqueue(3);
            ug.BFSRecursive(new(), queue);
        }
    }
}
