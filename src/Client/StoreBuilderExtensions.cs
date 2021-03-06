﻿using System;
using System.Net.Http;
using BlazorFocused.Store;

namespace BlazorFocused.Client
{
    public static class StoreBuilderExtensions
    {
        public static void RegisterRestClient<TState>(this IStoreBuilder<TState> builder, string baseUrl)
            where TState : class =>
            builder.RegisterHttpClient<IRestClient, RestClient>(client =>
                client.BaseAddress = new Uri(baseUrl));

        public static void RegisterRestClient<TState>(
            this IStoreBuilder<TState> builder,
            Action<HttpClient> configureClient = null)
            where TState : class
        {
            if (configureClient is null)
            {
                builder.RegisterHttpClient<IRestClient, RestClient>();
            }
            else
            {
                builder.RegisterHttpClient<IRestClient, RestClient>(configureClient);
            }

        }
    }
}
