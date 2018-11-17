using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class TreeNode<T>
    {
        internal T Data { get; set; }
        internal TreeNode<T> LeftNode { get; set; }
        internal TreeNode<T> RightNode { get; set; }
        
        /// <summary>
        /// Constructor of tree node
        /// </summary>
        /// <param name="data">Data of node</param>
        public TreeNode(T data)
        {
            Data = data;
            LeftNode = null;
            RightNode = null;
        }


        public TreeNode() { }
    }
}
