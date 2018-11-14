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
            QueueRealisation<string> queue = new QueueRealisation<string>(new List<string> { "asd", "asd" });

            queue.Delete();

            Assert.AreEqual(1, queue.Count());
        }

        [Test]
        public void QueueTest_QueueWith1ElementAndDelete2_InvalideOperationException()
        {
            QueueRealisation<string> queue = new QueueRealisation<string>(1);
            queue.Insert("aa");
            queue.Delete();

            Assert.Throws<InvalidOperationException>(()=>queue.Delete());
        }

        [Test]
        public void GetQueueEnumerator_TwoStepsAhead_GetCurrentElement_CurrentElementEqual2AddingElementInQueue()
        {
            QueueRealisation<string> queue = new QueueRealisation<string>(new List<string> { "a", "ab", "abc","abcd" });

            var enumerator = queue.GetEnumerator();

            enumerator.MoveNext();
            enumerator.MoveNext();

            Assert.AreEqual("ab", enumerator.Current);
        }
            
    }
}
