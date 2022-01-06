using System;
using System.Collections.Generic;

namespace Binary_Search_Trees
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
    }

    class BinarySearchTree
    {
        Node root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        public Node GetRoot()
        {
            return this.root;
        }

        public void Insert(int value)
        {
            Node newNode = new Node(value);

            if (root == null)
            {
                root = newNode;
                return;
            }

            Node current = root;

            while (true)
            {
                if (value < current.value)
                {
                    if (current.left == null)
                    {
                        current.left = newNode;
                        return;
                    }
                    current = current.left;
                }
                else
                {
                    if (current.right == null)
                    {
                        current.right = newNode;
                        return;
                    }
                    current = current.right;
                }
            }
        }

        public Node Lookup(int value)
        {
            if (root == null)
                return null;

            Node current = root;

            while (current != null)
            {
                if (value == current.value)
                {
                    return current;
                }
                else if (value < current.value)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }

            return null;
        }

        public void Remove(int value)
        {

        }

        #region BreadthFirstSearch
        public IList<int> BreadthFirstSearch()
        {
            Node current = this.root;
            Queue<Node> queue = new Queue<Node>();
            List<int> bfsOrder = new List<int>();

            queue.Enqueue(current);

            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                bfsOrder.Add(current.value);

                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }
            }

            return bfsOrder;
        }

        public IList<int> BreadthFirstSearchRecursive(Queue<Node> queue, IList<int> bfsOrder)
        {
            if (queue.Count == 0)
            {
                return bfsOrder;
            }

            Node current = queue.Dequeue();
            bfsOrder.Add(current.value);

            if (current.left != null)
            {
                queue.Enqueue(current.left);
            }

            if (current.right != null)
            {
                queue.Enqueue(current.right);
            }

            return BreadthFirstSearchRecursive(queue, bfsOrder);
        }
        #endregion

        #region DepthFirstSearch - In-order Traversal
        public IList<int> DepthFirstSearchInOrderTraversal()
        {
            return InOrderTraversal(root, new List<int>());
        }

        private IList<int> InOrderTraversal(Node node, IList<int> inOrderList)
        {
            if (node.left != null)
            {
                InOrderTraversal(node.left, inOrderList);
            }

            inOrderList.Add(node.value);

            if (node.right != null)
            {
                InOrderTraversal(node.right, inOrderList);
            }

            return inOrderList;
        }

        public IList<int> DepthFirstSearchInOrderTraversalIterative()
        {
            List<int> inOrderList = new List<int>();
            Stack<Node> stack = new Stack<Node>();
            Node current = root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                current = stack.Pop();
                inOrderList.Add(current.value);
                current = current.right;
            }

            return inOrderList;
        }

        public IList<int> DepthFirstSearchMorrisInOrderTraversalIterative()
        {
            List<int> inOrderList = new List<int>();
            Node current = root;
            Node predecessor = null;

            while (current != null)
            {
                if (current.left != null)
                {
                    predecessor = current.left;

                    while (predecessor.right != null && predecessor.right != current)
                    {
                        predecessor = predecessor.right;
                    }

                    if (predecessor.right == null)
                    {
                        predecessor.right = current;
                        current = current.left;
                    }
                    else
                    {
                        predecessor.right = null;
                        inOrderList.Add(current.value);
                        current = current.right;
                    }
                }
                else
                {
                    inOrderList.Add(current.value);
                    current = current.right;
                }
            }

            return inOrderList;
        }
        #endregion

        #region DepthFirstSearch - Pre-order Traversal
        public IList<int> DepthFirstSearchPreOrderTraversal()
        {
            return PreOrderTraversal(root, new List<int>());
        }

        private IList<int> PreOrderTraversal(Node node, IList<int> preOrderList)
        {
            preOrderList.Add(node.value);

            if (node.left != null)
            {
                PreOrderTraversal(node.left, preOrderList);
            }

            if (node.right != null)
            {
                PreOrderTraversal(node.right, preOrderList);
            }

            return preOrderList;
        }

        public IList<int> DepthFirstSearchPreOrderTraversalIterative()
        {
            List<int> preOrderList = new List<int>();
            Stack<Node> stack = new Stack<Node>();
            Node current = root;

            stack.Push(current);

            while (stack.Count > 0)
            {
                current = stack.Pop();
                preOrderList.Add(current.value);

                if (current.right != null)
                {
                    stack.Push(current.right);
                }

                if (current.left != null)
                {
                    stack.Push(current.left);
                }
            }

            return preOrderList;
        }

        public IList<int> DepthFirstSearchMorrisPreOrderTraversalIterative()
        {
            List<int> preOrderList = new List<int>();
            Node current = root;
            Node predecessor = null;

            while (current != null)
            {
                if (current.left != null)
                {
                    predecessor = current.left;

                    while (predecessor.right != null && predecessor.right != current)
                    {
                        predecessor = predecessor.right;
                    }

                    if (predecessor.right == null)
                    {
                        predecessor.right = current;
                        preOrderList.Add(current.value);
                        current = current.left;
                    }
                    else
                    {
                        predecessor.right = null;
                        current = current.right;
                    }
                }
                else
                {
                    preOrderList.Add(current.value);
                    current = current.right;
                }
            }

            return preOrderList;
        }
        #endregion

        #region DepthFirstSearch - Post-order Traversal
        public IList<int> DepthFirstSearchPostOrderTraversal()
        {
            return PostOrderTraversal(root, new List<int>());
        }

        private IList<int> PostOrderTraversal(Node node, IList<int> postOrderList)
        {
            if (node.left != null)
            {
                PostOrderTraversal(node.left, postOrderList);
            }

            if (node.right != null)
            {
                PostOrderTraversal(node.right, postOrderList);
            }

            postOrderList.Add(node.value);

            return postOrderList;
        }

        public IList<int> DepthFirstSearchPostOrderTraversalIterative()
        {
            List<int> postOrderList = new List<int>();
            Stack<Node> stack = new Stack<Node>();
            Node current = root;

            stack.Push(current);

            while (stack.Count > 0)
            {
                current = stack.Pop();
                postOrderList.Add(current.value);

                if (current.left != null)
                {
                    stack.Push(current.left);
                }

                if (current.right != null)
                {
                    stack.Push(current.right);
                }
            }

            postOrderList.Reverse();
            return postOrderList;
        }

        public IList<int> DepthFirstSearchPostOrderTraversalIterativeWithoutReversing()
        {
            List<int> postOrderList = new List<int>();
            Stack<Node> stack = new Stack<Node>();

            Node current = root;
            Node temp = null;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                temp = stack.Peek().right;

                if (temp == null)
                {
                    temp = stack.Pop();
                    postOrderList.Add(temp.value);

                    while (stack.Count > 0 && temp == stack.Peek().right)
                    {
                        temp = stack.Pop();
                        postOrderList.Add(temp.value);
                    }
                }
                else
                {
                    current = temp;
                }
            }

            return postOrderList;
        }
        #endregion
    }


    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.Insert(50);
            bst.Insert(25);
            bst.Insert(75);
            bst.Insert(10);
            bst.Insert(35);
            bst.Insert(65);
            bst.Insert(100);
            bst.Insert(15);
            bst.Insert(11);

            var queue = new Queue<Node>();
            queue.Enqueue(bst.GetRoot());
            var traversalrecursive = bst.DepthFirstSearchMorrisPreOrderTraversalIterative();

            foreach (var item in traversalrecursive)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
