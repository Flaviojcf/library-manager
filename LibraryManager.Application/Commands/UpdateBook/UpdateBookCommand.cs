﻿using MediatR;

namespace LibraryManager.Application.Commands.UpdateBook
{
    public class UpdateBookCommand(Guid id, string author, string title, string iSBN, int yearPublication) : IRequest<Unit>
    {
        public Guid Id { get; private set; } = id;
        public string Author { get; private set; } = author;
        public string Title { get; private set; } = title;
        public string ISBN { get; private set; } = iSBN;
        public int YearPublication { get; private set; } = yearPublication;
    }
}
