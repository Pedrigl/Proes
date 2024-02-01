using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProesBack.Infrastructure.Data.Repositories;
using ProesBack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProesTests
{
    [TestClass]
    public class UserTests
    {
        private readonly IUserViewModelService _userViewModelService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserTests(IMapper mapper)
        {
            _mapper = mapper;
            IUserRepository _userRepository = new UserRepository(GetFakeDbContext());
            IUserViewModelService _userViewModelService = new UserViewModelService(_userRepository, _mapper);
        }


    }
}
