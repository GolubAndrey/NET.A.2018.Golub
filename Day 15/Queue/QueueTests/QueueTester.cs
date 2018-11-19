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
            => new QueueT<int>(0));
        
        [Test]
        public void QueueTest_Adding3Elements_QueueHas3Element()
        {
            QueueT<int> qeue = new QueueT<int>(1);

            qeue.Enqueue(1);
            qeue.Enqueue(3);
            qeue.Enqueue(3);

            Assert.AreEqual(3, qeue.Count());
        }

        [Test]
        public void QueueTest_CreatingQueueWith3Elements_QueueHas3Element()
        {
            QueueT<string> qeue = new QueueT<string>(new List<string> { "asd", "asd","aaa" });
            
            Assert.AreEqual(3, qeue.Count());
        }

        [Test]
        public void QueueTest_Add2ElementsAndTake1_QueueHas1Element()
        {
            QueueT<CastomForTest2> queue =
                new QueueT<CastomForTest2>(new List<CastomForTest2> { new CastomForTest2(1),
                    new CastomForTest2(2) });

            queue.Dequeue();

            Assert.AreEqual(1, queue.Count());
        }

        [Test]
        public void QueueTest_QueueWith1ElementAndDelete2_InvalideOperationException()
        {
            QueueT<CastomForTest> queue = new QueueT<CastomForTest>(1);
            queue.Enqueue(new CastomForTest(1));
            queue.Dequeue();

            Assert.Throws<InvalidOperationException>(()=>queue.Dequeue());
        }

        [Test]
        public void GetQueueEnumerator_TwoStepsAhead_GetCurrentElement_CurrentElementEqual2AddingElementInQueue()
        {
            QueueT<string> queue = new QueueT<string>(new List<string> { "a", "ab", "abc", "abcd" });
            var enumerator = queue.GetEnumerator();

            enumerator.MoveNext();
            enumerator.MoveNext();

            Assert.AreEqual("ab",enumerator.Current);
        }

        [Test]
        public void IsEmptyTest()
        {
            QueueT<CastomForTest> queue = new QueueT<CastomForTest>(1);

            Assert.IsTrue(queue.IsEmpty());
        }

        [Test]
        public void GetPeekOfEmptyQueue_InvalidOperationException()
        {
            QueueT<CastomForTest> queue = new QueueT<CastomForTest>(1);

            Assert.Throws<InvalidOperationException>(()=>queue.Peek());
        }

        [Test]
        public void GetPeekOfQueue_FirstElementInQueue()
        {
            QueueT<CastomForTest> queue = new QueueT<CastomForTest>(1);
            queue.Enqueue(new CastomForTest(1));

            Assert.AreEqual(new CastomForTest(1), queue.Peek());
        }

    }
}
