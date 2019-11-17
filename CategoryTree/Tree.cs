using System;

namespace CategoryTree
{
    /// <summary> Represents a tree data structure </summary>
    /// <typeparam name="T"> the type of the values in the tree </typeparam>
    internal class Tree<T>
    {
        /// <summary> The root node or null if the tree is empty </summary>
        public TreeNode<T> Root { get; }

        /// <summary> Constructs the tree </summary>
        /// <param name="value"> the value of the node </param>
        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }
            Root = new TreeNode<T>(value);
        }

        /// <summary> Constructs the tree </summary>
        /// <param name="value"> the value of the root node </param>
        /// <param name="children"> the children of the root node </param>
        public Tree(T value, params Tree<T>[] children) : this(value)
        {
            foreach (Tree<T> child in children)
            {
                Root.AddChild(child.Root);
            }
        }

        /// <summary>Traverses and prints tree in Depth-First Search (DFS) manner</summary>
        /// <param name="root">the root of the tree to be traversed</param>
        /// <param name="spaces">the spaces used for representation of the parent-child relation</param>
        private void PrintDFS(TreeNode<T> root, string spaces)
        {
            if (Root == null)
            {
                return;
            }

            Console.WriteLine(spaces + root.Value);

            TreeNode<T> child = null;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                PrintDFS(child, spaces + "   ");
            }
        }

        /// <summary> Traverses and prints the tree in Depth-First Search (DFS) manner </summary>
        public void TraverseDFS()
        {
            PrintDFS(Root, string.Empty);
        }
    }
}