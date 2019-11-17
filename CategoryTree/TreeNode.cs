using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryTree
{
    /// <summary>Represents a tree node</summary>
    /// <typeparam name="T">the type of the values in nodes </typeparam>
    internal class TreeNode<T>
    {
        // Shows whether the current node has a parent or not
        private bool hasParent;

        // Contains the children of the node (zero or more)
        private List<TreeNode<T>> children;

        /// <summary>The value of the node</summary>
        public T Value { get; set; }

        /// <summary>The number of node's children</summary>
        public int ChildrenCount { get { return children.Count; } }

        /// <summary>Constructs a tree node</summary>
        /// <param name="value">the value of the node</param>
        public TreeNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }
            Value = value;
            children = new List<TreeNode<T>>();
        }

        /// <summary>Adds child to the node</summary>
        /// <param name="child">the child to be added</param>
        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            if (child.hasParent)
            {
                throw new ArgumentException("The node already has a parent!");
            }

            child.hasParent = true;
            children.Add(child);
        }

        /// <summary> Gets the child of the node at given index </summary>
        /// <param name="index">the index of the desired child</param>
        /// <returns>the child on the given position</returns>
        public TreeNode<T> GetChild(int index)
        {
            return children[index];
        }
    }
}