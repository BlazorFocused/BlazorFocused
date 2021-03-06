﻿using BlazorFocused.Store;

namespace BlazorFocused.Test.Utility
{
    public abstract class TestActionState<TState> : StoreAction<TState>
    {
        public string CheckedPropertyId { get; set; }
    }

    public abstract class TestActionState<TState, TInput> : StoreAction<TState, TInput>
    {
        public string CheckedPropertyId { get; set; }
    }
}
