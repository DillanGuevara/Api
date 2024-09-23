﻿using SocialMedia.Core.Entities;
using System;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }

        IRepository<User> UserRepository { get; }

        IRepository<Comment> CommentRepository { get; }

        ILoginRepository LoginRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
