using Gatherly.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherly.Application.Contracts.Infrastructure.Jwt;

public interface IJwtProvider
{
    string Generate(Member member);
}
