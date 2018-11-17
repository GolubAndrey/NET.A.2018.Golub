using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T>
    {
        public int Counter { get; private set; }

        private readonly Comparer<T> _comparer;
        private TreeNode<T> _root


        #region .Ctors
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

        public BinaryTree(IEnumerable<T> elements) : this(elements, Comparer<T>.Default) {}

        public BinaryTree(Comparer<T> comparer) =>
            _comparer = comparer ?? throw new ArgumentNullException($"{nameof(comparer)} can't be null");

        public BinaryTree() : this(Comparer<T>.Default) { }

        #endregion

        public void Add(T data)
        {
            if (_root == null)
            {
                _root = new TreeNode<T>(data);
            }
            if (IsExists(data))
            {
                throw new InvalidOperationException($"{nameof(data)} already in the tree");
            }
            TreeNode<T> walker = new TreeNode<T>();
            walker = _root;
            while (walker!=null)
            {
                if (_comparer.Compare(data,walker.Data)>0)
                {
                    walker = walker.LeftNode;
                }
                else
                {
                    walker = walker.RightNode;
                }
            }
            walker = new TreeNode<T>(data);

        }

        public bool IsExists(T data)
        {
            if (_root == null)
            {
                return false;
            }
            TreeNode<T> walker = new TreeNode<T>();
            walker = _root;
            while (_comparer.Compare(walker.Data, data) != 0)
            {
                if (walker == null)
                {
                    return false;
                }
                walker = _comparer.Compare(walker.Data, data) > 0 ? walker.LeftNode : walker.RightNode;
            }
            return true;
        }
        #region public Bypasses
        public IEnumerable<T> DirectBypass()
        {
            return DirectBypass(_root);
        }

        public IEnumerable<T> SymmetricalBypass()
        {
            return SymmetricalBypass(_root);
        }

        public IEnumerable<T> ReverseBypass()
        {
            return ReverseBypass(_root);
        }
        #endregion

        #region private Bypasses
        private IEnumerable<T> DirectBypass(TreeNode<T> node)
        {
            if (node==null)
            {
                yield break;
            }
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

            if (node == null)
            {
                yield break;
            }

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

            if (node == null)
            {
                yield break;
            }
        }
        #endregion
        

        #region Enumerator
        public IEnumerator<T> GetEnumerator()
        {
            return DirectBypass().GetEnumerator();
        }
        

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
    }

}
