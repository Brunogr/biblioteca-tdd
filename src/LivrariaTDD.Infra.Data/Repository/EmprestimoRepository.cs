﻿using BibliotecaTDD.Domain.Model;
using LivrariaTDD.Infra.Data.Repository.Base;
using LivrariaTDD.Infra.Data.Repository.Interface;

namespace LivrariaTDD.Infra.Data.Repository
{
    public class EmprestimoRepository : Repository<Emprestimo>, IEmprestimoRepository
    {
    }
}
