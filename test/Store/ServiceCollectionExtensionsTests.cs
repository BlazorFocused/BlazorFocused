﻿using BlazorFocused.Test.Model;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorFocused.Store.Test
{
    public class ServiceCollectionExtensionsTests
    {
        [Fact(DisplayName = "Should register store with initial state")]
        public void ShouldRegisterStore()
        {
            var simpleClass = new SimpleClass { FieldOne = "Test" };
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddStore(simpleClass);
            var provider = serviceCollection.BuildServiceProvider();

            var store = provider.GetRequiredService<IStore<SimpleClass>>();

            Assert.NotNull(store);
            Assert.Equal(simpleClass.FieldOne, store.GetState().FieldOne);
        }
    }
}
