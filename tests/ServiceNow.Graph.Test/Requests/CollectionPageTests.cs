using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceNow.Graph.Requests;
using Xunit;

namespace ServiceNow.Graph.Test.Requests
{
    public class CollectionPageTests
    {
        private CollectionPage<String> collectionPage;

        public CollectionPageTests()
        {
            this.collectionPage = new CollectionPage<string>();
        }

        [Fact]
        public void initializeWithList()
        {
            List<String> elements = new List<string>();
            CollectionPage<String> newCollectionPage = new CollectionPage<string>(elements);
            Assert.Same(elements, newCollectionPage.CurrentPage);
        }

        [Fact]
        public void indexOfReturnsCorrectIndex()
        {
            collectionPage.Add("E1");
            collectionPage.Add("E2");
            collectionPage.Add("E3");

            Assert.Equal(1, collectionPage.IndexOf("E2"));
        }

        [Fact]
        public void addString()
        {
            collectionPage.Add("E1");
            
            Assert.Single(collectionPage);
            Assert.Equal("E1", collectionPage[0]);
        }

        [Fact]
        public void insertInsertsAtCorrectLocation()
        {
            collectionPage.Add("E1");
            collectionPage.Insert(0, "E0");

            Assert.Equal(2, collectionPage.Count);
            Assert.Equal("E0", collectionPage[0]);
        }

        [Fact]
        public void removeAtRemovesStringAtCorrectLocation()
        {
            collectionPage.Add("E1");
            collectionPage.Add("E2");
            collectionPage.Add("E3");

            collectionPage.RemoveAt(1);

            Assert.Equal("E1", collectionPage[0]);
            Assert.Equal("E3", collectionPage[1]);
            Assert.Equal(2, collectionPage.Count);
        }

        [Fact]
        public void clearProperlyClearsPage()
        {
            collectionPage.Add("E1");
            collectionPage.Add("E2");

            collectionPage.Clear();

            Assert.Empty(collectionPage);
        }

        [Fact]
        public void containsExistingItem()
        {
            collectionPage.Add("E1");
            collectionPage.Add("E2");

            Assert.Contains("E2", collectionPage);
        }

        [Fact]
        public void copyToExistingArray()
        {
            string[] existingArray = new string[] { "D1", "D2", "D3" };
            collectionPage.Add("E1");
            collectionPage.Add("E2");
            string[] expectedArray = new string[] { "D1", "E1", "E2" };

            collectionPage.CopyTo(existingArray, 1);

            Assert.Equal(expectedArray, existingArray);
        }

        [Fact]
        public void removeRemovesItem()
        {
            collectionPage.Add("E1");
            collectionPage.Add("E2");
            collectionPage.Add("E3");
            string[] expectedArray = new string[] { "E1", "E2" };

            collectionPage.Remove("E3");

            Assert.Equal(expectedArray, collectionPage);
        }

        [Fact]
        public void enumeratorEnumeratesOverItems()
        {
            collectionPage.Add("E1");
            collectionPage.Add("E2");
            collectionPage.Add("E3");
            IEnumerator<String> iterator = collectionPage.GetEnumerator();

            iterator.MoveNext();
            Assert.Equal("E1", (String)iterator.Current);
            iterator.MoveNext();
            Assert.Equal("E2", (String)iterator.Current);
            iterator.MoveNext();
            Assert.Equal("E3", (String)iterator.Current);
        }
    }
}
