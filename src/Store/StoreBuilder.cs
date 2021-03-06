﻿using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorFocused.Store
{
    /// <inheritdoc cref="IStoreBuilder{TState}"/>
    internal class StoreBuilder<TState> : IStoreBuilder<TState> where TState : class
    {
        public TState InitialState { get; private set; }

        private readonly ServiceCollection serviceCollection;

        public StoreBuilder()
        {
            InitialState = default;
            serviceCollection = new ServiceCollection();
        }

        public void RegisterAction<TAction>()
            where TAction : IStoreAction<TState>
        {
            Type type = typeof(TAction);

            serviceCollection.AddTransient(type);
        }

        public void RegisterAction(IStoreAction<TState> action)
        {
            serviceCollection.AddTransient(action.GetType(), _ => action);
        }
       
        public void RegisterHttpClient()
        {
            serviceCollection.AddHttpClient();
        }

        public void RegisterHttpClient<TInterface, TImplementation>()
            where TInterface : class
            where TImplementation : class, TInterface
        {
            serviceCollection.AddHttpClient<TInterface, TImplementation>();
        }

        public void RegisterHttpClient<TInterface, TImplementation>(Action<HttpClient> configureHttpClient)
            where TInterface : class
            where TImplementation : class, TInterface
        {
            serviceCollection.AddHttpClient<TInterface, TImplementation>(configureHttpClient);
        }

        public void RegisterReducer<TReducer, TOutput>()
            where TOutput : class
            where TReducer : class, IReducer<TState, TOutput>
        {
            serviceCollection.AddTransient<IReducer<TState, TOutput>, TReducer>();
        }

        public void RegisterReducer<TOutput>(IReducer<TState, TOutput> reducer)
            where TOutput : class
        {
            serviceCollection.AddTransient(_ => reducer);
        }

        public void RegisterService<TService>() where TService : class
        {
            Type type = typeof(TService);

            serviceCollection.AddScoped(type);
        }

        public void RegisterService<TService>(TService service) where TService : class
        {
            serviceCollection.AddScoped(_ => service);
        }

        public void RegisterService<TInterface, TImplementation>()
            where TInterface : class
            where TImplementation : class, TInterface
        {
            serviceCollection.AddScoped<TInterface, TImplementation>();
        }

        public void SetInitialState(TState state)
        {
            InitialState = state;
        }

        public IServiceProvider BuildServices()
        {
            return serviceCollection.BuildServiceProvider();
        }
    }
}
