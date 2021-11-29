using System;
using Xunit;

namespace DelegateDemystification.Tests
{
    public class SubjectTests
    {
        [Fact]
        public void SubjectWithoutObserversAreNull()
        {
            ISubject SampleNullSubject = default;
            Assert.Null(SampleNullSubject);
        }

        static void Void() { }
        
        [Fact]
        public void NullSubjectAddingLambda_SubscriberReturnsNonNull()
        {
            ISubject SampleNullSubject = default;
            SampleNullSubject += () => Void();
            Assert.NotNull(SampleNullSubject);
        }

        [Fact]
        public void NullSubjectAddingMethod_SubscriberReturnsNonNull()
        {
            ISubject SampleNullSubject = default;
            SampleNullSubject += Void;
            Assert.NotNull(SampleNullSubject);
        }

        [Fact]
        public void RemovingAllSubscribersIsNull()
        {
            ISubject SampleNullSubject = default;
            SampleNullSubject += Void;
            SampleNullSubject -= Void;
            Assert.Null(SampleNullSubject);
        }

        [Fact]
        public void ValueSemanticsForSubscription()
        {
            ISubject SampleNullSubject = default;
            SampleNullSubject += Void;
            var oldValue = SampleNullSubject;
            SampleNullSubject -= Void;
            Assert.Multiple(
                () => Assert.NotNull(oldValue),
                () => Assert.Null(SampleNullSubject)
                );
        }

        [Fact]
        public void CombineSubjectWithNullSubject()
        {
            ISubject NullSubject = default;
            ISubject SomeSubject = default;
            SomeSubject += Void;
            ISubject oldValue = SomeSubject;
            SomeSubject += NullSubject;
            Assert.Equal(oldValue, SomeSubject);
        }

        [Fact]
        public void MultiSubjectEquality()
        {
            Subject sa;
            sa += (Action)Void;
        }
    }
}
