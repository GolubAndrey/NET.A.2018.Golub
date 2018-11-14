using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Queue;

namespace QueueTests
{
    [TestFixture]
    public class QueueTester
    {
        [Test]
        public void QueueTest_InvalidCreatingQueue() =>Assert.Throws<ArgumentException>(() 
            => new QueueRealisation<int>(0));
        
        [Test]
        public void QueueTest_Adding3Elements_QueueHas3Element()
        {
            QueueRealisation<int> qeue = new QueueRealisation<int>(1);

            qeue.Insert(1);
            qeue.Insert(3);
            qeue.Insert(3);

            Assert.AreEqual(3, qeue.Count());
        }

        [Test]
        public void QueueTest_CreatingQueueWith3Elements_QueueHas3Element()
        {
            QueueRealisation<string> qeue = new QueueRealisation<string>(new List<string> { "asd", "asd","aaa" });
            
            Assert.AreEqual(3, qeue.Count());
        }

        [Test]
        public void QueueTest_Add2ElementsAndTake1_QueueHas1Element()
        {
            QueueRealisation<CastomForTest2> queue =
                new QueueRealisation<CastomForTest2>(new List<CastomForTest2> { new CastomForTest2(1),
                    new CastomForTest2(2) });

            queue.Delete();

            Assert.AreEqual(1, queue.Count());
        }

        [Test]
        public void QueueTest_QueueWith1ElementAndDelete2_InvalideOperationException()
        {
            QueueRealisation<CastomForTest> queue = new QueueRealisation<CastomForTest>(1);
            queue.Insert(new CastomForTest(1));
            queue.Delete();

            Assert.Throws<InvalidOperationException>(()=>queue.Delete());
        }

        [Test]
        public void GetQueueEnumerator_TwoStepsAhead_GetCurrentElement_CurrentElementEqual2AddingElementInQueue()
        {
            QueueRealisation<string> queue = new QueueRealisation<string>(new List<string> { "a", "ab", "abc", "abcd" });
            var enumerator = queue.GetEnumerator();

            enumerator.MoveNext();
            enumerator.MoveNext();

            Assert.AreEqual("ab",enumerator.Current);
        }

        [Test]
        public void IsEmptyTest()
        {
            QueueRealisation<CastomForTest> queue = new QueueRealisation<CastomForTest>(1);

            Assert.IsTrue(queue.IsEmpty());
        }

        [Test]
        public void IsFullTest()
        {
            QueueRealisation<CastomForTest> queue = new QueueRealisation<CastomForTest>(1);
            queue.Insert(new CastomForTest(1));

            Assert.IsTrue(queue.isFull());
        }

        [Test]
        public void GetPeekOfEmptyQueue_InvalidOperationException()
        {
            QueueRealisation<CastomForTest> queue = new QueueRealisation<CastomForTest>(1);

            Assert.Throws<InvalidOperationException>(()=>queue.Peek());
        }

        [Test]
        public void GetPeekOfQueue_FirstElementInQueue()
        {
            QueueRealisation<CastomForTest> queue = new QueueRealisation<CastomForTest>(1);
            queue.Insert(new CastomForTest(1));

            Assert.AreEqual(new CastomForTest(1), queue.Peek());
        }

    }
}
