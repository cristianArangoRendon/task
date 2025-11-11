using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.core.DTOs.Authentication;

namespace task.core.Interfaces.Services
{
    public interface ITokenService
    {
        Task<TokenResultDTO> GenerateTokenAsync(object userData);

    }
}
