using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinaryTree;

namespace BinaryTreeTests
{
    [TestFixture]
    public class BinaryTreeTester
    {
        [Test]
        public void CreateTree_NullComparer_NullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BinaryTree<string>(new List<string>(), null));
        }

        [Test]
        public void CreateTree_NullIEnumerable_NullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BinaryTree<string>(null, Comparer<string>.Default));
        }

        [Test]
        public void AddElementInTree_3ElementTreeAndAdd1Element_TreeOn4Elements()
        {
            BinaryTree<int> binTree = new BinaryTree<int>(new List<int> { 1, 2, 3 });
            binTree.Add(5);
            Assert.AreEqual(binTree, new BinaryTree<int>(new List<int> { 1, 2, 3, 5 }));
        }

        [Test]
        public void DeleteElementFromTree_TreeWith11ElementAndDelete1Element()
        {
            BinaryTree<int> binTree = new BinaryTree<int>(new List<int> { 100, 20,15,50,120,30,24,35,33,55,60 });
            binTree.Delete(50);
            Assert.AreEqual(binTree, new BinaryTree<int>(new List<int> { 100, 20, 15, 120, 35, 30,24, 33, 55, 60 }));
        }

        [TestCase(new int[] { 10, 12, 11 },10,ExpectedResult =true)]
        [TestCase(new int[] { 10, 12, 11 }, 9, ExpectedResult = false)]
        public bool IsExistsTests_CorrectWork(IEnumerable<int> list,int element)
        {
            return new BinaryTree<int>(list).IsExists(element);
        }

        [Test]
        public void Bypasses_ValidArgumentsString()
        {
            BinaryTree<string> tree=new BinaryTree<string>(new string[] { "5", "4", "1", "7", "6", "9", "8" });
            string[] direct = new string[7] {"5", "4", "1", "7", "6", "9", "8"};
            string[] symmetrical = new string[7] { "1", "4", "5", "6", "7", "8", "9" };
            string[] reverce = new string[7] { "1", "4", "6", "8", "9", "7", "5" };
            
            Assert.AreEqual(direct, tree.DirectBypass());
            Assert.AreEqual(symmetrical, tree.SymmetricalBypass());
            Assert.AreEqual(reverce, tree.ReverseBypass());
        }

        [Test]
        public void DirectBypesse_ValidArgumentsBook()
        {
            BinaryTree<BookTestsClass> books = new BinaryTree<BookTestsClass>(new BookTestsClass[] { new BookTestsClass(5), new BookTestsClass(3), new BookTestsClass(4) });
            BookTestsClass[] direct = new BookTestsClass[3] { new BookTestsClass(5), new BookTestsClass(3), new BookTestsClass(4) };

            Assert.AreEqual(direct, books.DirectBypass());
        }

        [Test]
        public void SymmetricalBypesse_ValidArgumentsBook()
        {
            Comparer<PointTestsStruct> comparer = new PointComparer();
            BinaryTree<PointTestsStruct> points = new BinaryTree<PointTestsStruct>(new PointTestsStruct[] { new PointTestsStruct(5,5),new PointTestsStruct(3,3),new PointTestsStruct(4,4)},comparer);
        }

    }
}
