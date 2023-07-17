﻿using AutoMapper;
using BookShopApp.Application.Common.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorBiography
{
    public class GetAuthorDetailsQueryHandler:IRequestHandler<GetAuthorDetailsQuery,AuthorDetailsViewModel>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetAuthorDetailsQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<AuthorDetailsViewModel> Handle(GetAuthorDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dataContext.Authors.FirstOrDefaultAsync(author=>author.Id==request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            return _mapper.Map<AuthorDetailsViewModel>(entity);
        }
    }
}
