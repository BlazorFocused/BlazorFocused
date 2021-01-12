﻿using BlazorFocused.Core.Test.Model;
using FluentAssertions;
using Xunit;

namespace BlazorFocused.Store
{
    public partial class StoreTests
    {
        [Fact(DisplayName = "Should Store and Return Initial Value")]
        public void ShouldStoreAndReturnInitialValue()
        {
            SimpleClass inputSimpleClass = SimpleClassUtilities.GetRandomSimpleClass();
            SimpleClass expectedSimpleClass = inputSimpleClass;

            var store = new Store<SimpleClass>(inputSimpleClass);

            SimpleClass actualSimpleClass = store.GetState();

            actualSimpleClass.Should().BeEquivalentTo(expectedSimpleClass);
        }

        [Fact(DisplayName = "Should Return 'null' when initialized as null")]
        public void ShouldReturnNullWhenInitializedAsNull()
        {
            var store = new Store<SimpleClass>(null);

            SimpleClass actualSimpleClass = store.GetState();

            actualSimpleClass.Should().BeNull();
        }
    }
}