﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using Integration.Shared.Models;

namespace Integration.Server.Services
{
    public class ToDoService : IToDoService
    {
        public ValueTask<ToDoItem> AddToDoItem(ToDoItem toDoItem)
        {
            return new ValueTask<ToDoItem>(toDoItem);
        }

        public IEnumerable<ToDoItem> GenerateToDoItems(int count) =>
            GetRandomToDo().Generate(count);

        private Faker<ToDoItem> GetRandomToDo() =>
            new Faker<ToDoItem>()
                .RuleFor(todo => todo.Title, faker => faker.Commerce.ProductName())
                .RuleFor(todo => todo.Description, faker => faker.Commerce.ProductDescription())
                .RuleFor(todo => todo.Status, faker => faker.PickRandom<ToDoStatus>());
    }
}
