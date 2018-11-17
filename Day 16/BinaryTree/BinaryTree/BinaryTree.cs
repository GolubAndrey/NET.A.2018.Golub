using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T>
    {
        /// <summary>
        /// Number of nodes
        /// </summary>
        public int Counter { get; private set; }

        #region private fields
        private readonly Comparer<T> _comparer;
        private TreeNode<T> _root;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor of binary tree
        /// </summary>
        /// <param name="elements">IEnumerables elements</param>
        /// <exception cref="ArgumentNullException">Throws when one of parameters is null</exception>
        /// <param name="comparer">Comparer for nodes comparisons</param>
        public BinaryTree(IEnumerable<T> elements, Comparer<T> comparer)
        {
            if (ReferenceEquals(elements,null))
            {
                throw new ArgumentNullException($"{nameof(elements)} can't be null");
            }
            if (ReferenceEquals(comparer, null))
            {
                throw new ArgumentNullException($"{nameof(comparer)} can't be null");
            }
            _comparer = comparer;
            foreach(var el in elements)
            {
                this.Add(el);
            }
        }

        /// <summary>
        /// Constructor for binary tree
        /// </summary>
        /// <param name="elements">IEnumerable elements</param>
        public BinaryTree(IEnumerable<T> elements) : this(elements, Comparer<T>.Default) {}

        /// <summary>
        /// Constructor for binary tree
        /// </summary>
        /// <exception cref="ArgumentNullException">Throws when comparer is null</exception>
        /// <param name="comparer">Comparer for nodes comparisons</param>
        public BinaryTree(Comparer<T> comparer) =>
            _comparer = comparer ?? throw new ArgumentNullException($"{nameof(comparer)} can't be null");

        /// <summary>
        /// Constructor for binary tree
        /// </summary>
        public BinaryTree() : this(Comparer<T>.Default) { }

        #endregion

        #region Binary Tree Operations
        /// <summary>
        /// Add data in tree
        /// </summary>
        /// <exception cref="ArgumentNullException">Throws when data is null</exception>
        /// <exception cref="InvalidOperationException">Throws when such an element is already in the tree</exception>
        /// <param name="data">Data for adding</param>
        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException($"{nameof(data)} can't be null");
            }
            if (_root == null)
            {
                _root = new TreeNode<T>(data);
                return;
            }
            if (IsExists(data))
            {
                throw new InvalidOperationException($"{nameof(data)} already in the tree");
            }
            TreeNode<T> walker;
            walker = _root;
            while (walker != null)
            {
                if (_comparer.Compare(data,walker.Data)>0)
                {
                    if (walker.RightNode==null)
                    {
                        walker.RightNode = new TreeNode<T>(data);
                        return;
                    }
                    walker = walker.RightNode;

                }
                else
                {
                    if (walker.LeftNode == null)
                    {
                        walker.LeftNode = new TreeNode<T>(data);
                        return;
                    }
                    walker = walker.LeftNode;
                }
            }
            _root = new TreeNode<T>(data);
            _root = walker;
            Counter++;
        }

        /// <summary>
        /// Delete element from tree
        /// </summary>
        /// <exception cref="ArgumentNullException">Throws when data is null</exception>
        /// <exception cref="InvalidOperationException">Throws when there is no such element in the tree</exception>
        /// <param name="data">Data of deleting element</param>
        public void Delete(T data)
        {
            if (data==null)
            {
                throw new ArgumentNullException($"{nameof(data)} can't be null");
            }
            if (!IsExists(data))
            {
                throw new InvalidOperationException($"No {nameof(data)} in the tree");
            }
            
            TreeNode<T> walker=_root;
            TreeNode<T> previous=walker;
            while (_comparer.Compare(walker.Data, data) != 0)
            {
                previous = walker;
                walker = _comparer.Compare(walker.Data, data) > 0 ? walker.LeftNode : walker.RightNode;
            }
            if (walker.RightNode==null)
            {
                previous.LeftNode = null;
                return;
            }
            if (walker.LeftNode == null)
            {
                previous.LeftNode = null;
                return;
            }
            walker = walker.LeftNode;
            TreeNode<T> previous2 = walker;
            while(walker.RightNode!=null)
            {
                previous2 = walker;
                walker = walker.RightNode;
            }
            TreeNode<T> tempNode = previous.RightNode;
            previous.RightNode = walker;
            previous2.RightNode = walker.LeftNode != null ? walker.LeftNode : null;
            walker.LeftNode = tempNode.LeftNode;
            walker.RightNode = tempNode.RightNode;
        }

        /// <summary>
        /// Сhecks for an element in a tree
        /// </summary>
        /// <param name="data">Element to search</param>
        /// <returns>True - if found, otherwise - false</returns>
        public bool IsExists(T data)
        {
            if (_root == null)
            {
                return false;
            }
            TreeNode<T> walker =_root;
            while (_comparer.Compare(walker.Data, data) != 0)
            {
                walker = _comparer.Compare(data,walker.Data) > 0 ? walker.RightNode:walker.LeftNode;
                if (walker == null)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region public Bypasses
        /// <summary>
        /// Direct tree bypasse
        /// </summary>
        /// <returns>Sequence of bypasses elements</returns>
        public IEnumerable<T> DirectBypass()
        {
            return DirectBypass(_root);
        }

        /// <summary>
        /// Symmetrical tree bypasse
        /// </summary>
        /// <returns>Sequence of bypasses elements</returns>
        public IEnumerable<T> SymmetricalBypass()
        {
            return SymmetricalBypass(_root);
        }

        /// <summary>
        /// Reverse tree bypasse
        /// </summary>
        /// <returns>Sequence of bypasses elements</returns>
        public IEnumerable<T> ReverseBypass()
        {
            return ReverseBypass(_root);
        }
        #endregion

        #region private Bypasses
        private IEnumerable<T> DirectBypass(TreeNode<T> node)
        {
            yield return node.Data;

            if (node.LeftNode != null)
            {
                foreach (var value in DirectBypass(node.LeftNode))
                {
                    yield return value;
                }
            }
            if (node.RightNode!=null)
            {
                foreach(var value in DirectBypass(node.RightNode))
                {
                    yield return value;
                }
            }
        }

        private IEnumerable<T> SymmetricalBypass(TreeNode<T> node)
        {
            if (node.LeftNode != null)
            {
                foreach (var value in SymmetricalBypass(node.LeftNode))
                {
                    yield return value;
                }
            }

            yield return node.Data;

            if (node.RightNode != null)
            {
                foreach (var value in SymmetricalBypass(node.RightNode))
                {
                    yield return value;
                }
            }
        }

        private IEnumerable<T> ReverseBypass(TreeNode<T> node)
        {
            if (node.LeftNode != null)
            {
                foreach (var value in ReverseBypass(node.LeftNode))
                {
                    yield return value;
                }
            }
            
            if (node.RightNode != null)
            {
                foreach (var value in ReverseBypass(node.RightNode))
                {
                    yield return value;
                }
            }

            yield return node.Data;
        }
        #endregion
        

        #region Enumerator
        /// <summary>
        /// Get enumerator
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return DirectBypass().GetEnumerator();
        }
        

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
    }

}
