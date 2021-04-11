using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FindeksManager : IFindeksService
    {
        IUserService _userService;

        public FindeksManager(IUserService userService)
        {
            _userService = userService;
        }

        public IDataResult<int> GetFindeksScore(int userId)
        {
            int findeksScore = 1400;
            return new SuccessDataResult<int>(findeksScore, Messages.FindeksCalculateCompleted);
        }
    }
}
