﻿using AutoMapper;
using BookShopApp.Application.Common.Exceptions;
using BookShopApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorBiography
{
    public class GetAuthorBiographyHandler:IRequestHandler<GetAuthorBiographyQuery,AuthorBiographyVm>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetAuthorBiographyHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<AuthorBiographyVm> Handle(GetAuthorBiographyQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dataContext.Authors.FirstOrDefaultAsync(author=>author.Id==request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(entity), request.Id);
            }

            return _mapper.Map<AuthorBiographyVm>(entity);
        }
    }
}
