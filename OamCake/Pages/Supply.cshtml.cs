using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OamCake.Data.Context;
using OamCake.Data.Entity;
using OamCake.Data.Dto;
using OamCake.Repository;

namespace OamCake.Pages
{
    public class SupplyModel : PageModel
    {
        [BindProperty]
        public SupplyDto Supply { get; set; }
        public string Message { get; set; }
        public IEnumerable<Supply> Supplies { get; set; }


        private readonly ISupplyRepository _supplyRepository;
        private readonly IMapper _mapper;

        public SupplyModel(ISupplyRepository supplyRepository, IMapper mapper)
        {
            _supplyRepository = supplyRepository;
            _mapper = mapper;
        }

        public async Task OnGetAsync(string id, string action)
        {
            switch (action)
            {
                case "new": Supply = null;
                    break;
                case "edit":
                    Supply = _mapper.Map<SupplyDto>(await _supplyRepository.GetAsync(p => p.Id == new Guid(id)));
                    break;
                case "delete":
                    if (await _supplyRepository.Delete(p => p.Id == new Guid(id)))
                    {
                        await _supplyRepository.SaveChangesAsync();
                        Message = "Registro eliminado";
                    }
                    break;
            }

            await GetSupplies();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Supply.Id == null)
            {
                _supplyRepository.Create(sup => _mapper.Map<Supply>(Supply));
                await _supplyRepository.SaveChangesAsync();
                Message = "Registro agregado";
            }
            else
            {
                Func<Supply, Supply> fun = sup =>
                {
                    sup.Name = Supply.Name;
                    sup.Description = Supply.Description;
                    return sup;
                };

                if (await _supplyRepository.Update(fun, sub => sub.Id == new Guid(Supply.Id)))
                {
                    await _supplyRepository.SaveChangesAsync();
                    Message = "Registro modificado";
                }
            }

            await GetSupplies();
            return RedirectToPage("./Supply", new { id = "", action = "" });
        }

        private async Task GetSupplies()
        {
            Supplies = await _supplyRepository.ToListAsync(sup => true);
        }
    }
}
