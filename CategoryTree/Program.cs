using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CategoryTree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<string[]> categories = ReadCsv(@".\categories.csv", ";");
            categories.RemoveAt(0); // Remove header

            Tree<string> testTree = new Tree<string>("Категории");

            foreach (string[] row in categories)
            {
                BuildTree(row, testTree.Root, 0);
            }
            testTree.TraverseDFS(); // Print tree in console

            Console.ReadKey();
        }

        /// <summary>
        /// Reads the csv file and returns a list of arrays. Each array is 1 row
        /// </summary>
        /// <param name="filePath"> Path to .csv file </param>
        /// <param name="delimeter"> separator of elements in a row </param>
        /// <returns></returns>
        private static List<string[]> ReadCsv(string filePath, string delimeter)
        {
            List<string[]> result = new List<string[]>();

            using (TextFieldParser parser = new TextFieldParser(filePath, Encoding.GetEncoding("Windows-1251")))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(delimeter);
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields().Where(x => !string.IsNullOrEmpty(x.Trim())).ToArray(); //clear the array of empty lines
                    result.Add(fields);
                }
            }

            return result;
        }

        /// <summary>
        /// Builds a tree from a given array of strings
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="node"></param>
        /// <param name="deep"></param>
        private static void BuildTree(string[] arr, TreeNode<string> node, int deep)
        {
            if (deep >= arr.Length)
            {
                return;
            }
            int childId = FindChild(node, arr[deep]);

            if (childId >= 0)
            {
                BuildTree(arr, node.GetChild(childId), ++deep);
            }
            else
            {
                TreeNode<string> newChild = new TreeNode<string>(arr[deep]);
                node.AddChild(newChild);
                BuildTree(arr, newChild, ++deep);
            }
        }

        /// <summary>
        /// Search for a child node. Returns the index of the found node or -1.
        /// </summary>
        /// <param name="node"> Search Node </param>
        /// <param name="value"> Index of found node </param>
        /// <returns></returns>
        private static int FindChild(TreeNode<string> node, string value)
        {
            int result = -1;

            for (int i = 0; i < node.ChildrenCount; i++)
            {
                if (node.Childrens[i].Value == value)
                {
                    return i;
                }
            }
            return result;
        }
    }
}