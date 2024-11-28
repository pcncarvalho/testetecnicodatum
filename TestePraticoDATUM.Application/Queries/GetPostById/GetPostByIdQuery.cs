﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePraticoDATUM.Application.ViewModels;

namespace TestePraticoDATUM.Application.Queries.GetPostById
{
    public class GetPostByIdQuery : IRequest<PostViewModel>
    {
        public GetPostByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
