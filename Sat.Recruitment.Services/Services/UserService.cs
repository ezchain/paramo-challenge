using Sat.Recruitment.Domain.Enum;
using Sat.Recruitment.Domain.Exceptions;
using Sat.Recruitment.Domain.Extension;
using Sat.Recruitment.Domain.Interfaces.Models;
using Sat.Recruitment.Domain.Interfaces.Services;
using Sat.Recruitment.Domain.Models;
using Sat.Recruitment.Services.Factory;

namespace Sat.Recruitment.Services.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users;
        private readonly IFileReaderService _fileReaderService;
        public UserService(IFileReaderService fileReaderService)
        {
            _users = new List<User>();
            _fileReaderService = fileReaderService;
        }


        public IUser Create(IUser request)
        {
            var strategy = GiftCalculatorStrategyFactory.GetStrategy(request.UserType);
            var gift = strategy.CalculateGift(request.Money);
            request.Money = request.Money + gift;
            return Create(request.Name, request.Email, request.Phone, request.Address, request.UserType, request.Money);
        }

        public void Create(string path)
        {
            var data = _fileReaderService.ReadFromFile(path);
            decimal defaultMoney = 0;
            foreach (var item in data)
            {
                var rows = item.Split(',');
                var name = rows.ElementAtOrDefault(0);
                var email = rows.ElementAtOrDefault(1);
                var phone = rows.ElementAtOrDefault(2);
                var address = rows.ElementAtOrDefault(3);
                var userType = rows.ElementAtOrDefault(4).GetUserType();
                var money = rows.ElementAtOrDefault(5);
                decimal.TryParse(money, out defaultMoney);
                Create(name, email, phone, address, userType, defaultMoney);
            }
        }

        private IUser Create(string name, string email, string phone, string address, UserTypeEnum userType, decimal money)
        {
            ValidateRequiredFields(name, email, phone, address);
            ValidateIsDuplicated(name, email, phone, address);

            var user = new User
            {
                Name = name,
                Email = email.FormatEmail(),
                Address = address,
                Phone = phone,
                UserType = userType,
                Money = money
            };

            _users.Add(user);
            return user;
        }


        private void ValidateRequiredFields(string? name, string? email, string? phone, string? address)
        {
            var errors = new List<string>();
            if (String.IsNullOrEmpty(name))
                errors.Add("Name is required.");
            if (String.IsNullOrEmpty(email))
                errors.Add("Email is required.");
            if (String.IsNullOrEmpty(address))
                errors.Add("Address is required.");
            if (String.IsNullOrEmpty(phone))
                errors.Add("Phone is required.");

            if(errors.Any())
                throw new RequiredFieldException(errors);

        }

        private void ValidateIsDuplicated(string name, string email, string phone, string address)
        {
            if (_users.Any(u => u.Email == email || u.Phone == phone || (u.Name == name && u.Address == address)))
                throw new DuplicatedUserException();
        }

    }
}