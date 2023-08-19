using AutoMapper;
using eyas_Task4.Models;
using eyas_Task4.Service.empServices;
using eyas_Task4.Service.etsService;
using eyas_Task4.Tabels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eyas_Task4.Controllers
{
    public class mainController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IempServices _empServices;
        private readonly IetsService _etsService;
        private readonly IMapper _mapper;

        public mainController(ApplicationDbContext context,  IMapper mapper ,IempServices iempServices)
        {
            _context = context;
            _mapper = mapper;
            _empServices = iempServices;
        }

/*
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var list = await _empServices.GetAll();
            return Ok(list);
        }
*/
/// /dead

        [HttpGet("AddRelation")]
        public async Task<IActionResult> AddRelation(EmpTransSalary m)
        {
            var list = await _etsService.addSalary(m);
            return Ok(list);
        }

    }
}
